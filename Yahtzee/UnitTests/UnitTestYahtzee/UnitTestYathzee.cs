using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Yahtzee;

namespace UnitTestYahtzee
{
    [TestClass]
    public class UnitTestYathzee
    {
        [TestMethod]
        public void TestMethodDiceOfAKindLowerSectionCalculatorTwoOfAkind()
        {
            //-- Arrange
            int[] array = { 6,6,2,2,3};
            int twoOfAKind = 2;
            int expected = 12;

            //-- Act
            var actaul = Program.DiceOfAKindLowerSectionCalculator(array, twoOfAKind);

            //-- Assert
            Assert.AreEqual(expected, actaul);
        }
        [TestMethod]
        public void TestMethodDiceOfAKindLowerSectionCalculatorThreeOfAkind()
        {
            //-- Arrange
            int[] array = { 6, 2, 2, 2, 3 };
            int threeOfAKind = 3;
            int expected = 6;

            //-- Act
            var actaul = Program.DiceOfAKindLowerSectionCalculator(array, threeOfAKind);

            //-- Assert
            Assert.AreEqual(expected, actaul);
        }

        [TestMethod]
        public void TestMethodDiceOfAKindLowerSectionCalculatorFourOfAkind()
        {
            //-- Arrange
            int[] array = { 6, 3, 3, 3, 3 };
            int fourOfAKind = 4;
            int expected = 12;

            //-- Act
            var actaul = Program.DiceOfAKindLowerSectionCalculator(array, fourOfAKind);

            //-- Assert
            Assert.AreEqual(expected, actaul);
        }

        [TestMethod]
        public void TestMethodDiceOfAKindLowerSectionCalculatorFiveOfAkind()
        {
            //-- Arrange
            int[] array = { 2, 2, 2, 2, 2 };
            int fiveOfAKind = 5;
            int expected = 10;

            //-- Act
            var actaul = Program.DiceOfAKindLowerSectionCalculator(array, fiveOfAKind);

            //-- Assert
            Assert.AreEqual(expected, actaul);
        }
    }
}
