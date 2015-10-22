using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1.Polinomial.Test
{
    [TestClass]
    public class PolinomialTest
    {
        [TestMethod]
        public void Sum_123and55_return178()
        {
            Polinomial p1 = new Polinomial(1,2,3);
            Polinomial p2 = new Polinomial(5,5);
            Polinomial expectedP = new Polinomial(1,7,8);

            Polinomial result = p1 + p2;

            Assert.AreEqual(expectedP , result);   
        }

        [TestMethod]
        public void Sub_55and123_returnM132()
        {
            Polinomial p1 = new Polinomial(1, 2, 3);
            Polinomial p2 = new Polinomial(5, 5);
            Polinomial expectedP = new Polinomial(-1, 3, 2);

            Polinomial result = p2 - p1;

            Assert.AreEqual(expectedP, result);
        }

        [TestMethod]
        public void Sum_123and45_return178()
        {
            Polinomial p1 = new Polinomial(1, 2, 3);
            Polinomial p2 = new Polinomial(4, 5);
            Polinomial expectedP = new Polinomial(4, 13, 22, 15, 0 ,0 );

            Polinomial result = p1 * p2;

            Assert.AreEqual(expectedP, result);
        }

        [TestMethod]
        public void Equals_123and321_returnFalse()
        {
            Polinomial p1 = new Polinomial(1, 2, 3);
            Polinomial p2 = new Polinomial(3, 2, 1);
            bool expectedResult = false;

            bool result = Polinomial.Equals(p1, p2);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Equals_123and123_returnTrue()
        {
            Polinomial p1 = new Polinomial(1, 2, 3);
            Polinomial p2 = new Polinomial(1, 2, 3);
            bool expectedResult = true;

            bool result = Polinomial.Equals(p1, p2);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Equals_123_returnTrue()
        {
            Polinomial p1 = new Polinomial(1, 2, 3);
            Polinomial p2 = p1;
            bool expectedResult = true;

            bool result = Polinomial.Equals(p1, p2);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
