using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nhom5_DeTaiXLSS.DTO;
using Nhom5_DeTaiXLSS.BUS;
using System.Diagnostics;
using Form_;
using DevExpress.XtraSplashScreen;

namespace Nhom5_DeTaiXLSS
{
    public partial class Form1 : Form
    {
        List<Node> graph = new List<Node>();
        List<Node> QuaTrinh = new List<Node>();
        //Tính thời gian thực thi của Dijkstra
        Stopwatch watch = new Stopwatch();
        //
        GetData frmDT = null;
        //
        BUS_DonVi busDV = new BUS_DonVi();
        Graph g = new Graph();
        public Form1()
        {
            InitializeComponent();
            //Gán địa chỉ bắt đầu
            txtVTBD.Text = "875 Âu Cơ, Phường 14, Tân Phú, Thành phố Hồ Chí Minh, Việt Nam";
            //
            txtSoLuong.Focus();
            //
        }

        private void btnXemDL_Click(object sender, EventArgs e)
        {
            
            if (txtSoLuong.TextLength == 0)
            {
                Console.Beep();
                txtSoLuong.Focus();
                MessageBox.Show("Vui lòng nhập số lượng đối tác lớn hơn 0!", "Thông báo lỗi");
                return;
            }
            if (int.Parse(txtSoLuong.Text) > 1000)
            {
                Console.Beep();
                txtSoLuong.Focus();
                MessageBox.Show("Số điểm nhập đã vượt tối đa số lượng Danh Sách Đối Tác!", "Thông báo lỗi");
                return;
            }
            graph = g.createDiaDiemList(int.Parse(txtSoLuong.Text));
            frmDT = new GetData(busDV.getDSDV(int.Parse(txtSoLuong.Text)));
            frmDT.Show();
        }
        private void HienThiListView(ListView lst, List<Node> quatrinh)
        {
            lst.Items.Clear();
            //Gán vào bảng Kết quả
            for (int i = 0; i < quatrinh.Count - 1; i++)
            {
                //Gán tên điểm đi
                ListViewItem lvt1 = new ListViewItem(quatrinh[i].name);
                //Gán tên điểm đến
                ListViewItem.ListViewSubItem l1 = new ListViewItem.ListViewSubItem(lvt1, (quatrinh[i + 1].name));
                //Làm tròn khoảng cách
                float khoangCach = (float)quatrinh[i + 1].Distance;
                //Gán khoảng cách giữa điểm đi và điểm đến
                ListViewItem.ListViewSubItem l2 = new ListViewItem.ListViewSubItem(lvt1, String.Format("{0}", khoangCach.ToString()));
                //Add tên điểm đến
                lvt1.SubItems.Add(l1);
                //Add tên điểm đi
                lvt1.SubItems.Add(l2);
                //Gán ListviewItem vào bảng listView kết quả.
                lst.Items.Add(lvt1);
            }
        }

