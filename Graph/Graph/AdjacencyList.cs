//代码来源于http://www.cnblogs.com/abatei/archive/2008/06/06/1215114.html
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graph
{
    //创建图的邻接表
    public class AdjacencyList
    {
        public StringBuilder dfsPath;
        List<Vertex> items; //图的顶点集合
        public AdjacencyList() : this(10) { } //构造方法
        public AdjacencyList(int capacity) //指定容量的构造方法
        {
            items = new List<Vertex>(capacity);
        }
        public void AddVertex(string item) //添加一个顶点
        {   //不允许插入重复值  
            if (Contains(item))
            {
                throw new ArgumentException("插入了重复顶点！");
            }
            
            items.Add(new Vertex(item));
        }

        public void AddEdge(string from, string to) //添加无向边
        {
            Vertex fromVer = Find(from); //找到起始顶点
            if (fromVer == null)
            {
                throw new ArgumentException("头顶点并不存在！");
            }

            Vertex toVer = Find(to); //找到结束顶点
            if (toVer == null)
            {
                throw new ArgumentException("尾顶点并不存在！");
            }

            //无向边的两个顶点都需记录边信息
            AddDirectedEdge(fromVer, toVer);
            AddDirectedEdge(toVer, fromVer);
        }

        public bool Contains(string item) //查找图中是否包含某项
        {
            foreach (Vertex v in items)
            {
                if (v.data.Equals(item))
                {
                    return true;
                }
            }
            
            return false;
        }

        private Vertex Find(string item) //查找指定项并返回
        {
            foreach (Vertex v in items)
            {
                if (v.data.Equals(item))
                {
                    return v;
                }
            }
        
            return null;
        }

        //添加有向边
        private void AddDirectedEdge(Vertex fromVer, Vertex toVer)
        {
            if (fromVer.firstEdge == null) //无邻接点时
            {
                fromVer.firstEdge = new Node(toVer);
            }
            else
            {
                Node tmp, node = fromVer.firstEdge;
                do
                {   //检查是否添加了重复边
                    if (node.adjvex.data.Equals(toVer.data))
                    {
                        throw new ArgumentException("添加了重复的边！");
                    }
                    
                    tmp = node;
                    node = node.next;
                } while (node != null);
                tmp.next = new Node(toVer); //添加到链表未尾
            }
        }

         public override string ToString() //仅用于测试
         {
             //打印每个节点和它的邻接点
             string s = string.Empty;
             foreach (Vertex v in items)
             {
                 s += v.data.ToString() + ":";
                 if (v.firstEdge != null)
                 {
                     Node tmp = v.firstEdge;
                     while (tmp != null)
                     {
                         s += tmp.adjvex.data.ToString();
                         tmp = tmp.next;
                     }
                 }
                 s += "\r\n";
             }
             return s;
         }

         public void DFSTraverse() //深度优先搜索
         {
             InitVisited(); //将visited标志全部置为false
             dfsPath = new StringBuilder();
             foreach (Vertex v in items)
             {
                 if (!v.visited) //如果未被访问
                 {
                     DFS(v); //深度优先遍历
                 }
             }

         }

         private void DFS(Vertex v)
         {
             v.visited = true; //将访问标志设为true
             //Console.Write(v.data + " "); //访问
             dfsPath.Append(v.data + " ");
             Node node = v.firstEdge;
             while (node != null) //访问此顶点的所有邻接点
             {
                 //如果邻接点未被访问，则递归访问它的边
                 if (!node.adjvex.visited)
                 {
                     DFS(node.adjvex); //递归
                 }
                 node = node.next; //访问下一个邻接点
             }
         }

         private void InitVisited()
         {
             foreach (Vertex v in items)
             {
                 v.visited = false; //全部置为false
             }
         }
        
    }
}
