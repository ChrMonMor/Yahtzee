using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Yahtzee;

namespace UnitTestYahtzee
{
    [TestClass]
    public class UnitTestYathzee
    {
        [TestMethod]
        public void TestMethodDiceOfKindsLowerSectionCalculatorTwoOfAkind()
        {
            //-- Arrange
            int[] array = { 6,6,2,2,3};
            int twoOfAKind = 2;
            int pairs = 1;
            int expected = 12;

            //-- Act
            var actaul = Program.DiceOfKindsLowerSectionCalculator(array, twoOfAKind, pairs, false);

            //-- Assert
            Assert.AreEqual(expected, actaul);
        }
        [TestMethod]
        public void TestMethodDiceOfKindsLowerSectionCalculatorThreeOfAkind()
        {
            //-- Arrange
            int[] array = { 6, 2, 2, 2, 3 };
            int threeOfAKind = 3;
            int pairs = 1;
            int expected = 6;

            //-- Act
            var actaul = Program.DiceOfKindsLowerSectionCalculator(array, threeOfAKind, pairs, false);

            //-- Assert
            Assert.AreEqual(expected, actaul);
        }

        [TestMethod]
        public void TestMethodDiceOfKindsLowerSectionCalculatorFourOfAkind()
        {
            //-- Arrange
            int[] array = { 6, 3, 3, 3, 3 };
            int fourOfAKind = 4;
            int pairs = 1;
            int expected = 12;

            //-- Act
            var actaul = Program.DiceOfKindsLowerSectionCalculator(array, fourOfAKind, pairs, false);

            //-- Assert
            Assert.AreEqual(expected, actaul);
        }

        [TestMethod]
        public void TestMethodDiceOfKindsLowerSectionCalculatorFiveOfAkind()
        {
            //-- Arrange
            int[] array = { 2, 2, 2, 2, 2 };
            int fiveOfAKind = 5;
            int pairs = 1;
            int expected = 10;

            //-- Act
            var actaul = Program.DiceOfKindsLowerSectionCalculator(array, fiveOfAKind, pairs, false);

            //-- Assert
            Assert.AreEqual(expected, actaul);
        }
        [TestMethod]
        public void TestMethodDiceOfKindsLowerSectionCalculatorTwoOfAkindAndTwoPairs()
        {
            //-- Arrange
            int[] array = { 6, 6, 2, 2, 3 };
            int twoOfAKind = 2;
            int pairs = 2;
            int expected = 16;

            //-- Act
            var actaul = Program.DiceOfKindsLowerSectionCalculator(array, twoOfAKind, pairs, false);

            //-- Assert
            Assert.AreEqual(expected, actaul);
        }

        [TestMethod]
        public void TestMethodDiceOfKindsLowerSectionCalculatorTwoOfAkindAndTwoPairsButThereisYathzee()
        {
            //-- Arrange
            int[] array = { 6, 6, 6, 6, 6 };
            int twoOfAKind = 2;
            int pairs = 2;
            int expected = 0;

            //-- Act
            var actaul = Program.DiceOfKindsLowerSectionCalculator(array, twoOfAKind, pairs, false);

            //-- Assert
            Assert.AreEqual(expected, actaul);
        }
        [TestMethod]
        public void TestMethodDiceOfKindsLowerSectionCalculatorThreeOfAkindFalse()
        {
            //-- Arrange
            int[] array = { 6, 6, 2, 2, 3 };
            int twoOfAKind = 3;
            int pairs = 1;
            int expected = 0;

            //-- Act
            var actaul = Program.DiceOfKindsLowerSectionCalculator(array, twoOfAKind, pairs, false);

            //-- Assert
            Assert.AreEqual(expected, actaul);
        }
        [TestMethod]
        public void TestMethodDiceOfKindsLowerSectionCalculatorTwoOfAkindFalse()
        {
            //-- Arrange
            int[] array = { 6, 1, 2, 4, 3 };
            int twoOfAKind = 2;
            int pairs = 1;
            int expected = 0;

            //-- Act
            var actaul = Program.DiceOfKindsLowerSectionCalculator(array, twoOfAKind, pairs, false);

            //-- Assert
            Assert.AreEqual(expected, actaul);
        }
        [TestMethod]
        public void TestMethodDiceOfKindsLowerSectionCalculatorFourOfAkindFalse()
        {
            //-- Arrange
            int[] array = { 6, 3, 5, 3, 3 };
            int fourOfAKind = 4;
            int pairs = 1;
            int expected = 0;

            //-- Act
            var actaul = Program.DiceOfKindsLowerSectionCalculator(array, fourOfAKind, pairs, false);

            //-- Assert
            Assert.AreEqual(expected, actaul);
        }

