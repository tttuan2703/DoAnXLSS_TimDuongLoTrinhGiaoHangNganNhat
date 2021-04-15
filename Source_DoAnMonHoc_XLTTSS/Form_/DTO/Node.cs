using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom5_DeTaiXLSS.DTO
{
    class Node
    {
        public int Id { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public string name { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public string tenQuan { get; set; }

        public bool IsSource { get; set; }

        public double Distance { get; set; }
        public double DistanceFormStart { get; set; }
        public List<Node> AdjacentList { get; set; }

        public bool Visited { get; set; }

        public Node ParentNode { get; set; }

        public Node()
        {
            this.AdjacentList = new List<Node>();
        }

        public Node(int id, string name, string SDT, string dchi, double x, double y,string tenQuan)
        {
            this.Id = id;
            this.name = name;
            this.x = x;
            this.y = y;
            this.SDT = SDT;
            this.DiaChi = dchi;
            this.AdjacentList = new List<Node>();
            this.tenQuan = tenQuan;
        }
        public Node(Node other)
        {
            this.Id = other.Id;
            this.name = other.name;
            this.x = other.x;
            this.y = other.y;
            this.SDT = other.SDT;
            this.DiaChi = other.DiaChi;
            this.AdjacentList = new List<Node>();
        }
        public Node(int id, int distance, List<Node> neighbors, bool isSource = false)
        {
            this.Id = id;
            this.Distance = distance;
            this.AdjacentList = neighbors;
            this.IsSource = isSource;
        }

        public double CompareTo(Node other)
        {
            return this.Distance - other.Distance;  // if we get a negative result, that means this node's distance is less than the other.
        }

        const double R = 6371;
        const double TO_RAD = (3.1415926536 / 180);

        //Tính khoảng cách từ điểm đi(u) tới điểm đến(v)
        public double dist(Node other)//Điểm đi(u)
        {
            double a, b, c;
            //Đổi tọa độ sang Radian
            double x2 = this.x * TO_RAD; //Tọa độ x của v;
            double y2 = this.y * TO_RAD; // Tọa độ y của v;
            double x1 = other.x * TO_RAD;    // Tọa độ x của u;
            double y1 = other.y * TO_RAD;    // Tọa độ y của u;

            double delta_X = x2 - x1;   //v.x - u.x
            double delta_Y = y2 - y1;   //v.y - u.y

            a = Math.Pow(Math.Sin(delta_Y / 2), 2);
            b = Math.Cos(y1) * Math.Cos(y2);
            c = Math.Pow(Math.Sin(delta_X / 2), 2);
            return Math.Asin(Math.Sqrt(a + b * c)) * 2 * R;
        }


        public double dist2(Node other)
        {
            double dx, dy, dz;
            double ph1 = this.x;
            double th1 = this.y;
            double ph2 = other.x;
            double th2 = other.y;
            ph1 -= ph2;
            ph1 *= TO_RAD; th1 *= TO_RAD; th2 *= TO_RAD;
            dz = Math.Sin(th1) - Math.Sin(th2);
            dx = Math.Cos(ph1) * Math.Cos(th1) - Math.Cos(th2);
            dy = Math.Sin(ph1) * Math.Cos(th1);
            return Math.Asin(Math.Sqrt(dx * dx + dy * dy + dz * dz) / 2) * 2 * R;
        }
    }
}
