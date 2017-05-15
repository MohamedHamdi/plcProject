using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using com.calitha.commons;
using com.calitha.goldparser;



namespace PlcProject
{ 
    
    public partial class Form1 : Form
    {
        MyParser m;
        public Form1()
        {
         
            InitializeComponent();
            m = new MyParser("Simple.cgt", listBox1, listBox2, listBox3,label1,dataGridView1);
            label1.BackColor = Color.Red;
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();

            m.Parse(textBox1.Text);
           
         
        }

      
    }
}
