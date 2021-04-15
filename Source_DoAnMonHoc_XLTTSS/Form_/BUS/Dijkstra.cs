using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nhom5_DeTaiXLSS.DTO;

namespace Nhom5_DeTaiXLSS.BUS
{
    class Dijkstra
    {
        public List<Node> Graph { get; private set; }
        public Node Source { get; private set; }
        private List<Node> visitedNodes;
        private List<Node>[] mangs;
        public Dijkstra(List<Node> graph, Node source,int soLuong)
        {
            this.Graph = graph;
            this.Source = source;
            ChiaMang(soLuong);
        }
        public Dijkstra(List<Node> graph, Node source)
        {
            this.Graph = graph;
            this.Source = source;
        }
        public List<Node> RunTruyenThong()
        {
            if (this.Graph == null || this.Graph.Count == 0 || this.Source == null)
            {
                throw new Exception("Cannot run Dijkstra without proper graph and source node.");
            }
            //Mặc định các điểm trong danh sách có khoảng cách là dương vô cùng,ngoại trừ điểm bắt đầu là 0
            this.Initialize();
            //Đánh dấu điểm bắt đầu đã duyệt
            this.Source.Visited = true;
            //Tạo danh sách các điểm đã duyệt
            this.visitedNodes = new List<Node>();
            //Node sẽ duyệt ban đầu là node bắt đầu
            Node current = this.Source;
            while (visitedNodes.Count < this.Graph.Count)
            {
                //Tạo một node nhỏ nhất có khoảng cách là dương vô cùng, để chứa thông tin Node có khoảng cách nhỏ nhất
                //với điều kiện Node đó chưa thăm
                Node min = new Node();
                min.Distance = int.MaxValue;
                //Đánh dấu node đã thăm, thêm vào danh sách đã thăm
                current.Visited = true;
                visitedNodes.Add(current);
                //Lần lượt duyệt từng nút kề của Node đang duyệt
                foreach (var neighbor in current.AdjacentList)
                {
                    var indexOfNeighbor = current.AdjacentList.IndexOf(neighbor);
                    if (indexOfNeighbor < 0 || !current.AdjacentList.Contains(neighbor))
                    {
                        throw new Exception("Can't find neighbor, thus can relax edge between these two vertices.");
                    }
                    //Lấy Node trong Graph tương ứng với nút đang duyệt
                    Node v = this.Graph.Find(p => p.Id == neighbor.Id);
                    //Nếu là Node chưa thăm thì sẽ cập nhật khoảng cách Node kề có phải là nhỏ nhất
                    if (v.Visited == false)
                    {
                        v.Distance = neighbor.Distance;
                        v.ParentNode = current;
                        //Nếu Node có khoảng cách nhỏ nhất thì sẽ gán min là Node đó
                        if (min.Distance > neighbor.Distance)
                        {
                            min = v;
                        }
                    }
                }
                //Sau khi duyệt hết thì Node sẽ xét tiếp theo là Node có khoảng cách nhỏ nhất(min)
                current = min;
            }
            return visitedNodes;
        }