        [TestMethod]
        public void TestMethodDiceOfKindsLowerSectionCalculatorFiveOfAkindFalse()
        {
            //-- Arrange
            int[] array = { 2, 1, 2, 2, 2 };
            int fiveOfAKind = 5;
            int pairs = 1;
            int expected = 0;

            //-- Act
            var actaul = Program.DiceOfKindsLowerSectionCalculator(array, fiveOfAKind, pairs, false);

            //-- Assert
            Assert.AreEqual(expected, actaul);
        }
        [TestMethod]
        public void TestMethodDiceOfKindsLowerSectionCalculatorTwoOfAkindAndTwoPairsFalse()
        {
            //-- Arrange
            int[] array = { 6, 4, 2, 2, 3 };
            int twoOfAKind = 2;
            int pairs = 2;
            int expected = 0;

            //-- Act
            var actaul = Program.DiceOfKindsLowerSectionCalculator(array, twoOfAKind, pairs, false);

            //-- Assert
            Assert.AreEqual(expected, actaul);
        }


        [TestMethod]
        public void TestMethodDiceOfKindsLowerSectionCalculatorFullHouse()
        {
            //-- Arrange
            int[] array = { 4, 4, 2, 2, 4 };
            int top = 3;
            int maxjumps = 2;
            int expected = 16;

            //-- Act
            var actaul = Program.DiceOfKindsLowerSectionCalculator(array, top, maxjumps, true);

            //-- Assert
            Assert.AreEqual(expected, actaul);
        }
        [TestMethod]
        public void TestMethodPyramidDiceLowerSectionCalculatorFullHouseFalseYathzee()
        {
            //-- Arrange
            int[] array = { 1, 1, 1, 1, 1 };
            int top = 3;
            int maxjumps = 2;
            int expected = 0;

            //-- Act
            var actaul = Program.DiceOfKindsLowerSectionCalculator(array, top, maxjumps, true);

            //-- Assert
            Assert.AreEqual(expected, actaul);
        }
        [TestMethod]
        public void TestMethodPyramidDiceLowerSectionCalculatorFullHouseFalseNonSimilar()
        {
            //-- Arrange
            int[] array = { 1, 2, 3, 4, 5 };
            int top = 3;
            int maxjumps = 2;
            int expected = 0;

            //-- Act
            var actaul = Program.DiceOfKindsLowerSectionCalculator(array, top, maxjumps, true);

            //-- Assert
            Assert.AreEqual(expected, actaul);
        }
        [TestMethod]
        public void TestMethodDiceInARowLowerSectionCalculatorSmall()
        {
            //-- Arrange
            int[] array = { 1, 2, 3, 4, 5 };
            int smallest = 1;
            int biggest = 5;
            int expected = 15;

            //-- Act
            var actaul = Program.DiceInARowLowerSectionCalculator(array, smallest, biggest);

            //-- Assert
            Assert.AreEqual(expected, actaul);
        }
        [TestMethod]
        public void TestMethodDiceInARowLowerSectionCalculatorSmallFalse()
        {
            //-- Arrange
            int[] array = { 1, 2, 3, 4, 6 };
            int smallest = 1;
            int maxjumps = 5;
            int expected = 0;

            //-- Act
            var actaul = Program.DiceInARowLowerSectionCalculator(array, smallest, maxjumps);

            //-- Assert
            Assert.AreEqual(expected, actaul);
        }
        [TestMethod]
        public void TestMethodDiceInARowLowerSectionCalculatorRoyal()
        {
            //-- Arrange
            int[] array = { 1, 2, 3, 4, 5, 6};
            int smallest = 1;
            int biggest = 6;
            int expected = 30;

            //-- Act
            var actaul = Program.DiceInARowLowerSectionCalculator(array, smallest, biggest);

            //-- Assert
            Assert.AreEqual(expected, actaul);
        }
    }
}
