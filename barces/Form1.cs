using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace barces
{
    public partial class Form1 : Form
    {
        public Graphics g;
        public List list=new List();
        bool ProgramEnd = false;
        Pen pe = new Pen(Color.Black);
        Pen pe1 = new Pen(Color.Red);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            treeView1.ImageList = imageList1;
            TreeNode newn= treeView1.Nodes.Add("vega1");
            newn.ImageIndex = 0;
            newn.SelectedImageIndex = 0;
            TreeNode newn2= treeView1.Nodes.Add("vega2");
            newn2.ImageIndex = 1;
            newn2.SelectedImageIndex = 1;
            TreeNode newn3= treeView1.Nodes.Add("vega3");
            newn3.ImageIndex = 2;
            newn3.SelectedImageIndex = 2;


            pe.Width = 3;
            g = panel1.CreateGraphics();
            timer1.Start();            
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            if (valuetxtBox.Text != "")
            {
                list.Append(new element(int.Parse(valuetxtBox.Text)));
                Write();
            }
            else
                MessageBox.Show("Please Enter Some Values !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void Write()
        {
            listBox1.Items.Clear();
            element null_e = new element();
            Point p1 = new Point();
            int yaxis = 50;
            int[] values=new int[5];
            int valuesConst = 5;
            int valuesCounter = 0;
            for (ListElement p = list.head; p!=null; p=p.Next)
            {
                int draw = 190;
                element[] e = new element[5];                
                for (int i = 0; i < 5; i++)
                {
                    e[i] = p.St.Top();
                    if (e[i] != null)
                    {
                        listBox1.Items.Add(Convert.ToString(e[i].value));
                        null_e = p.St.Pop();
                    }
                }
                if (valuesConst > 5)
                {
                    int[] TMP = new int[valuesConst - 5];
                    for (int x = 0; x < valuesConst-5; x++)
                    {
                        TMP[x] = values[x];
                    }                
                    values = new int[valuesConst];
                    for (int y = 0; y < valuesConst-5; y++)
                    {
                        values[y] = TMP[y];
                    }
                }
                for (int h = e.Length - 1; h >= 0; h--)
                {
                    if (e[h] != null)
                    {                        
                        p.St.Push(e[h]);
                        values[valuesCounter] = e[h].value;
                        valuesCounter++;
                    }
                }
                valuesConst += 5;
                
                    g.Clear(Color.White);
                    int innerY = 50;
                    int arrow = 100;
                    bool drawArrow = false;
                    bool SecondRowArrow = true;
                    bool SecondRowRect = true;
                    for (int l = 0; l <= list.count; l++)
                    {
                        if (drawArrow)
                        {
                            if (l < 5)
                            {
                                g.DrawLine(pe, arrow + 50, 120, arrow + 100, 120);
                                g.DrawLine(pe, arrow + 80, 110, arrow + 100, 120);
                                g.DrawLine(pe, arrow + 80, 130, arrow + 100, 120);
                            }
                            else
                            {
                                if (SecondRowArrow)
                                {
                                    g.DrawLine(pe, arrow + 50, 120, arrow + 70, 120);
                                    g.DrawLine(pe, arrow + 70, 120, arrow + 70, 240);
                                    g.DrawLine(pe, 25, 240, arrow + 70, 240);
                                    g.DrawLine(pe, 25, 240, 25, 360);
                                    g.DrawLine(pe, 25, 360, 50, 360);
                                    arrow = 100;
                                    SecondRowArrow = false;
                                }
                                g.DrawLine(pe, arrow + 50, 360, arrow + 100, 360);
                                g.DrawLine(pe, arrow + 80, 350, arrow + 100, 360);
                                g.DrawLine(pe, arrow + 80, 370, arrow + 100, 360);
                            }
                            arrow += 150;
                        }
                        if (l < 5)
                        {
                            g.DrawRectangle(pe, innerY, 20, 100, 200);
                            for (int j = 180; j > 20; j = j - 40)
                            {
                                g.DrawLine(pe, innerY, j, innerY + 100, j);
                            }
                        }
                        else
                        {
                            if(SecondRowRect)
                            {
                                innerY = 50;
                                SecondRowRect = false;
                            }
                            g.DrawRectangle(pe, innerY, 260, 100, 200);
                            for (int j = 420; j > 260; j = j - 40)
                            {
                                g.DrawLine(pe, innerY, j, innerY + 100, j);
                            }
                        }                        
                        innerY += 150;
                        drawArrow = true;                        
                    }      
                        int count = 0;
                        int count2=5;
                        yaxis = 50;
                        bool SecondValues = false;
                        for (int k = 0; k <valuesCounter; k++)
                        {
                           if (values[k] != 0)
                            {
                                if (!SecondValues)
                                {
                                    p1.X = yaxis + 45;
                                    p1.Y = draw;
                                    draw -= 40;
                                    g.DrawString(Convert.ToString(values[k]), valuetxtBox.Font, pe.Brush, p1);
                                    count++;
                                    if (count == count2)
                                    {
                                        yaxis += 150;
                                        draw = 190;
                                        count2 += 5;
                                    }
                                    if (k == 25)
                                    {
                                        SecondValues = true;
                                        yaxis = 50;
                                        draw = 430;
                                        count--;
                                    }
                                }
                                if(SecondValues)
                                {
                                    p1.X = yaxis + 45;
                                    p1.Y = draw;
                                    draw -= 40;
                                    g.DrawString(Convert.ToString(values[k]), valuetxtBox.Font, pe.Brush, p1);
                                    count++;
                                    if (count == count2)
                                    {
                                        yaxis += 150;
                                        draw = 430;
                                        count2 += 5;
                                    }
                                    if (k == 50 && !ProgramEnd)
                                        if (MessageBox.Show("Etc............", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                                        {
                                            ProgramEnd = true;
                                            Write();
                                        }                                    
                                }                               
                            }
                        }
                        listBox1.Items.Add(" ");                                             
            }              
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        string s = "Add Some Values !";
        int Scounter = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Scounter != 17)
            {
                valuetxtBox.Text += Convert.ToString(s[Scounter]);
                Scounter++;
            }
            else
                timer1.Stop();
        }

        private void valuetxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void valuetxtBox_MouseDown(object sender, MouseEventArgs e)
        {
            valuetxtBox.Text = "";
        }

        private void Finbtn_Click(object sender, EventArgs e)
        {
            Mark(list.Find(int.Parse(valuetxtBox.Text)));
        }

        public void Mark(string Data)
        {
            Write();
            if (Data != "")
            {
                string[] FirstSplitData = new string[(Data.Length / 4)];
                FirstSplitData=Data.Split(',');
                int[] I = new int[FirstSplitData.Length-1];
                int[] J = new int[FirstSplitData.Length-1];
                for (int i = 0; i < FirstSplitData.Length-1; i++)
                {
                    string[] SecondSplitData = new string[2];
                    SecondSplitData = FirstSplitData[i].Split(' ');
                    I[i] = Convert.ToInt32(SecondSplitData[0]);
                    J[i] = Convert.ToInt32(SecondSplitData[1]);
                }

                for (int j = 0; j < I.Length; j++)
                {
                    int XAxis = 0, YAxis = 0;
                    if (I[j] <= 4)
                        YAxis = 180;
                    else
                    {
                        YAxis = 420;
                        I[j] = I[j] - 5;
                    }                    
                    XAxis = 50 + 150 * I[j];
                    YAxis = YAxis - 40 * J[j];
                    g.FillRectangle(pe1.Brush, XAxis+2, YAxis+2, 98, 10);
                    g.FillRectangle(pe1.Brush, XAxis+2, YAxis+2, 20, 38);
                    g.FillRectangle(pe1.Brush, XAxis+80, YAxis+2, 20, 38);
                    g.FillRectangle(pe1.Brush, XAxis+2, YAxis+23, 98, 17);
                }
            }
            else
                MessageBox.Show("There is No Data !", "Empty Stack", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
       
    }
}