        protected void Initialize()
        {
            foreach (var node in this.Graph)
            {
                node.Distance = int.MaxValue; // Mặc định khoảng cách dương vô cùng
                node.DistanceFormStart = int.MaxValue;
                node.ParentNode = null;
                node.Visited = false;
            }
            this.Source.Distance = 0;//Gán điểm bắt đầu là 0;
        }
        protected void PrintPath(List<Node> visitedNodes)
        {
            double tong = 0;
            Console.WriteLine("Duong di ngan nhat tu {0}:",this.Source.Id);
            Console.WriteLine("v\tw(u,v)\tw({0},v)", this.Source.Id);
            foreach (Node i in visitedNodes)
            {
                tong = tong + i.Distance;
                Console.WriteLine(i.Id + "\t" + i.Distance + "\t" + tong);
            }
            Console.WriteLine("Tong duong di: " + tong);
            Console.ReadLine();
        }
        protected Node minDis(List<Node> graph)
        {
            Node min=new Node();
            min.Distance = int.MaxValue;
            foreach (Node i in graph)
            {
                if ((i.Visited == false))
                {
                    if(min.Distance>i.Distance)
                    min = i;
                }
            }
            return min;
        }
        public async Task<List<Node>> Run_2(){

            if (this.Graph == null || this.Graph.Count == 0 || this.Source == null)
            {
                throw new Exception("Cannot run Dijkstra without proper graph and source node.");
            }

            this.Initialize();
            this.Source.Visited = true;
            this.visitedNodes = new List<Node>();
            Node u = this.Source;

            while (visitedNodes.Count < this.Graph.Count)
            {
                u.Visited = true;
                this.visitedNodes.Add(u);
                    var tasks = new List<Task<Node>>();
                    var task1 = TaskEx.Run(()=>PartialResult(mangs[0], u, visitedNodes));
                    var task2 = TaskEx.Run(() => PartialResult(mangs[1], u, visitedNodes));
                    tasks.Add(task1);
                    tasks.Add(task2);
                    var results=await TaskEx.WhenAll(tasks.ToArray());

                    Node min = new Node();
                    min.Distance = double.MaxValue;
                    for (int i = 0; i < results.Length; i++)
                    {
                        if (min.Distance > results[i].Distance)
                        {
                            min = results[i];
                        }
                    }
                        u = min;
            }
            return visitedNodes;
        }
        public async Task<List<Node>> Run_CoDong(int soLuong)
        {

            if (this.Graph == null || this.Graph.Count == 0 || this.Source == null)
            {
                throw new Exception("Cannot run Dijkstra without proper graph and source node.");
            }

            this.Initialize();
            ChiaMang(soLuong);
            this.Source.Visited = true;
            this.visitedNodes = new List<Node>();
            Node u = this.Source;

            while (visitedNodes.Count < this.Graph.Count)
            {
                u.Visited = true;
                this.visitedNodes.Add(u);
                var tasks = new List<Task<Node>>();
                for(int dem=0;dem<soLuong;dem++)
                {
                    int index = dem;
                    //if (dem == soLuong)
                    //{ continue; }
                    //else
                    //{
                        var task1 = TaskEx.Run(() => PartialResult(mangs[index], u, visitedNodes));
                        tasks.Add(task1);
                    //}
                }
                //tasks.Add(task2);
                var results = await TaskEx.WhenAll(tasks.ToArray());

                Node min = new Node();
                min.Distance = double.MaxValue;
                for (int i = 0; i < results.Length; i++)
                {
                    if (min.Distance > results[i].Distance)
                    {
                        min = results[i];
                    }
                }
                u = min;
            }
            return visitedNodes;
        }
        public async Task<List<Node>> Run_3()
        {
            if (this.Graph == null || this.Graph.Count == 0 || this.Source == null)
            {
                throw new Exception("Cannot run Dijkstra without proper graph and source node.");
            }

            this.Initialize();
            this.Source.Visited = true;
            this.visitedNodes = new List<Node>();
            Node u = this.Source;
            while (visitedNodes.Count < this.Graph.Count)
            {
                u.Visited = true;
                this.visitedNodes.Add(u);
                var tasks = new List<Task<Node>>();
                var task1 = TaskEx.Run(() => PartialResult(mangs[0], u, visitedNodes));
                var task2 = TaskEx.Run(() => PartialResult(mangs[1], u, visitedNodes));
                var task3 = TaskEx.Run(() => PartialResult(mangs[2], u, visitedNodes));
                tasks.Add(task1);
                tasks.Add(task2);
                tasks.Add(task3);
                var results = await TaskEx.WhenAll(tasks.ToArray());
                Node min = new Node();
                min.Distance = double.MaxValue;
                for (int i = 0; i < results.Length; i++)
                {
                    if (min.Distance > results[i].Distance)
                    {
                        min = results[i];
                    }
                }
                u = min;
            }
            return visitedNodes;
        }
        public async Task<List<Node>> Run_4()
        {
            if (this.Graph == null || this.Graph.Count == 0 || this.Source == null)
            {
                throw new Exception("Cannot run Dijkstra without proper graph and source node.");
            }

            this.Initialize();
            this.Source.Visited = true;
            this.visitedNodes = new List<Node>();
            Node u = this.Source;

            while (visitedNodes.Count < this.Graph.Count)
            {
                u.Visited = true;
                this.visitedNodes.Add(u);
                var tasks = new List<Task<Node>>();
                var task1 = TaskEx.Run(() => PartialResult(mangs[0], u, visitedNodes));
                var task2 = TaskEx.Run(() => PartialResult(mangs[1], u, visitedNodes));
                var task3 = TaskEx.Run(() => PartialResult(mangs[2], u, visitedNodes));
                var task4 = TaskEx.Run(() => PartialResult(mangs[3], u, visitedNodes));
                tasks.Add(task1);
                tasks.Add(task2);
                tasks.Add(task3);
                tasks.Add(task4);
                var results = await TaskEx.WhenAll(tasks.ToArray());
                Node min = new Node();
                min.Distance = double.MaxValue;
                for (int i = 0; i < results.Length; i++)
                {
                    if (min.Distance > results[i].Distance)
                    {
                        min = results[i];
                    }
                }
                u = min;
                //}
            }
            return visitedNodes;
        }
        public static Node PartialResult(List<Node> graph, int start, int size, int rowCount, bool[] used, int[] ans, Node minNode)
        {
            Node min=new Node();

            Node current=graph.Find(p => p.Id == minNode.Id);
            if(current!=null){
                    foreach (var neighbor in minNode.AdjacentList)
                {
                    var indexOfNeighbor = minNode.AdjacentList.IndexOf(neighbor);
                    if (indexOfNeighbor < 0 || !minNode.AdjacentList.Contains(neighbor))
                    {
                        throw new Exception("Can't find neighbor, thus can relax edge between these two vertices.");
                    }
                    //Lấy Node trong Graph tương ứng với nút đang duyệt
                    Node v = graph.Find(p => p.Id == neighbor.Id);
                    //Nếu là Node chưa thăm thì sẽ cập nhật khoảng cách Node kề có phải là nhỏ nhất
                    if (v.Visited == false)
                    {
                        v.Distance = neighbor.Distance;
                        v.ParentNode = current;
                    }
                    if (min.Distance > neighbor.Distance)
                    {
                        min = v;
                    }
                }
                }
            return min;
        }
        public static Node PartialResult(List<Node>mang,Node minNode,List<Node> visited)
        {
                Node current=minNode;
                Node min = new Node();
                min.Distance = double.MaxValue;
                foreach (var neighbor in current.AdjacentList)
                {
                    //Lấy Node trong Graph tương ứng với nút đang duyệt
                    Node v = mang.Find(p => p.Id == neighbor.Id);
                    //Nếu là Node chưa thăm thì sẽ cập nhật khoảng cách Node kề có phải là nhỏ nhất
                    if (v != null)
                    {
                        if (!visited.Contains(v))
                        {
                            v.Distance = neighbor.Distance;
                            v.ParentNode = current;
                            if (min.Distance > v.Distance)
                            {
                                min = v;
                            }
                        }
                    }
                }
                return min;
            }
        public void ChiaMang(int SoLuong)
        {
            var partRowCount = this.Graph.Count / SoLuong;
            mangs = new List<Node>[SoLuong];
            int end=0;
            for (int i = 0; i < SoLuong; i++)
            {
                int start=partRowCount*i;
                end =partRowCount*(i+1);
                List<Node> mangCon = new List<Node>();
                for (int j = start; j < end; j++)
                {
                    mangCon.Add(this.Graph[j]);
                }
                mangs[i] = mangCon;
            }
            if (end != Graph.Count)
            {
                int k = 0;
                for (int i = end; i < Graph.Count(); i++)
                {
                    if (mangs[SoLuong-1].FirstOrDefault(m => m == Graph[i]) == null)
                    {
                        mangs[k].Add(Graph[i]);
                        k++;
                    }
                    if (k == SoLuong)
                        k = 0;
                }
            }
        }
      }
    }
