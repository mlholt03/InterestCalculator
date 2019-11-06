using System;
using System.Collections.Generic;
using System.Text;
using InterestCalculator.Src.Interfaces;
namespace InterestCalculator.Src.Models
{
    public abstract class InterestBearing : IInterestBearing
    {
        public decimal Interest { get; set; }
    }
}
