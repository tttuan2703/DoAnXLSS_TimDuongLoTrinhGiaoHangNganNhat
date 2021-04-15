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
using Form_.DTO;

namespace Nhom5_DeTaiXLSS
{
    public partial class GetData : Form
    {
        DataTable tb = new DataTable();
        List<Node> graph = new List<Node>();
        BUS_DonVi busDV = new BUS_DonVi();
        Graph g = new Graph();
        public GetData(DataTable dt)
        {
            InitializeComponent();
            graph = g.createDiaDiemList(dt.Rows.Count);
            List<string> lst = new List<string>();
            foreach (Node n in graph) {
                lst.Add(n.name);
            }
            Object[] obj = lst.Cast<Object>().ToArray();
            cboDSDV.Items.AddRange(obj);
            //
        }

        private void llbAllDV_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dgvDSDV.DataSource = loadDL();
        }

        List<DTO_TruongHoc> loadDL(){
            List<DTO_TruongHoc> dsTH=new List<DTO_TruongHoc>();
            foreach (Node n in graph) { 
                DTO_TruongHoc th=new DTO_TruongHoc();
                th.STT1=n.Id;
                th.TenTruong=n.name;
                th.ViDo1=n.x;
                th.KinhDo=n.y;
                th.SDT1=n.SDT;
                th.DiaChi= n.DiaChi;
                th.TenQuan = n.tenQuan;
                dsTH.Add(th);
            }
            return dsTH;
        }

        private void cboDSDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDSDV.Text.Equals("")) {
                return;
            }
            Node node ;
            if (cboDSDV.SelectedIndex == 0)
                node = graph[0];
            else
                node = busDV.getDoiTac(busDV.layMaTruong(cboDSDV.Text));
            //
            List<Ds_KhoangCachCacDiem> dsTH = busDV.ds_KhoangCach(node, graph).OrderBy(d=>d.KhoangCach).ToList();
            dgvDSDV.DataSource =dsTH ;
            Ds_KhoangCachCacDiem kc = dsTH.Single(d => d.KhoangCach == (dsTH.Min(d1 => d1.KhoangCach)));
            lbKQ.Text="Khoảng cách ngắn nhất: "+kc.DiemDen+" ("+kc.KhoangCach+" mét).";
            lbKQ.Visible = true;
        }

    }
}
