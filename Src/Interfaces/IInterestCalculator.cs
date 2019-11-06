using System;
using System.Collections.Generic;
using System.Text;

namespace InterestCalculator.Src.Interfaces
{
    public interface IInterestCalculator<T> where T : IInterestBearing
    {
        void CalculateInterest(T interestBearing);
    }
}
