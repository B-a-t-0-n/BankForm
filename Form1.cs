using System;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace BankForm
{
    public partial class Form1 : Form
    {
        public Bank bank = new Bank();
        
        public Form1()
        {
            InitializeComponent();
            bank.Create("Рамзан", "Кадыров", "Ахматович","депозит", 381000000);
            bank.Create("Иван", "Иванов", "Иванович", "обычный", 100,"здесь был Иван");
            bank.Create("Александр", "Фролов", "Сергеевич", "накопительный счёт");
   
        }

        public Form1(Bank bank)
        {
            InitializeComponent();
            this.bank = bank;
          

            //bank.Notify += ConsoleP;
        }



        //private void listBox1_Click(object sender, EventArgs e)
        //{
        //    int index = listBox1.SelectedIndex;
        //    if (listBox1.Text != "")
        //    {
        //        var form = new Form3(bank, index);
        //        form.Show();
        //        this.Hide();
        //    }

        //}




        private void button2_Click(object sender, EventArgs e)
        {
            var form = new Registr_Form(bank);
            form.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(textBox1.Text) - 1;
            var form = new Info_Form(bank, index);
            form.Show();
            this.Hide();
        }
    }
}