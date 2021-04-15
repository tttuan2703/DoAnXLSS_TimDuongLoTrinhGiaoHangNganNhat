using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Nhom5_DeTaiXLSS.DTO
{
    class Ds_KhoangCachCacDiem
    {
        string diemDi, diemDen;

        public string DiemDi
        {
            get { return diemDi; }
            set { diemDi = value; }
        }

        public string DiemDen
        {
            get { return diemDen; }
            set { diemDen = value; }
        }

        double khoangCach;

        public double KhoangCach
        {
            get { return khoangCach; }
            set { khoangCach = value; }
        }

    }
}
