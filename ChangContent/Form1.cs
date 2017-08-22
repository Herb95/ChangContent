using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChangContent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent ();
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            ReadTextFile read = new ReadTextFile ();
            read.ReadFile ();
        }
    }
    class ReadTextFile
    {
        public void ReadFile()
        {
            //直接读取出字符串
            //string text = System.IO.File.ReadAllText (@"..\test.txt");
            string text = System.IO.File.ReadAllText (@"D:\_VisualStudioProject\test\test.txt");
            Console.WriteLine (text);

            ////按行读取为字符串数组
            //string[] lines = System.IO.File.ReadAllLines (@"d:\_visualstudioproject\test\test.txt");
            //foreach (string line in lines)
            //{
            //    Console.WriteLine (line.ToString ());
            //}

            ////从头到尾以流的方式读出文本文件
            ////该方法会一行一行的读出文件
            //using (System.IO.StreamReader sr = new System.IO.StreamReader (@"D:\_VisualStudioProject\test\test.txt"))
            //{
            //    string str;
            //    while ((str = sr.ReadLine ()) != null)
            //    {
            //        Console.WriteLine (str.ToString());
            //    }
            //    Console.Read ();
            //}
        }
    }
}
