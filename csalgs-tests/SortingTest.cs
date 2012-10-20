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
        public void TestFullSortingDouble() {
            ISortMethod<Double> sort = new BubbleSort<Double>();
            Double[] selection = Helpers.GenerateDoubleSelection(10);

            sort.Setup(selection);
            sort.SetupComparable(Comparisons.DOUBLE_ASC);

            sort.Sort();

        }
    }
}
