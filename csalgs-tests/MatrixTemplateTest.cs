using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using csalgs.math;
namespace csalgs_tests
{
    [TestClass]
    public class MatrixTemplateTest
    {
        [TestMethod]
        public void CreatingMatrix()
        {
            new Matrix(10, 10);
        }

        [TestMethod]
        public void TestIndexator() {
            Matrix m = new Matrix(2, 2);

            m[0, 0] = 1;
            m[0, 1] = 2;
            m[1, 0] = 3;
            m[1, 1] = 4;

            Assert.AreEqual(1, m[0, 0]);
            Assert.AreEqual(2, m[0, 1]);
            Assert.AreEqual(3, m[1, 0]);
            Assert.AreEqual(4, m[1, 1]);
        }

        [TestMethod]
        public void TestNegativeMatrixSize() {
            try
            {
                Matrix m = new Matrix(-1, -1);
            }
            catch (Exception e) {
                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void TestMultyplyByScalar() {
            Matrix m;
        }

        [TestMethod]
        public void TestMultyplyByMatrix() { }

        [TestMethod]
        public void TestSubstractByScalar() { }

        [TestMethod]
        public void TestSubstractByMatrix() { }
    }
}
