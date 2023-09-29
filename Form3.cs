using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace BankForm
{
    public partial class Info_Form : Form
    {
        double tick;
        Bank bank;
        int index;
        public Info_Form(Bank bank, int index)
        {
            this.bank = bank;
            bank.notify += Message;
            this.index = index;
            InitializeComponent();
            BankAccountInfo();
            TimerStart();

        }

        private void TimerStart()
        {
            tick = 60;
            timer1.Interval = 1000; // 500 миллисекунд
            timer1.Enabled = false;
            timer1.Tick += timer1_Tick;
            timer2.Interval = (5  * 60) * 1000;
            timer2.Enabled = true;
            timer2.Tick += timer2_Tick;
            label2.Text = "";
        }

        private void Message(string mess)
        {
            MessageBox.Show(mess);
        }

        private void BankAccountInfo()
        {
            pictureBox1.Image = bank.account[index].Image; 
            textBox1.Text = "ФИО: " + bank.account[index].GetFullName() + "\r\nтип аккаунта: " + bank.account[index].AccountType +
           "\r\nid: " + bank.account[index].id + "\r\nдата создания: " + bank.account[index].CreateDate +
           "\r\nсчёт: " + Convert.ToString(bank.account[index].Sum) + "\r\nкоментарий: " + bank.account[index].Comment;
        }

        private void button_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1(bank);
            form.Show();
            Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            bank.DeleteAccount(index + 1);
            Form1 form = new Form1(bank);
            form.Show();
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = $"Выход в главное меню через {(int)tick}";
            //MessageBox.Show($"{tick}");
            tick -= 0.5;    
            if (tick == 0)
            {
                Form1 form = new Form1(bank);
                form.Show();
                Close();
            }
        }

        private void Form3_MouseClick(object sender, MouseEventArgs e)
        {
            timer1.Tick -= timer1_Tick;
            timer2.Tick -= timer2_Tick;
            TimerStart();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bank.account[index].Comment = textBox2.Text;
            BankAccountInfo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bank.account[index].Notify += Message;
            try
            {
                bank.account[index].TakeOff(Convert.ToInt32(textBox3.Text));
            }
            catch
            {
                MessageBox.Show("Введите сумму с которой хотите выполнить опперецию правильно");
            }
            textBox3.Text = "";
            bank.account[index].Notify -= Message;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bank.account[index].Notify += Message;
            try
            {
                bank.account[index].Put(Convert.ToInt32(textBox3.Text));
            }
            catch
            {
                MessageBox.Show("Введите сумму с которой хотите выполнить опперецию правильно");
            }
            textBox3.Text = "";
            bank.account[index].Notify -= Message;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap image; //Bitmap для открываемого изображения

            OpenFileDialog open_dialog = new OpenFileDialog(); //создание диалогового окна для выбора файла
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; //формат загружаемого файла
            if (open_dialog.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                try
                {
                    image = new Bitmap(open_dialog.FileName);
                    //вместо pictureBox1 укажите pictureBox, в который нужно загрузить изображение 
                    //this.pictureBox1.Size = image.Size;
                    pictureBox1.Image = image;
                    bank.account[index].Image = image;
                    pictureBox1.Invalidate();
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Info_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
