using InterestCalculator.Src.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterestCalculator.Src.Interfaces
{
    public interface ICreditCardInterestRateGetter
    {
        decimal GetInterestRateForCardType(CreditTypes type);
    }
}
