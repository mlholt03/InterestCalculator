using InterestCalculator.Src.Enums;

namespace InterestCalculator.Src.Models
{
    public class CreditCard : InterestBearing
    {
        public decimal Principal { get; set; }
        public CreditTypes CreditType { get; set; }
    }
}
