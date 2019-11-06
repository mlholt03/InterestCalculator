using InterestCalculator.Src.Interfaces;
using InterestCalculator.Src.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace InterestCalculator.Src.Calculators
{
    public class WalletInterestCalculator : IInterestCalculator<Wallet>
    {
        private IInterestCalculator<CreditCard> creditCardInterestCalculator = null;
        public WalletInterestCalculator(IInterestCalculator<CreditCard> creditCardInterestCalculator)
        {
            this.creditCardInterestCalculator = creditCardInterestCalculator ?? throw new ArgumentNullException(nameof(creditCardInterestCalculator));
        }
        public void CalculateInterest(Wallet interestBearing)
        {
            if (interestBearing is null)
            {
                throw new ArgumentNullException(nameof(interestBearing));
            }

            var walletInterest = 0.0M;

            interestBearing.CreditCards.ForEach(cc =>
            {
                this.creditCardInterestCalculator.CalculateInterest(cc);
                walletInterest += cc.Interest;
            });

            interestBearing.Interest = walletInterest;
        }
    }
}
