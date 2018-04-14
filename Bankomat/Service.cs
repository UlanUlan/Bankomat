using KKB.Bank.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using GeneratorName;
namespace Bankomat
{
   public class Service
    {
        private static Random rnd = new Random();

        public static void createClient(ref Client c)
        {
            //Generator gen = new Generator();
            //c.FullName = gen.GenerateDefault(Gender.woman);
            c.FullName = "ABC";
            c.IIN = "123123123123";
            c.PhoneNumber = "+77781112233";
            c.DoB = DateTime.Now;

            for (int i = 0; i < rnd.Next(1, 8); i++)
            {
                c.ListAccount.Add(createAccount());
            }
        }

        public static Account createAccount()
        {
            Account acc = new Account();

            acc.AccountNumber = "KZ" + rnd.Next(11111, 999999);
            acc.CreateDate = DateTime.Now.AddMonths(-rnd.Next(1, 56));
            acc.Balance = double.Parse(rnd.Next(1000, 99999).ToString());

            return acc;
        }
    }
}
