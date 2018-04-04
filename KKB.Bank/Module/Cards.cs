using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.Bank.Module
{
    public enum CardType{ MasterCard, Visa, Maestro }
    public class Cards
    {
        public string CardNumber { get;  set; }
        public DateTime ExpDate { get; set; }
        public int CCV { get; set; }
        public CardType Cardtype { get;set;} 
        public string GetCardNumber()
        {
            string[] cn = CardNumber.Split(' ');

            cn[1] = "****";
            cn[2] = "****";

            return string.Format("{0} {1} {2} {3}", cn[0], cn[1], cn[2], cn[3]);
        
        }
        
        
    }
}
