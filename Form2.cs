using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace QuizRunner
{
    public partial class Form2 : Form
    {
        int question_count;
        int correct_answers;
        int wrong_answers;
        int persent = 100;

        int realage;
        int psycologicalage;

        string[] array;
        string[] file;

        int[] perm = Enumerable.Range(0, 50).ToArray();
        Random run = new Random();
        int stringnum;

        string correct_answer;
        string selected_response;
        private Func<int> a;

        string path = Directory.GetCurrentDirectory() + @"\statistika.txt";

        public StreamReader Read { get; private set; }

        public Form2()
        {
            InitializeComponent();
            for (int i = 49; i >= 1; i--)
            {
                int j = run.Next(i + 1);
                int temp = perm[j];
                perm[j] = perm[i];
                perm[i] = temp;
            }
        }

        void Start()
        {
            button2.Text = "Следущий вопрос";

            var encoding = Encoding.GetEncoding(65001);

            try
            {
                Read = new StreamReader(Directory.GetCurrentDirectory() + @"\question.txt", encoding);
                this.Text = "Тест на проверку вашего IQ.";
                question_count = 0;
                correct_answers = 0;
                wrong_answers = 0;
                correct_answer = "";
                array = new String[500];
                file = new String[500];
                int k = 0;
                while (Read.EndOfStream == false)
                {
                    k++;
                    file[k] = Read.ReadLine();
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Fatal: miistake");
            }

            question();
        }

        void question()
        {
            stringnum = perm[question_count];
            question_count++;
            int stroke_num = 8 * stringnum + 1;
            label1.Text = (question_count.ToString() + "." + file[stroke_num] + "\n" + file[stroke_num + 1] + "\n" + file[stroke_num + 2] + "\n" + file[stroke_num + 3] + "\n" + file[stroke_num + 4] + "\n" + file[stroke_num + 5] + "\n" + file[stroke_num + 6]);
            correct_answer = file[stroke_num + 7];
            textBox1.Text = string.Empty;
            button2.Enabled = false;
            if ((stringnum + 1 == 4) || (stringnum + 1 == 5) || (stringnum + 1 == 6) || (stringnum + 1 == 8) || (stringnum + 1 == 12) || (stringnum + 1 == 14) || (stringnum + 1 == 16) || (stringnum + 1 == 19) || (stringnum + 1 == 20) || (stringnum + 1 == 22) || (stringnum + 1 == 23) || (stringnum + 1 == 26) || (stringnum + 1 == 27) || (stringnum + 1 == 33) || (stringnum + 1 == 35) || (stringnum + 1 == 36) || (stringnum + 1 == 37) || (stringnum + 1 == 38) || (stringnum + 1 == 41) || (stringnum + 1 == 42) || (stringnum + 1 == 45) || (stringnum + 1 == 47) || (stringnum + 1 == 48) || (stringnum + 1 == 50))
            {
                pictureBox1.Visible = true;
                pictureBox1.Image = Image.FromFile("pictures/" + (stringnum + 1).ToString() + ".jpg");
            }
            else
            {
                pictureBox1.Visible = false;
            }
            if (question_count == 20)

                button2.Text = "завершить";

        }

        void switchcheck(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 train = new Form1();
            this.Visible = false;
            train.ShowDialog();
            this.Close();
        }
        private void Form2_Load(object sender, EventArgs e)
        {

            button2.Text = "Следущий вопрос";
            textBox1.TextChanged += new EventHandler(switchcheck);
            Start();

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var encoding = Encoding.GetEncoding(65001);
            selected_response = textBox1.Text;
            if (selected_response == correct_answer)
            {
                correct_answers++;
            }
            if (!(selected_response == correct_answer))
            {
                wrong_answers++;
                array[wrong_answers] = label1.Text;
            }

            if (button2.Text == "завершить")
            {
                Read.Close();

                textBox1.Visible = false;

                textBox1.Text = string.Empty;
                int IQ = correct_answers / question_count * persent + 60 + run.Next(0, 15);
                pictureBox1.Visible = false;

                label1.Text = String.Format("Тест завершен.\n" +
                    "Правильные ответы: {0} из {1}.\n" +
                    "Ваш IQ: {2}.", correct_answers,
                    question_count, IQ);


                string text = $"Your IQ: {IQ}\n";

                using (FileStream file = new FileStream(path, FileMode.OpenOrCreate))
                {
                    byte[] buffer = Encoding.Default.GetBytes(text);
                    file.Seek(0, SeekOrigin.End);
                    await file.WriteAsync(buffer, 0, buffer.Length);
                    file.Close();
                }

                button2.Visible = false;
            }
            if (button2.Text == "Следущий вопрос") question();

        }

        public string test_S(string dir)
        {
            return dir = path;
        }

        public string test_IQ(string dir1)
        {
            return dir1 = Base.Piq;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
