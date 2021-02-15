using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Text.RegularExpressions;
using IronPython.Modules;

namespace WindowsFormsApp1
{
    public partial class mainForm : System.Windows.Forms.Form
    {
      
        public mainForm()
        {
            InitializeComponent();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private string textInBuffer = "";

        private async void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendialog = new OpenFileDialog();
            opendialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (opendialog.ShowDialog() != DialogResult.OK) return;
            setHref(opendialog.FileName);
            while (getTextFromBuffer().Length == 1)
            {
                await Task.Delay(100);
            }
            debugOutput.Text = "text is " +  getTextFromBuffer();
        
        }

        public string getCurrentDir()
        {
            string path = Directory.GetCurrentDirectory();
            int lenCutPart = "bin\\Debug\\netcoreapp3.1".Length;
            path = path.Substring(0, path.Length - lenCutPart);
            return path;
        }

        public string readFromBuffer()
        {
            string textFromBuffer;
            string path = Directory.GetCurrentDirectory();
            using (FileStream fstream = File.OpenRead(path + "\\buffer.txt"))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                textFromBuffer = System.Text.Encoding.Default.GetString(array);
            }

            return textFromBuffer;
        }

        public  void writeToBuffer(string text)
        {
            string path = Directory.GetCurrentDirectory();
            using (FileStream fstream = new FileStream(path + "\\buffer.txt", FileMode.Create))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                fstream.Write(array, 0, array.Length);
            }
        }

        string getTextFromBuffer()
        {
            string buffer = readFromBuffer();
            int index_second_slashn = 0;
            int tmp = 0;
            for (int i = 0; i < buffer.Length; i++)
            {

                if (buffer[i] == '\n') tmp++;

                if (tmp == 2 && (buffer[i] == '\n'))
                    index_second_slashn = i;
            }
        
            return buffer.Substring(index_second_slashn + 16);
        }

    
        void setHref(string href)
        {
            writeToBuffer("state = working\nhref = " + href + "\ntext on image = ");
        }

        void run_img_to_text_py()
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.FileName = "cmd.exe";

            p.StartInfo.CreateNoWindow = true;
            var path = Directory.GetCurrentDirectory();
            string text = "/C  python " + path + "\\img_to_text.py";
            p.StartInfo.Arguments = text;

            writeToBuffer("state = working\nhref = \ntext on image = ");
            p.Start();
        }
        private void mainForm_Load(object sender, EventArgs e)
        {
            run_img_to_text_py();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            writeToBuffer("state = closing\nhref = \ntext on image = \n");
        }
    }
}