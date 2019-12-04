using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _22_DeadLockResolveSample
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Main Started");

            Account accountA = new Account(101, 5000);
            Account accountB = new Account(102, 3000);

            Console.WriteLine("{0} Current Balance = {1}", accountA.ID.ToString(), accountA.GetCurrentBalance().ToString());

            Console.WriteLine("{0} Current Balance = {1}", accountB.ID.ToString(), accountB.GetCurrentBalance().ToString());

            Console.WriteLine("-------------");

            AccountManager accountManagerA = new AccountManager(accountA, accountB, 1000);
            Thread t1 = new Thread(accountManagerA.Transfer);
            t1.Name = "T1";

            AccountManager accountManagerB = new AccountManager(accountB, accountA, 2000);
            Thread t2 = new Thread(accountManagerB.Transfer);
            t2.Name = "T2";

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();


            Console.WriteLine("Main Complate");
            Console.Read();

        }
    }


    #region Business 
    public class Account
    {
        double _balance;
        readonly int _id;

        public Account(int id, double balance)
        {
            this._id = id;
            this._balance = balance;
        }

        public int ID
        {
            get { return _id; }
        }

        public void Withdraw(double amount)
        {
            _balance -= amount;
        }

        public void Deposit(double amount)
        {
            _balance += amount;
        }

        public double GetCurrentBalance()
        {
            return _balance;
        }

    }
 
    public class AccountManager
    {
        Account _fromAccount;
        Account _toAccount;
        double _amountToTransfer;

        public AccountManager(Account fromAccount, Account toAccount, double amountToTransfer)
        {
            _fromAccount = fromAccount;
            _toAccount = toAccount;
            _amountToTransfer = amountToTransfer;
        }

        //Lock is applicable to only one resource at a time
        public void Transfer()
        {
            object _lock1, _lock2;

            if (_fromAccount.ID < _toAccount.ID)
            {
                _lock1 = _fromAccount;
                _lock2 = _toAccount;
            }
            else
            {
                _lock1 = _toAccount;
                _lock2 = _fromAccount;
            }

            Console.WriteLine(Thread.CurrentThread.Name + " trying to acquire lock on " + ((Account)_lock1).ID.ToString());

            lock (_lock1)
            {
                Console.WriteLine(Thread.CurrentThread.Name + " acquired lock on " + ((Account)_lock1).ID.ToString());
                Console.WriteLine(Thread.CurrentThread.Name + " suspended for 1 second");

                Thread.Sleep(1000);

                Console.WriteLine(Thread.CurrentThread.Name + " back in action and trying to acquire lock on " + ((Account)_lock2).ID.ToString());

                lock (_lock2)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + " acquired lock on " + ((Account)_lock2).ID.ToString());

                    _fromAccount.Withdraw(_amountToTransfer);
                    _toAccount.Deposit(_amountToTransfer);

                    Console.WriteLine(Thread.CurrentThread.Name + " Transfered " + _amountToTransfer.ToString() + " from " + _fromAccount.ID.ToString() + " to " + _toAccount.ID.ToString());
                    Console.WriteLine("{0} Current Balance = {1}", _fromAccount.ID.ToString(), _fromAccount.GetCurrentBalance().ToString());
                    Console.WriteLine("{0} Current Balance = {1}", _toAccount.ID.ToString(), _toAccount.GetCurrentBalance().ToString());
                    
                    Console.WriteLine("-------------");

                }
            }
        }

    }
    #endregion
}
