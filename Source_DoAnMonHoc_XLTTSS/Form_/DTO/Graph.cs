using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nhom5_DeTaiXLSS.DAL;
using System.Data.SqlClient;

namespace Nhom5_DeTaiXLSS.DTO
{
    class Graph
    {
        private List<Ds_KhoangCachCacDiem> dsKC = new List<Ds_KhoangCachCacDiem>();
        private static Random random = new Random();
        Node daiLy=null;
        const double R = 6371;
        const double TO_RAD = (3.1415926536 / 180);
        public List<Node> createDiaDiemList(int sl)
        {
            //Tạo danh sách các đơn vị đối tác từ CSDL
            List<Node> vertex = new List<Node>();
            KetNoi_SQL kn = new KetNoi_SQL();
            //Lấy số lượng phần tử ngẫu nhiên
            int num = random.Next(0, 210);
            kn.Mo();
            //string sql = "select top " + 206 + " * from DonViDoiTac";
            string sql = "select top "+sl+" * from TruongHoc,Quan where truongHoc.MaQuan=Quan.maQuan";
            SqlDataReader rd = kn.ExecuteReader(sql);
            //Add dia diem long Thanh--Phan tử bắt đầu
            daiLy = new Node(0, "Đại lý giao hàng", "875 Âu Cơ, Phường 14, Tân Phú, Thành phố Hồ Chí Minh, Việt Nam", "0987281910", 10.797123, 106.637822,"QUẬN TÂN PHÚ");
            vertex.Add(daiLy);
            //
            while (rd.Read())
            {
                //Tạo node chứa thông tin của đơn vị
                Node u = new Node(int.Parse(rd["maTruong"].ToString()), rd["TenTruong"].ToString(), rd["DiaChi"].ToString(), rd["SDT"].ToString(), Double.Parse(rd["ViDo"].ToString()), Double.Parse(rd["KinhDo"].ToString()),rd["tenQuan"].ToString());
                u.Distance = 0;//Mặc định khoảng cách ban đầu là 0;
                vertex.Add(u);//Thêm node vào danh sách
            }
            kn.Dong();
            //Tạo danh sách điểm đến cho từng điểm
            for (int i = 0; i < vertex.Count; i++)
            {
                for (int j = 0; j < vertex.Count; j++)
                {
                    Node neightbor = new Node();
                    if (i == j)//Nếu điểm đến và điểm đi giống nhau
                    {
                        neightbor = new Node(vertex[i]);
                        neightbor.Distance = 0;//Gán khoảng cách cho điểm đến là 0
                    }
                    else
                    {
                        neightbor = new Node(vertex[j]);//Tạo một điểm đến
                        neightbor.Distance = (vertex[j].dist(vertex[i]) * 1000);//Thêm thông tin khoảng cách từ điểm đi cho điểm đến
                    }
                    vertex[i].AdjacentList.Add(neightbor);//Thêm điểm đến vào danh sách điểm đến của điểm đi
                }
            }
            return vertex;
        }
    }
}
