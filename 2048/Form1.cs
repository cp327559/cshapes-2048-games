using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    
    public partial class Form1 : Form
    {

        Games g;       
        public Form1()
        {
            InitializeComponent();
        }
        //打开程序
        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("D:\\2048保存文档")) //检测是否有存档
            {   
                GetLoad();
            }
            else
            {
                g = new Games();
                g.Again();
                
            }
            lblMaax.Text = g.max.ToString();
            draw();
        }
        //捕捉按键动作做出相应操作
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    g.Up();
                    if (g.change)
                    {
                        g.AddNum();
                    }
                    lblGrade.Text = g.grade.ToString();
                    break;
                case Keys.Down:
                    g.Down();
                    if (g.change)
                    {
                        g.AddNum();
                    }
                    lblGrade.Text = g.grade.ToString();
                    break;
                case Keys.Left:
                    g.Left();
                    if (g.change)
                    {
                        g.AddNum();
                    }
                    lblGrade.Text = g.grade.ToString();
                    break;
                case Keys.Right:
                    g.Right();
                    if (g.change)
                    {
                        g.AddNum();
                    }
                    lblGrade.Text = g.grade.ToString();  
                    break;
                case Keys.F5:
                    plHelp.Show();
                    break;
                case Keys.Enter:                    
                    g.Again();
                    draw();
                    plGameOver.Visible = false;
                    lblGrade.Text = g.grade.ToString();
                    lblMaax.Text = g.max.ToString();
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }
            draw();
            if(g.over)
            {
                plGameOver.Visible = true;
                lblYourGrade.Text = g.grade.ToString();
                lblMax.Text = g.Max().ToString();
            }
        }
        /// <summary>
        /// 画出方块
        /// </summary>
        private void draw()
        {
            PictureBox[,] pb = new PictureBox[4, 4]{
                               {num1,num2,num3,num4},
                               {num5,num6,num7,num8},
                               {num9,num10,num11,num12},
                               {num13,num14,num15,num16}
                               };
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Draw(pb[i, j], g.n[i, j]);
                }
            }
        }


        /// <summary>
        /// 给方块赋值
        /// </summary>
        /// <param name="p"></param>
        /// <param name="num"></param>
        private void Draw(PictureBox p, int num)
        {
            switch (num)
            {
                case 0: p.Image = global::_2048.Properties .Resources._0; break;
                case 2: p.Image = global::_2048.Properties.Resources.奶酪; break;
                case 4: p.Image = global::_2048.Properties.Resources.老鼠; break;
                case 8: p.Image = global::_2048.Properties.Resources.猫; break;
                case 16: p.Image = global::_2048.Properties.Resources.狗; break;
                case 32: p.Image = global::_2048.Properties.Resources.猴子; break;
                case 64: p.Image = global::_2048.Properties.Resources.狼; break;
                case 128: p.Image = global::_2048.Properties.Resources.豹子; break;
                case 256: p.Image = global::_2048.Properties.Resources.熊; break;
                case 512: p.Image = global::_2048.Properties.Resources.熊猫; break;
                case 1024: p.Image = global::_2048.Properties.Resources.老虎; break;
                case 2048: p.Image = global::_2048.Properties.Resources.狮子; break;
                case 4096: p.Image = global::_2048.Properties.Resources.大象; break;
                case 8192: p.Image = global::_2048.Properties.Resources.驯兽师; break;
                default: break;
            }
        }

        
        /// <summary>
        /// 序列化Game类，并保存，相当于存档
        /// </summary>
        private void Save()
        {
            FileStream fw = new FileStream("D:\\2048保存文档", FileMode.Create, FileAccess.Write);
            BinaryFormatter formatter_w = new BinaryFormatter();
            formatter_w.Serialize(fw, g);
            fw.Close();
        }

        /// <summary>
        /// 从文件反序列化读取存档     
        /// </summary>
        private void GetLoad()
        {
            FileStream fr = new FileStream("D:\\2048保存文档", FileMode.Open, FileAccess.Read);
            BinaryFormatter formatter_r = new BinaryFormatter();
            g = (Games)formatter_r.Deserialize(fr);
            lblGrade.Text = g.grade.ToString();
            lblMaax .Text = g.max.ToString();
            fr.Close();

        }
        //关闭程序提示保存
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult dr = MessageBox.Show("需要保存吗？", "关闭", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Save();
            }
            else if (dr == DialogResult.No)
            { }
        }
        private void label9_Click(object sender, EventArgs e)
        {
            plHelp.Visible = false;
        }

        private void plGameOver_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }      
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
