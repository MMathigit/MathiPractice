using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AccountTransactionApp.Models
{
    class Account
    {
        private readonly int _accountNumber;
        private readonly string _name;
        private double _balance;
        private const double MIN_BALANCE = 500;
        private List<Transaction> _transactions = new List<Transaction>();

        public Account(int accountNumber, string name, double balance)
        {
            _accountNumber = accountNumber;
            _name = name;
            _balance = balance;
        }

        public Account(int accountNumber, string name)
        {
            _accountNumber = accountNumber;
            _name = name;
            _balance = MIN_BALANCE;
        }

        public void Deposit(double amount)
        {

            _balance = _balance + amount;
            _transactions.Add(new Transaction { Amount = amount, Date = DateTime.Now, Type = "Deposit" });
        }

        public void Withdraw(double amount)
        {

            if (_balance - amount > MIN_BALANCE)
            {
                _balance = _balance - amount;
                _transactions.Add(new Transaction { Amount = amount, Date = DateTime.Now, Type = "Withdraw" });

            }

            //will throw exeception later,
            //throw new Exception("Insufficient balance");

        }

        public List<Transaction> Transactions
        {

            get
            {
                return _transactions;
            }
        }


        public double Balance
        {

            get { return _balance; }
        }

        public string Name
        {

            get { return _name; }
        }

        public int AccountNumber
        {

            get { return _accountNumber; }
        }

    }
}