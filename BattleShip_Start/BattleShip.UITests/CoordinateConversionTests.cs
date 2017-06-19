using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleShip.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI.Tests
{
    [TestClass()]
    public class CoordinateConversionTests
    {
        [TestMethod()]
        public void translateNumberToLetterTest()
        {
            //Create CoordinateConversion object:
            CoordinateConversion coordinateConversion = new CoordinateConversion();

            //Call translation function on coordinateConversion object:
            char actual = coordinateConversion.translateNumberToLetter(1);
            Assert.AreEqual('A', actual);
            actual = coordinateConversion.translateNumberToLetter(2);
            Assert.AreEqual('B', actual);

            //char actual = coordinateConversion.translateNumberToLetter(72);
            //Assert.AreEqual('H', actual);
            //Assert.Fail();
        }

        [TestMethod()]
        public void translateLetterToNumberTest()
        {
            CoordinateConversion coordinateConversion = new CoordinateConversion();

            int actual = coordinateConversion.translateLetterToNumber('A');
            Assert.AreEqual(1, actual);
        }
    }
}