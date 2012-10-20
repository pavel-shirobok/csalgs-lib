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
            Double[] selection = SortHelper.GenerateDoubleSelection(10);
            Assert.AreEqual(10, selection.Length);
        }

        [TestMethod]
        public void TestGeneratingWithNegativeAndZeroCount() {
            Exception ex = null;
            
            try{
                SortHelper.GenerateDoubleSelection(0);
            }catch(Exception e){
                ex = e;
            }

            Assert.AreEqual(ex is ArgumentException, true);

            try
            {
                SortHelper.GenerateDoubleSelection(-1);
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
            Assert.AreEqual(true, SortHelper.TestSorting<Double>(result, Comparisons.DOUBLE_ASC));
            Assert.AreEqual(false, SortHelper.TestSorting<Double>(result, Comparisons.DOUBLE_DESC));

            Double[] result2 = {0.0, 0, 1.0, 10.0, -10.0};
            Assert.AreEqual(false, SortHelper.TestSorting<Double>(result2, Comparisons.DOUBLE_ASC));
            Assert.AreEqual(false, SortHelper.TestSorting<Double>(result2, Comparisons.DOUBLE_DESC));

            Double[] result3 = { 10, 9, 8, 6, 0 };
            Assert.AreEqual(false, SortHelper.TestSorting<Double>(result3, Comparisons.DOUBLE_ASC));
            Assert.AreEqual(true, SortHelper.TestSorting<Double>(result3, Comparisons.DOUBLE_DESC));
        }
    }
}
