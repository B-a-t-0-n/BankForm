using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankForm
{
    public delegate void AccountHandler(string message);
    public class Account
    {
        public static List<int> ID = new List<int>();
        public string Name { get; private set; }
        public string AccountType { get; private set; }
        public DateTime CreateDate { get; private set; }
        public string  Surname { get; private set; }
        public string Patronymic { get; private set; }
        public Bitmap Image { get; set; }
        public int id { get; /*private*/ set; }
        public int Sum { get; /*private*/ set; }
        public string Comment { get; set; }

        public AccountHandler? notify;

        public event AccountHandler Notify
        {
            add
            {
                notify += value;
            }
            remove
            {
                notify -= value;
            }
        }

        public Account(string Name, string Surname, string Patronymic, string Type)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Patronymic = Patronymic;
            AccountType = Type;
            Sum = 0;
            id = ID.Count + 1;
            Comment = "";
            CreateDate = DateTime.Now;
        }

        public Account(string Name, string Surname, string Patronymic, string Type, int Sum)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Patronymic = Patronymic;
            AccountType = Type;
            this.Sum = Sum;
            id = ID.Count + 1;
            Comment = "";
            CreateDate = DateTime.Now;
        }

        public Account(string Name, string Surname, string Patronymic, string Type, int Sum, string Comment)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Patronymic = Patronymic;
            AccountType = Type;
            this.Sum = Sum;
            id = ID.Count + 1;
            this.Comment = Comment;
            CreateDate = DateTime.Now;
        }

        public Account(string Name, string Surname, string Patronymic, string Type, int Sum, string Comment, Bitmap image)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Patronymic = Patronymic;
            AccountType = Type;
            this.Sum = Sum;
            id = ID.Count + 1;
            this.Comment = Comment;
            CreateDate = DateTime.Now;
            this.Image = image;
        }
        public Account(string Name, string Surname, string Patronymic, string Type, string Comment)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Patronymic = Patronymic;
            AccountType = Type;
            this.Sum = 0;
            id = ID.Count + 1;
            this.Comment = Comment;
            CreateDate = DateTime.Now;
        }

        public string GetFullName()
        {
            return Surname + " " + Name + " " + Patronymic;
        }

        public void Put(int sum)
        {
            Sum += sum;
            notify?.Invoke($"На счет поступило: {sum}");   // 2.Вызов события 
        }

        public void Print()
        {
            if (Sum <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            notify?.Invoke($"Текущий баланс: {Sum}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void TakeOff(int sum)
        {
            if (sum > Sum)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                notify?.Invoke("Невозможно выполнить операцию недостаточно средств");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Sum -= sum;
                notify?.Invoke($"снято {sum}");
            }
        }

        public static double operator +(Account a, Account b)
        {
            return a.Sum + b.Sum;
        }

        public static double operator -(Account a, Account b)
        {
            return a.Sum - b.Sum;
        }

        public static bool operator <(Account a, Account b)
        {
            if(a.Sum < b.Sum)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator >(Account a, Account b)
        {
            if (a.Sum > b.Sum)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(Account a, Account b)
        {
            if (a.Sum == b.Sum)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Account a, Account b)
        {
            if (a.Sum != b.Sum)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}