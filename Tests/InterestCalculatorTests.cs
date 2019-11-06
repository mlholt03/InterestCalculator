using InterestCalculator.Src;
using InterestCalculator.Src.Calculators;
using InterestCalculator.Src.Enums;
using InterestCalculator.Src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace InterestCalculator.Tests
{
    public class InterestCalculatorTests
    {
        [Fact]
        public void Test1()
        {
            var person = new Person
            {
                Interest = 0m,
                Wallets = new List<Wallet>
                {
                    new Wallet
                    {
                        CreditCards = new List<CreditCard>
                        {
                            new CreditCard
                            {
                                CreditType = CreditTypes.Visa,
                                Principal = 100M
                            },
                            new CreditCard
                            {
                                CreditType = CreditTypes.Mastercard,
                                Principal = 100M
                            },
                            new CreditCard
                            {
                                CreditType = CreditTypes.Discover,
                                Principal = 100M
                            }
                        }
                    }
                }
            };
            var interestRateGetter = new CreditCardInterestRateGetter();
            var ccic = new CreditCardInterestCalculator(interestRateGetter);
            var wic = new WalletInterestCalculator(ccic);
            var pic = new PersonInterestCalculator(wic);

            pic.CalculateInterest(person);

            var expectedVisaInterest = 100 * .1M;
            var expectedMCInterest = 100 * .05M;
            var expectedDiscoverInterest = 100 * .01M;
            var expectedPersonInterest = expectedVisaInterest + expectedMCInterest + expectedDiscoverInterest;

            Assert.Equal(expectedPersonInterest, person.Interest);
            
            var actualVisaCC = person.Wallets.First().CreditCards.First(cc => cc.CreditType == CreditTypes.Visa);
            Assert.Equal(expectedVisaInterest, actualVisaCC.Interest);

            var actualMastercardCC = person.Wallets.First().CreditCards.First(cc => cc.CreditType == CreditTypes.Mastercard);
            Assert.Equal(expectedMCInterest, actualMastercardCC.Interest);

            var actualDiscoverCC = person.Wallets.First().CreditCards.First(cc => cc.CreditType == CreditTypes.Discover);
            Assert.Equal(expectedDiscoverInterest, actualDiscoverCC.Interest);
        }

        [Fact]
        public void Test2()
        {
            var person = new Person
            {
                Interest = 0m,
                Wallets = new List<Wallet>
                {
                    new Wallet
                    {
                        CreditCards = new List<CreditCard>
                        {
                            new CreditCard
                            {
                                CreditType = CreditTypes.Visa,
                                Principal = 100M
                            },
                            new CreditCard
                            {
                                CreditType = CreditTypes.Discover,
                                Principal = 100M
                            }
                        }
                    },
                    new Wallet
                    {
                        CreditCards = new List<CreditCard>
                        {
                            new CreditCard
                            {
                                CreditType = CreditTypes.Mastercard,
                                Principal = 100M
                            }
                        }
                    }
                }
            };
            var interestRateGetter = new CreditCardInterestRateGetter();
            var ccic = new CreditCardInterestCalculator(interestRateGetter);
            var wic = new WalletInterestCalculator(ccic);
            var pic = new PersonInterestCalculator(wic);

            pic.CalculateInterest(person);

            var expectedVisaInterest = 100 * .1M;
            var expectedMCInterest = 100 * .05M;
            var expectedDiscoverInterest = 100 * .01M;
            var expectedPersonInterest = expectedVisaInterest + expectedMCInterest + expectedDiscoverInterest;

            Assert.Equal(expectedPersonInterest, person.Interest);

            var expectedWallet1Interest = expectedVisaInterest + expectedDiscoverInterest;            
            var actualWallet1 = person.Wallets.First(w => w.CreditCards.Count == 2);
            Assert.Equal(expectedWallet1Interest, actualWallet1.Interest);

            var expectedWallet2Interest = expectedMCInterest;
            var actualWallet2 = person.Wallets.First(w => w.CreditCards.Count == 1);
            Assert.Equal(expectedWallet2Interest, actualWallet2.Interest);
        }

        [Fact]
        public void Test3()
        {
            var person = new Person
            {
                Interest = 0m,
                Wallets = new List<Wallet>
                {
                    new Wallet
                    {
                        CreditCards = new List<CreditCard>
                        {
                            new CreditCard
                            {
                                CreditType = CreditTypes.Mastercard,
                                Principal = 100M
                            },
                            new CreditCard
                            {
                                CreditType = CreditTypes.Visa,
                                Principal = 100M
                            }
                        }
                    }
                }
            };

            var person2 = new Person
            {
                Interest = 0m,
                Wallets = new List<Wallet>
                {
                    new Wallet
                    {
                        CreditCards = new List<CreditCard>
                        {
                            new CreditCard
                            {
                                CreditType = CreditTypes.Visa,
                                Principal = 100M
                            },
                            new CreditCard
                            {
                                CreditType = CreditTypes.Mastercard,
                                Principal = 100M
                            }
                        }
                    }
                }
            };
            var interestRateGetter = new CreditCardInterestRateGetter();
            var ccic = new CreditCardInterestCalculator(interestRateGetter);
            var wic = new WalletInterestCalculator(ccic);
            var pic = new PersonInterestCalculator(wic);

            pic.CalculateInterest(person);
            pic.CalculateInterest(person2);

            var expectedVisaInterest = 100 * .1M;
            var expectedMCInterest = 100 * .05M;

            var expectedPersonInterest = expectedVisaInterest + expectedMCInterest;

            Assert.Equal(expectedPersonInterest, person.Interest);
            Assert.Equal(expectedPersonInterest, person2.Interest);

            var expectedWallet1Interest = expectedPersonInterest;
            var actualWallet1 = person.Wallets.First();
            Assert.Equal(expectedWallet1Interest, actualWallet1.Interest);

            var expectedWallet2Interest = expectedPersonInterest;
            var actualWallet2 = person2.Wallets.First();
            Assert.Equal(expectedWallet2Interest, actualWallet2.Interest);
        }
    }
}
