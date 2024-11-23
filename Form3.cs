using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizRunner
{

    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            if (System.IO.File.Exists(Directory.GetCurrentDirectory() + @"\statistika.txt"))
            {

                label1.Font = new Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
                label1.Text = "STATISTICS";

                var encoding = Encoding.GetEncoding(65001);
                FileStream load = new FileStream(Directory.GetCurrentDirectory() + @"\statistika.txt", FileMode.Open);
                StreamReader read = new StreamReader(load);
                label2.Text = read.ReadToEnd();
                load.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 train = new Form1();
            this.Visible = false;
            train.ShowDialog();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.IO.File.Delete(Directory.GetCurrentDirectory() + @"\statistika.txt");
            label1.Text = "";
            label2.Text = "";
        }
    }
}
