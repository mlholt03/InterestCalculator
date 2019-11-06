using InterestCalculator.Src.Interfaces;
using InterestCalculator.Src.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterestCalculator.Src.Calculators
{
    public class CreditCardInterestCalculator : IInterestCalculator<CreditCard>
    {
        private ICreditCardInterestRateGetter interestRateGetter = null;

        public CreditCardInterestCalculator(ICreditCardInterestRateGetter rateGetter)
        {
            this.interestRateGetter = rateGetter ?? throw new ArgumentNullException();
        }

        public void CalculateInterest(CreditCard interestBearing)
        {
            if (interestBearing is null)
            {
                throw new ArgumentNullException(nameof(interestBearing));
            }

            var rate = interestRateGetter.GetInterestRateForCardType(interestBearing.CreditType);

            interestBearing.Interest = interestBearing.Principal * rate;
        }
    }
}
