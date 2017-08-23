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
        ReadTextFile read = new ReadTextFile ();

        private void Btn1_Click(object sender, EventArgs e)
        {
            List<string> s = read.ReadFile1 ();
            for (int i = 0; i < s.Count; i++)
            {
                textBox1.Text += s[i];
            }
        }
        private void Btn2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            WriteTextFile write = new ChangContent.WriteTextFile ();
            write.WriteFile (textBox2.Text);
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

            #region 按行读取为字符串数组
            ////按行读取为字符串数组
            //string[] lines = System.IO.File.ReadAllLines (@"d:\_visualstudioproject\test\test.txt");
            //foreach (string line in lines)
            //{
            //    Console.WriteLine (line.ToString ());
            //}
            #endregion
        }
        /// <summary>
        /// 读取文件  返回List
        /// </summary>
        /// <returns></returns>
        public List<string> ReadFile1()
        {
            //从头到尾以流的方式读出文本文件
            //该方法会一行一行的读出文件
            List<string> a = new List<string> ();
            using (System.IO.StreamReader sr = new System.IO.StreamReader (@"D:\_VisualStudioProject\test\test.txt"))
            {
                string str;
                while ((str = sr.ReadLine ()) != null)
                {
                    a.Add (str.ToString ());
                    //Console.WriteLine (str.ToString ());
                }
                Console.Read ();
                return a;
            }
        }
    }

    class WriteTextFile
    {
        public void WriteFile()
        {
            //如果文件不存在，则创建；存在则覆盖
            //该方法写入字符数组换行显示
            string[] lines = { "first line", "second line", "third line", "第四行第四行第四行第四行第四行第四行" };
            System.IO.File.WriteAllLines (@"D:\_VisualStudioProject\test\test.txt", lines, Encoding.UTF8);

            //如果文件不存在，则创建;存在则覆盖
            string strTest = "该例子测试一个字符串写入文本文件。";
            System.IO.File.WriteAllText (@"D:\_VisualStudioProject\test\test.txt", strTest, Encoding.UTF8);


            //在将文本写入文件前，处理文本行
            //streamWriter一个参数默认覆盖
            //streamWriter第二个参数为false覆盖现有文件，为true则把文本追加到文本末尾
            using (System.IO.StreamWriter file = new System.IO.StreamWriter (@"D:\_VisualStudioProject\test\test.txt", true))
            {
                foreach (string line in lines)
                {
                    if (!line.Contains("second"))
                    {
                        //直接追加文件末尾不换行
                        file.Write (line);
                        //直接追加文件末尾，换行
                        file.WriteLine (line);
                    }
                }
            }
        }

        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="textBoxLine"></param>
        public void WriteFile(string textBoxLine)
        {
            ////如果文件不存在，则创建；存在则覆盖
            ////该方法写入字符数组换行显示
            //string[] lines = { "first line", "second line", "third line", "第四行第四行第四行第四行第四行第四行" };
            //System.IO.File.WriteAllLines (@"D:\_VisualStudioProject\test\test.txt", lines, Encoding.UTF8);

            ////如果文件不存在，则创建;存在则覆盖
            //string strTest = textBoxLine;
            //System.IO.File.WriteAllText (@"D:\_VisualStudioProject\test\test.txt", strTest, Encoding.UTF8);

            ////在将文本写入文件前，处理文本行
            ////streamWriter一个参数默认覆盖
            ////streamWriter第二个参数为false覆盖现有文件，为true则把文本追加到文本末尾
            //using (System.IO.StreamWriter file = new System.IO.StreamWriter (@"D:\_VisualStudioProject\test\test.txt", true))
            //{
            //    foreach (string line in lines)
            //    {
            //        if (!line.Contains ("second"))
            //        {
            //            //直接追加文件末尾不换行
            //            file.Write (line);
            //            //直接追加文件末尾，换行
            //            file.WriteLine (line);
            //        }
            //    }
            //}

            List<string> liness = new List<string> ();
            liness.Add (textBoxLine);
            System.IO.File.WriteAllLines (@"D:\_VisualStudioProject\test\test.txt", liness, Encoding.UTF8);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter (@"D:\_VisualStudioProject\test\test.txt", true))
            {
                foreach (string line in liness)
                {
                    file.Write (line);
                }
            }

        }
    }
}
