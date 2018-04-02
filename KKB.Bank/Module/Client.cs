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
                    .Replace("", "");

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
        List<Account> ListAccount;

        public void ClientInfoPrint()
        {
            Console.WriteLine("{0}\n {1}\n {2}\n {3}\n {4}\n {5}\n", FullName, IIN, Login, Password, PhoneNumber, DoB);
        }

    }
}
