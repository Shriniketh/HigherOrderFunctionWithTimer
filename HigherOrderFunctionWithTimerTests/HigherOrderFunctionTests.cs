using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HigherOrderFunctionwithTimer;

namespace HigherOrderFunctionWithTimerTests
{
    [TestClass]
    public class HigherOrderFunctionTests
    {
        [TestMethod]
        public void CheckIfPrimeNumber_Returns_Three_PrimeNumbers_Successfully()
        {
            Program.CheckIfPrimeNumber();
        }
    }
}
