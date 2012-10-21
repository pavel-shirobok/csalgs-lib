using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using csalgs.sorting;
namespace csalgs_tests
{
    [TestClass]
    public class SortingTest
    {
        [TestMethod]
        public void InitBubbleSortingTest()
        {
            ISortMethod<Double> sort = new BubbleSort<Double>();
        }

        [TestMethod]
        public void TestFullBubbleSortingDouble() {
            ISortMethod<Double> sort = new BubbleSort<Double>();
            Double[] selection = SortHelper.GenerateDoubleSelection(1000);

            testMethod<Double>(sort, selection, Comparisons.DOUBLE_ASC);
            testMethod<Double>(sort, selection, Comparisons.DOUBLE_DESC);
        }

        private void testMethod<T>(ISortMethod<T> method, T[] selection, Comparison<T> comp) {
            method.Setup(selection);
            method.SetupComparable(comp);
            method.Sort();
            Assert.AreEqual(true, SortHelper.TestSorting<T>(selection, comp));
        }

        [TestMethod]
        public void TestFullQuickSortingDouble() {
            ISortMethod<double> sort = new QuickSort<Double>();

            Double[] selection = SortHelper.GenerateDoubleSelection(1000);

            testMethod<Double>(sort, selection, Comparisons.DOUBLE_ASC);
            testMethod<Double>(sort, selection, Comparisons.DOUBLE_DESC);
        }

    }
}
