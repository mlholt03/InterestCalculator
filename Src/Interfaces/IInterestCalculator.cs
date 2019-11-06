using System;
using System.Collections.Generic;
using System.Text;

namespace InterestCalculator.Src.Interfaces
{
    public interface IInterestCalculator<T> where T : IInterestBearing
    {
        void CalculateInterest(T interestBearing);
        //Person Updater --> Wallet Updater
        //Wallet Updater --> Line Updater
        //Line Updater

        //InterestBearingOutputer --> Accepts object of type InterestBearing -> Returns interest amount
    }
}
