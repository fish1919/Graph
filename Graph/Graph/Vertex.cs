//代码来源于http://www.cnblogs.com/abatei/archive/2008/06/06/1215114.html

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graph
{
    //嵌套类，表示链表中的表结点
    public class Node
    {
        public Vertex adjvex; //邻接点域
        public Node next; //下一个邻接点指针域
        public Node(Vertex value)
        {
            adjvex = value;
        }
    }

    //表示存放于数组中的表头结点
    public class Vertex
    {
        public string data; //数据
        public Node firstEdge; //邻接点链表头指针
        public Boolean visited; //访问标志,遍历时使用
        public Vertex(string value) //构造方法
        {
            data = value;
        }
    }
    
}
