using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Graph
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            AdjacencyList a = new AdjacencyList();
            //添加顶点
            //a.AddVertex("A");
            //a.AddVertex("B");
            //a.AddVertex("C");
            //a.AddVertex("D");
            ////添加边
            //a.AddEdge("A", "B");
            //a.AddEdge("A", "C");
            //a.AddEdge("A", "D");
            //a.AddEdge("B", "D");

            a.AddVertex("V1");
            a.AddVertex("V2");
            a.AddVertex("V3");
            a.AddVertex("V4");
            a.AddVertex("V5");
            a.AddVertex("V6");
            a.AddVertex("V7");
            a.AddVertex("V8");
            a.AddEdge("V1", "V2");
            a.AddEdge("V1", "V3");
            a.AddEdge("V2", "V4");
            a.AddEdge("V2", "V5");
            a.AddEdge("V3", "V6");
            a.AddEdge("V3", "V7");
            //a.AddEdge("V4", "V8");
            a.AddEdge("V5", "V8");
            a.AddEdge("V6", "V8");
            //a.AddEdge("V7", "V8");
            a.DFSTraverse();

            rtbList.AppendText(a.ToString());
            rtbList.AppendText(a.dfsPath.ToString());
        }
    }
}
