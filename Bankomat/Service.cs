using KKB.Bank.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratorName;

namespace Bankomat
{
    class Service
    {
        private static Random r = new Random(); 

        public static void createClient(ref Client c)
        {
            Generator gen = new Generator();
            c.FullName = gen.GenerateDefault(Gender.woman);
            c.IIN = "123123123123";
            c.PhoneNumber = "+77781112233";
            c.DoB = DateTime.Now;
            for (int i = 0; i < r.Next(1,8); i++)
            {
                c.ListAccount.Add(createAccount());
            }
        }
        public static Account createAccount()
        {
           
            Account acc = new Account();
            acc.AccountNumber = "KZ" + r.Next(100000, 100000000);
            acc.Balance = double.Parse(r.Next(100, 99999).ToString());
            acc.CreateDate =DateTime.Now.AddMonths(-r.Next());
            return acc;
        }
    }
}
