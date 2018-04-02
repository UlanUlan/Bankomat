using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.Bank.Module
{
    class Account
    {
        public Account()
        {
            ListCards = new List<Cards>();
          //  Balance = 0;
        }

        public DateTime CreateDate { get; set; }
        public DateTime CloseDate { get; set; }
        public string AccountNumber { get; set; }
        public double Balance { get; set; } = 0;
        public List<Cards> ListCards;
        public void PrintCardInfo()
        {
            foreach (Cards item in ListCards)
            {
                string info = string.Format("{0}\t ({1}) - {2}",
                    item.GetCardNumber(), item.Cardtype, item.ExpDate);

                Console.WriteLine(info);
            }
        }
        
    }
}
