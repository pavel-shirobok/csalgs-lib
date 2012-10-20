using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using csalgs.sorting;
namespace csalgs_tests
{
    [TestClass]
    public class HelpersTest
    {
        [TestMethod]
        public void TestDoubleGenerating()
        {
            Double[] selection = Helpers.GenerateDoubleSelection(10);
            Assert.AreEqual(10, selection.Length);
        }

        [TestMethod]
        public void TestGeneratingWithNegativeAndZeroCount() {
            Exception ex = null;
            
            try{
                Helpers.GenerateDoubleSelection(0);
            }catch(Exception e){
                ex = e;
            }

            Assert.AreEqual(ex is ArgumentException, true);

            try
            {
                Helpers.GenerateDoubleSelection(-1);
            }
            catch (Exception e)
            {
                ex = e;
            }

            Assert.AreEqual(ex is ArgumentException, true);

        }

        [TestMethod]
        public void TestResultSorting() {
            Double[] result = {1.0, 2.0, 3.0, 4.0, 5.0}; 
            Comparison<Double> comp = Comparisons.DOUBLE_ASC;

            
            
        }
    }
}
