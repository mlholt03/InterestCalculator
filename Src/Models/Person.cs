using System.Collections.Generic;

namespace InterestCalculator.Src.Models
{
    public class Person : InterestBearing
    {
        public List<Wallet> Wallets { get; set; }
    }
}