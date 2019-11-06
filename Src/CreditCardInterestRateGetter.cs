using InterestCalculator.Src.Enums;
using InterestCalculator.Src.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterestCalculator.Src
{
    public class CreditCardInterestRateGetter : ICreditCardInterestRateGetter
    {
        public decimal GetInterestRateForCardType(CreditTypes type)
        {
            var interestRate = 0.0M;

            switch (type) {
                case CreditTypes.Discover:
                    interestRate = .01M;
                    break;
                case CreditTypes.Mastercard:
                    interestRate = .05M;
                    break;
                case CreditTypes.Visa:
                    interestRate = .1M;
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Credit type {type} not valid.");
            }

            return interestRate;
        }
    }
}
