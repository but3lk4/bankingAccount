using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bankingAccount;

namespace bankingAccountTests
{
    [TestFixture]
    public class AccountTest
    {
        Account source;
        Account destination;

        [SetUp]
        public void InitAccount()
        {
            
            source = new Account();
            source.Deposit(200.00F);
            destination = new Account();
            destination.Deposit(150.00F);
        }

        [Test]
        public void bankingAccount_WhenTransferFunds_CheckIfAmountIsEqualAfter() // sprawdzamy czy po przelewie zgadza się źródło i docelowe konto 
        {
            //act
            source.TransferFunds(destination, 100.00F); //transfer ze źródła 

            //assert 
            Assert.AreEqual(250.00, destination.Balance);
            Assert.AreEqual(100.00, source.Balance);
        }

        [Test]
        public void bankingAccount_WhenTransferFunds_CheckIfAmountIsDiffAfter() // sprawdzamy czy po przelewie zgadza się źródło i docelowe konto 
        {
            //act
            source.TransferFunds(destination, 100.00F); //transfer ze źródła 

            //assert 
            Assert.AreNotEqual(300.00, destination.Balance);
            Assert.AreNotEqual(99.00, source.Balance);
        }

        [Test]
        [TestCase(200, 0, 78)] // parametry będą przekazane do zmiennych a,b,c w każdym testcase
        [TestCase(200, 0, 189)] 
        [TestCase(200, 0, 1)]
        public void bankingAccount_WhenTransferMinimalFunds_BalanceGreaterThanMinimalBalance(int a, int b, int c)
        {
            Account source = new Account(); //ustawiamy źródło
            source.Deposit(a);
            Account destination = new Account(); //cel
            destination.Deposit(b);

            source.TransferMinFunds(destination, c); //sprawdzamy czy przy przelewie nie zostanie zbyt mała kwota na rachunku
            Assert.AreEqual(c, destination.Balance);
        }


        

        [Test]
        public void bankingAccount_TransferMinimalFunds_FailAll([Values(200, 500)] int a, [Values(0, 20)]int b,
        [Values(140, 135)]int c)
        {
            Account source = new Account();
            source.Deposit(a);
            Account destination = new Account();
            destination.Deposit(b);

            destination = source.TransferMinFunds(destination, c);
        }

    }

   
   
}