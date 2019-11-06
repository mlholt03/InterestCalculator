using System.Collections.Generic;

namespace InterestCalculator.Src.Models
{
    public class Wallet : InterestBearing
    {
        public List<CreditCard> CreditCards { get; set; }
    }
}
