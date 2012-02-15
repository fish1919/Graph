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
            a.AddVertex("A");
            a.AddVertex("B");
            a.AddVertex("C");
            a.AddVertex("D");
            //添加边
            a.AddEdge("A", "B");
            a.AddEdge("A", "C");
            a.AddEdge("A", "D");
            a.AddEdge("B", "D");

            rtbList.AppendText(a.ToString());
        }
    }
}
