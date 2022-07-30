using System;
using NUnit.Framework;
using VerificationService;

namespace BookClass.Tests
{
    [TestFixture]
    public class IsoCurrencyTests
    {
        [TestCase(null)]
        public void IsValid_StringIsNull_ThrowsArgumentNullException(string currency)
        {
            Assert.Throws<ArgumentNullException>(() => IsoCurrencyValidator.IsValid(currency), "currency string cannot be null or empty or whitespace.");
        }

        [TestCase("USD")]
        [TestCase("BZD")]
        [TestCase("EUR")]
        [TestCase("BYR")]
        [TestCase("KRW")]
        public void IsValid_IsoIsValid(string number)
        {
            Assert.IsTrue(IsoCurrencyValidator.IsValid(number));
        }

        [TestCase("us")]
        [TestCase("ABC")]
        [TestCase("123")]
        [TestCase("YML")]
        [TestCase("BY")]
        [TestCase("Gh")]
        [TestCase("")]
        [TestCase("    ")]
        public void IsValid_IsoIsNotValid(string number)
        {
            Assert.IsFalse(IsoCurrencyValidator.IsValid(number));
        }
    }
}
