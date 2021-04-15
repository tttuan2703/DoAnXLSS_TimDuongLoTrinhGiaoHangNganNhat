using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nhom5_DeTaiXLSS.DAL;
using System.Data;
using System.Data.SqlClient;
using Nhom5_DeTaiXLSS.DTO;

namespace Nhom5_DeTaiXLSS.BUS
{
    class BUS_DonVi
    {
        KetNoi_SQL kn = new KetNoi_SQL();
        XuLy xl = new XuLy();
        public DataTable getDSDV(int sl){
            string sql = "select top "+sl+" maTruong,tenTruong,DiaChi,SDT,KinhDo,ViDo,tenQuan"
                        +" from TruongHoc,Quan"
                        +" where TruongHoc.MaQuan=Quan.maQuan"
                        +" order by maTruong asc";
            return kn.load(sql);
        }
        public int layMaTruong(string tenTruong) {
            int kq = 0;
            string sql = "select maTruong from TruongHoc where tenTruong=N'" + tenTruong.Trim() + "'";
            try {
                kn.Mo();
                SqlDataReader rd = kn.ExecuteReader(sql);
                while (rd.Read()) {
                    kq = int.Parse(rd["maTruong"].ToString());
                }
                kn.Dong();
                return kq;
            }
            catch {
                return kq;
            }
        }
        public List<Ds_KhoangCachCacDiem> ds_KhoangCach(Node node,List<Node> dsNode) {
            List<Ds_KhoangCachCacDiem> ds = new List<Ds_KhoangCachCacDiem>();
            for (int i = 0; i < dsNode.Count; i++)
            {
                Ds_KhoangCachCacDiem kc = new Ds_KhoangCachCacDiem();
                kc.DiemDi = node.name;
                kc.DiemDen = dsNode[i].name;
                if (kc.DiemDi.Equals(kc.DiemDen))
                    continue;
                kc.KhoangCach = xl.harversine(node.y, node.x, dsNode[i].y, dsNode[i].x);
                ds.Add(kc);
            }
            return ds;
        }
        public Node getDoiTac(int ma) {
            Node n = new Node();
            try {
                string sql = "select * from TruongHoc where maTruong=" + ma;
                kn.Mo();
                SqlDataReader rd = kn.ExecuteReader(sql);
                while (rd.Read()) {
                    n.name = rd["tenTruong"].ToString();
                    n.x = double.Parse(rd["viDo"].ToString());
                    n.y = double.Parse(rd["kinhDo"].ToString());
                }
                kn.Dong();
                return n;
            }
            catch {
                return n;
            }
        }
    }
}
