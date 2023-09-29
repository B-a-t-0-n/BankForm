using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankForm
{
    public class Bank : IEnumerable
    {
        public  List<Account> account;
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
        public void Create(string Name, string Surname, string Patronymic, string Type)
        {
            account.Add(new Account(Name, Surname, Patronymic, Type));
            Account.ID.Add(account.Count);
            notify?.Invoke($"аккаунт создан id: {account.Count}");
        }
        public void Create(string Name, string Surname, string Patronymic, string Type, int Sum)
        {
            account.Add(new Account(Name, Surname, Patronymic, Type, Sum));
            Account.ID.Add(account.Count);
            notify?.Invoke($"аккаунт создан id: {account.Count}");
        }
        public void Create(string Name, string Surname, string Patronymic, string Type, int Sum, string Comment)
        {
            account.Add(new Account(Name, Surname, Patronymic, Type, Sum, Comment));
            Account.ID.Add(account.Count);
            notify?.Invoke($"аккаунт создан id: {account.Count}");
        }
        public void Create(string Name, string Surname, string Patronymic, string Type, int Sum, string Comment, Bitmap image)
        {
            account.Add(new Account(Name, Surname, Patronymic, Type, Sum, Comment, image));
            Account.ID.Add(account.Count);
            notify?.Invoke($"аккаунт создан id: {account.Count}");
        }
        public void Create(string Name, string Surname, string Patronymic, string Type, string Comment)
        {
            account.Add(new Account(Name, Surname, Patronymic, Type, Comment));
            Account.ID.Add(account.Count);
            notify?.Invoke($"аккаунт создан id: {account.Count}");
        }
        public Bank()
        {
            account = new List<Account>();
        }
        public void DeleteAccount(int id)
        {
            notify?.Invoke($"аккаунт с id: {id} удалён");
            Account.ID.Remove(id);
            account.Remove(account[id-1]);
        }
        public void AllId()
        {
            notify?.Invoke("Зарегестрированные Id\n");
            //foreach (var item in Account.ID)
            //{
            //    notify?.Invoke("ID :: "  + Convert.ToString(item));
            //}
            for(int i = 0; i < account.Count; i++)
            {
                notify?.Invoke("ID :: " + account[i].id + " sum :: " + account[i].Sum);
            }
        }
        public IEnumerator GetEnumerator()
        {
            var aa = new AccountNumerator(account);
            return aa;
        }
    }
}
