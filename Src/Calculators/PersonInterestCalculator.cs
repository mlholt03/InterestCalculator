using InterestCalculator.Src.Interfaces;
using InterestCalculator.Src.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterestCalculator.Src.Calculators
{
    public class PersonInterestCalculator : IInterestCalculator<Person>
    {
        private readonly IInterestCalculator<Wallet> walletCalculator;

        public PersonInterestCalculator(IInterestCalculator<Wallet> walletCalculator)
        {
            this.walletCalculator = walletCalculator ?? throw new ArgumentNullException(nameof(walletCalculator));
        }

        public void CalculateInterest(Person interestBearing)
        {
            if (interestBearing is null)
            {
                throw new ArgumentNullException(nameof(interestBearing));
            }

            var personInterest = 0.0M;

            interestBearing.Wallets.ForEach(cc =>
            {
                this.walletCalculator.CalculateInterest(cc);
                personInterest += cc.Interest;
            });

            interestBearing.Interest = personInterest;
        }
    }
}
