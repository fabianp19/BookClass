using System;
using NUnit.Framework;
using VerificationService;

namespace BookClass.Tests
{
    [TestFixture]
    public class IsbnVerifierTests
    {
        [TestCase("3-598-21508-8")]
        [TestCase("3-598-21507-X")]
        [TestCase("3598215088")]
        [TestCase("359821507X")]
        [TestCase("3-598-215088")]
        [TestCase("039304002X")]
        [TestCase("978-0-901-69066-1")]
        [TestCase("9780901690661")]
        public void IsValid_IsbnIsValid(string number)
        {
            Assert.IsTrue(IsbnVerifier.IsValid(number));
        }

        [TestCase("----3-5--98-21508-8")]
        [TestCase("3-5-98-21507-X")]
        [TestCase("35A98-2150----88")]
        [TestCase("3-5982yb1507-X")]
        [TestCase("35982yb1507gX")]
        [TestCase("---359821507X")]
        [TestCase("359821507---X")]
        [TestCase("359821507--FX")]
        [TestCase("359821507--XX")]
        [TestCase("359X821507--X")]
        public void IsValid_InvalidSymbols_IsbnIsNotValid(string number)
        {
            Assert.IsFalse(IsbnVerifier.IsValid(number));
        }

        [TestCase("3-598-21508-9")]
        [TestCase("3-598-21507-A")]
        [TestCase("3-598-P1581-X")]
        [TestCase("3-598-2X507-9")]
        [TestCase("359821507")]
        [TestCase("3598215078X")]
        [TestCase("00")]
        [TestCase("3-598-21507")]
        [TestCase("3-598-21515-X")]
        [TestCase("134456729")]
        [TestCase("3132P34035")]
        [TestCase("98245726788")]
        [TestCase("")]
        [TestCase("    ")]
        public void IsValid_IsbnIsNotValid(string number)
        {
            Assert.IsFalse(IsbnVerifier.IsValid(number));
        }

        [TestCase(null)]
        public void IsValid_StringIsNull_ThrowsArgumentNullException(string number)
        {
            Assert.Throws<ArgumentNullException>(() => IsbnVerifier.IsValid(number), "Source string cannot be null or empty or whitespace.");
        }
    }
}