        private void btnTimDuong_Click(object sender, EventArgs e)
        {
            if (txtSoLuong.TextLength == 0) {
                Console.Beep();
                txtSoLuong.Focus();
                MessageBox.Show("Vui lòng nhập số lượng đối tác lớn hơn 0!", "Thông báo lỗi");
                return;
            }
            if (int.Parse(txtSoLuong.Text) > 1000)
            {
                Console.Beep();
                txtSoLuong.Focus();
                MessageBox.Show("Số điểm nhập đã vượt tối đa số lượng Danh Sách Đối Tác!", "Thông báo lỗi");
                return;
            }
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            graph = g.createDiaDiemList(int.Parse(txtSoLuong.Text));
            Node batdau = graph[0];
            //Thực thi với điểm bắt đầu là điểm ở vị trí bắt đầu của danh sách
            Dijkstra dijkstra_2 = new Dijkstra(graph, batdau, 2);
            Dijkstra dijkstra_3 = new Dijkstra(graph, batdau);
            Dijkstra dijkstra_4 = new Dijkstra(graph, batdau, 4);
            //Hiển thị kết quả Truyền thống
            watch.Reset();
            watch.Start();
            QuaTrinh = dijkstra_2.RunTruyenThong();
            //Dừng thời gian sau khi thực thi xong
            watch.Stop();

            //Gán kết quả vào label
            lbThoiGian_TT.Text = String.Format("Thời gian thực thi: {0:00} s", watch.Elapsed.TotalSeconds.ToString());
            //lblThoiGianTruyenThong.Text = String.Format("Thời gian thực thi: {0:00} ms", watch.Elapsed.Milliseconds.ToString());
            lbThoiGian_TT.Visible = true;//Hiển thị thời gian trên form
            HienThiListView(lstV_TT, QuaTrinh);
            lbTongKC_TT.Text = String.Format("Tổng đường đi: {0:00}", QuaTrinh.Sum(p => p.Distance));
            lbTongKC_TT.Visible = true;//Hiển thị tổng đường đi trên form

            //Song song 2 tiến trình
            //Hiển thị kết quả binary heap
            watch.Reset();
            watch.Start();
            QuaTrinh = TaskEx.Run(() => dijkstra_2.Run_2()).Result;
            //Dừng thời gian sau khi thực thi xong
            watch.Stop();

            //Gán kết quả vào label
            lbThoiGian_SS2.Text = String.Format("Thời gian thực thi 2 luong: {0:00} s", watch.Elapsed.TotalSeconds.ToString());
            lbThoiGian_SS2.Visible = true;//Hiển thị thời gian trên form

            HienThiListView(lstV_SS2, QuaTrinh);

            lbTongKC_SS2.Text = String.Format("Tổng đường đi: {0:00}", QuaTrinh.ToList().Sum(p => p.Distance));
            lbTongKC_SS2.Visible = true;//Hiển thị tổng đường đi trên form

            

            //Song song 3 tiến trình
            watch.Reset();
            watch.Start();
            QuaTrinh = TaskEx.Run(() => dijkstra_3.Run_CoDong(3)).Result;
            //Dừng thời gian sau khi thực thi xong
            watch.Stop();

            //Gán kết quả vào label
            lbThoiGian_SS3.Text = String.Format("Thời gian thực thi 3 luong: {0:00} s", watch.Elapsed.TotalSeconds.ToString());
            lbThoiGian_SS3.Visible = true;//Hiển thị thời gian trên form
            //
            HienThiListView(lstV_SS3, QuaTrinh);
            //Tổng đường đi
            lbTongKC_SS3.Text = String.Format("Tổng đường đi: {0:00}", QuaTrinh.ToList().Sum(p => p.Distance));
            lbTongKC_SS3.Visible = true;//Hiển thị tổng đường đi trên form

            //Song song 4 tiến trình
            watch.Reset();
            watch.Start();
            QuaTrinh = TaskEx.Run(() => dijkstra_4.Run_4()).Result;
            //Dừng thời gian sau khi thực thi xong
            watch.Stop();

            //Gán kết quả vào label
            lbThoiGian_SS4.Text = String.Format("Thời gian thực thi 4 luong: {0:00} s", watch.Elapsed.TotalSeconds.ToString());
            lbThoiGian_SS4.Visible = true;//Hiển thị thời gian trên form
            //
            HienThiListView(lstV_SS4, QuaTrinh);
            //Tổng đường đi
            lbTongKC_SS4.Text = String.Format("Tổng đường đi: {0:00}", QuaTrinh.ToList().Sum(p => p.Distance));
            lbTongKC_SS4.Visible = true;//Hiển thị tổng đường đi trên form
            //
            SplashScreenManager.CloseForm();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtSoLuong.TextLength == 0)
            {
                Console.Beep();
                txtSoLuong.Focus();
                MessageBox.Show("Vui lòng nhập số lượng đối tác lớn hơn 0!", "Thông báo lỗi");
                return;
            }
            if (int.Parse(txtSoLuong.Text) > 1000)
            {
                Console.Beep();
                txtSoLuong.Focus();
                MessageBox.Show("Số điểm nhập đã vượt tối đa số lượng Danh Sách Đối Tác!", "Thông báo lỗi");
                return;
            }
            ChonLuongSongSong f1 = new ChonLuongSongSong(int.Parse(txtSoLuong.Text));
            f1.Show();
        }
    }
}
