using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static List<string> Pics = new List<string>();
        private void Form1_Load(object sender, EventArgs e)
        {
              Control.CheckForIllegalCrossThreadCalls = false;
           
            //void timer_Tick(object sender, EventArgs e)
            //{
            //    //模拟的做一些耗时的操作
            //    System.Threading.Thread.Sleep(2000);
            //}
        }
        public bool Flag=false;
        public Thread th;
        private void button1_Click(object sender, EventArgs e)
        {
            th = new Thread(new ThreadStart(ThreadMethod));
          //  th.IsBackground=true;
            th.Start();
            Flag = true;
           
        }
        int piccount = 0;
        int sleepTime = 200;
        public void ThreadMethod()
        {
            Random Rd = new Random();
            while (Flag)
            {
               // picBox.Location = new Point(Rd.Next(500), Rd.Next(800));
                for (int i = 0; i < Pics.Count; i++)
                {

                    textBox1.Text = Pics[i]+Flag.ToString();
                    picBox.Image = Image.FromFile(Pics[i]);
                    picBox.Width = 300;
                    picBox.Height = 300;
                    //    picBox.Dock = DockStyle.Fill;
                    picBox.Refresh();
                    Thread.Sleep(sleepTime);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Flag = false;
            th.Suspend();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            picBox.Width = 300;
            picBox.Height = 300;
            picBox.Image = Image.FromFile(Pics[piccount]);
           // textBox1.Text = Pics[piccount] + Flag.ToString();
            picBox.Dock = DockStyle.Fill;
            piccount++;
            if (piccount == Pics.Count)
            {
                piccount = 0;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            this.textBox1.Text = folderBrowserDialog1.SelectedPath;
            Pics.Clear();
            DirectoryInfo folder = new DirectoryInfo(this.textBox1.Text);
            foreach (FileInfo file in folder.GetFiles())
            {
                Pics.Add(file.FullName);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sleepTime+=10;
            this.textBox2.Text = sleepTime.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            sleepTime -= 10;
            this.textBox2.Text = sleepTime.ToString();
        }
    }
}