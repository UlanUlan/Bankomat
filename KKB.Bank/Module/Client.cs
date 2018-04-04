using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.Bank.Module
{
    public class Client
    {
        public Client()
        {
            ListAccount = new List<Account>();

        }
        private string FullName_;
        public string FullName
        {
            get
            {
                return FullName_;
            }
            set
            {
                /*?<center><b><font size=7>Игнат
 Голованов
</font></b></center>*/
                FullName_ = value
                    .Replace("<center><b><font size=7>", "")
                    .Replace("</font></b></center>", "")
                    ;

            }
        }
        private string IIN_;
        public string IIN
        {
            get
            {
                return IIN_;
            }
            set
            {
                if (value.Length == 12)
                {
                    IIN_ = value;
                }
                else
                {
                    throw new Exception("Некорректно введён ИИН");
                }
            }
        }
        public DateTime DoB { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public List<Account> ListAccount;

        public bool isBlocked { get; set; } = false; 

        private int WrongField_ =0;
        public int WrongField
        {
            get
            {
                return WrongField_;
            }
            set
            {
                if(value >= 3)
                    isBlocked = true;
                WrongField_ = value;
            }
        }

        public void ClientInfoPrint()
        {
            Console.WriteLine("{0}\n {1}\n {2}\n {3}\n {4}\n {5}\n", FullName, IIN, Login, Password, PhoneNumber, DoB);
        }
        public void PrintAccountInfo()
        {
            double sumBalance = 0;
            foreach (Account item in ListAccount)
            {
                Console.WriteLine("KZ: {0}", item.AccountNumber);
                Console.WriteLine("Date Created: {0} ", item.CreateDate);
                Console.WriteLine("Exp. Date: {0}", item.CloseDate);
                Console.WriteLine("Balance: {0}", item.Balance);

                sumBalance += item.Balance;
            }
            
            Console.WriteLine("итого сумма на счетах: {0:n0}",sumBalance);
        }
        //public void 
    }
}
