using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nhom5_DeTaiXLSS.DAL;
using Nhom5_DeTaiXLSS.DTO;

namespace Nhom5_DeTaiXLSS.BUS
{
    class XuLy
    {
        const double R = 6371;
        const double TO_RAD = (3.1415926536 / 180);
        KetNoi_SQL kn = new KetNoi_SQL();
        public int soLuongDonVi()
        {
            int dem = 0;
            try
            {
                string sql = "select count(*) from DonViDoiTac";
                dem = (int)kn.ExecuteScalar(sql);
                return dem;
            }
            catch
            {
                return dem;
            }
        }
        public ListViewItem[] DanhSachDonVi(List<Node> vertex)
        {
            ListViewItem[] ds = new ListViewItem[vertex.Count];
            int i = 0;
            
            foreach (Node u in vertex)
            {
                ListViewItem item = new ListViewItem(new[] { u.Id.ToString(), u.name.ToString(), u.SDT.ToString(), u.DiaChi.ToString(), u.x.ToString(), u.y.ToString() });
                ds[i] = item;
                i++;
            }
            return ds;
        }
        public double harversine(double th1, double ph1, double th2, double ph2)
        {
	        double dx, dy, dz;
	        ph1 -= ph2;
            ph1 *= TO_RAD; th1 *= TO_RAD; th2 *= TO_RAD;
            dz = Math.Sin(th1) - Math.Sin(th2);
            dx = Math.Cos(ph1) * Math.Cos(th1) - Math.Cos(th2);
            dy = Math.Sin(ph1) * Math.Cos(th1);
	        return Math.Asin(Math.Sqrt(dx * dx + dy * dy + dz * dz) / 2) * 2 * R;
        }
    }
}
