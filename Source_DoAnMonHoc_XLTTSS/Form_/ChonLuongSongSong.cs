using DevExpress.XtraSplashScreen;
using Nhom5_DeTaiXLSS;
using Nhom5_DeTaiXLSS.BUS;
using Nhom5_DeTaiXLSS.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_
{
    public partial class ChonLuongSongSong : Form
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
        int sl = 0;
        public ChonLuongSongSong(int soluong)
        {
            InitializeComponent();
            //
            txtSoLuong.Focus();
            //
            graph = g.createDiaDiemList(soluong);
            sl = soluong;
            lbTongSL.Text +=" "+ soluong.ToString() +" đối tác";
        }

        private void btnTimDuong_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            if (int.Parse(txtSoLuong.Text)>sl)
            {
                Console.Beep();
                txtSoLuong.Focus();
                MessageBox.Show("Số luồng nhập đã vượt tối đa số lượng Danh Sách Đối Tác!", "Thông báo lỗi");
                return;
            }
            if (txtSoLuong.TextLength == 0)
            {
                Console.Beep();
                txtSoLuong.Focus();
                MessageBox.Show("Vui lòng nhập số lượng lớn hơn 0!", "Thông báo lỗi");
                return;
            }
            Node batdau = graph[0];
            //Thực thi với điểm bắt đầu là điểm ở vị trí bắt đầu của danh sách
            Dijkstra dijkstra_3 = new Dijkstra(graph, batdau);
            watch.Reset();
            watch.Start();
            QuaTrinh = TaskEx.Run(() => dijkstra_3.Run_CoDong(int.Parse(txtSoLuong.Text))).Result;
            //Dừng thời gian sau khi thực thi xong
            watch.Stop();

            //Gán kết quả vào label
            lbThoiGian.Text = String.Format("Thời gian thực thi "+txtSoLuong.Text+" luong: {0:00} s", watch.Elapsed.TotalSeconds.ToString());
            lbThoiGian.Visible = true;//Hiển thị thời gian trên form
            //
            HienThiListView(lstV_SS, QuaTrinh);
            //Tổng đường đi
            lbTongKC.Text = String.Format("Tổng đường đi: {0:00}", QuaTrinh.ToList().Sum(p => p.Distance));
            lbTongKC.Visible = true;//Hiển thị tổng đường đi trên form
            SplashScreenManager.CloseForm();            
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
    }
}
