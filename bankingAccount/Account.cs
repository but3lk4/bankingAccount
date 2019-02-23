using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace bankingAccount
{
    public class Account
    {
        private float balance;
        private float minBalance = 10; // minimalna kwota na koncie

        public Account()
        {
        }

        public Account(int value)
        {
            balance = value;
        }

        public void Deposit(float amount)  // depozyt, dodanie środków na konto
        {
            balance += amount;
        }

        public void Withdraw(float amount)  //wypłata, pobranie określonej kwoty z konta
        {
            balance -= amount;
        }

        public void TransferFunds(Account destination, float amount)  //przekazanie kwoty na konto 
        {
            destination.Deposit(amount);
            Withdraw(amount);
        }

        public Account TransferMinFunds(Account destination, float amount)// sprawdzenie czy kwota na koncie jest większa niż minimalna
        {
            if (Balance - amount > MinBalance)
            {
                destination.Deposit(amount);
                Withdraw(amount);
            }
            else
            {
                throw new NotImplementedException();
            }
            return destination;
        }


        public float Balance
        {
            get { return balance; }
        }

        public float MinBalance
        {
            get { return minBalance; }
        }

    }
}