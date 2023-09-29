using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankForm
{
    public partial class Registr_Form : Form
    {
        Bank bank;
        public Registr_Form(Bank bank)
        {
            this.bank = bank;
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(@"D:\проекты c#\BankForm\photo\noun_profile.png");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("поля ФИО и тип аккаунта обязательны");
            }
            else
            {
                int sum;
                bool program = false;
                do
                {
                    if (textBox5.Text == "")
                    {
                        sum = 0;
                        program = false;
                    }    
                    else
                    {
                        try
                        {
                            sum = Convert.ToInt32(textBox5.Text);
                            program = false;
                        }
                        catch
                        {
                            sum = 0;
                            MessageBox.Show("сумма была введена некорректно");
                            textBox5.Text = "";
                            program = true;
                        }
                    }
                } while (program);
                bank.Notify += Message_info;
                bank.Create(textBox2.Text, textBox1.Text, textBox3.Text, textBox4.Text, sum, textBox6.Text, new Bitmap(pictureBox1.Image));
                bank.Notify -= Message_info;
                Form1 form = new Form1(bank);
                form.Show();
                Close();
            }
        }

        private void Message_info(string a)
        {
            MessageBox.Show(a);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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
                    pictureBox1.Invalidate();
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1(bank);
            form.Show();
            Close();
        }
    }
}
