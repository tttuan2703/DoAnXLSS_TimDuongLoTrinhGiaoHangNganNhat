using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Form_.DTO
{
    class DTO_TruongHoc
    {
        int STT;

        public int STT1
        {
            get { return STT; }
            set { STT = value; }
        }
        string tenTruong;

        public string TenTruong
        {
            get { return tenTruong; }
            set { tenTruong = value; }
        }
        double kinhDo, ViDo;

        public double ViDo1
        {
            get { return ViDo; }
            set { ViDo = value; }
        }

        public double KinhDo
        {
            get { return kinhDo; }
            set { kinhDo = value; }
        }
        string SDT, diaChi, tenQuan;

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

        public string SDT1
        {
            get { return SDT; }
            set { SDT = value; }
        }

        public string TenQuan
        {
            get { return tenQuan; }
            set { tenQuan = value; }
        }
    }
}
