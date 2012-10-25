using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using csalgs.math;
namespace csalgs_tests
{
	/// <summary>
	/// Сводное описание для MatrixTest
	/// </summary>
	[TestClass]
	public class MatrixTest
	{
		public MatrixTest()
		{
			//
			// TODO: добавьте здесь логику конструктора
			//
		}

		private TestContext testContextInstance;

		/// <summary>
		///Получает или устанавливает контекст теста, в котором предоставляются
		///сведения о текущем тестовом запуске и обеспечивается его функциональность.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}


		[TestMethod]
		public void MatrixDataAccessTest()
		{
			double[,] raw = new double[3, 2];

			raw[0, 0] = 1;
			raw[0, 1] = 2;

			raw[1, 0] = 3;
			raw[1, 1] = 4;

			raw[2, 0] = 5;
			raw[2, 1] = 6;


			Matrix matrix1 = new Matrix(3, 2);

			matrix1[0, 0] = 1;
			matrix1[0, 1] = 2;

			matrix1[1, 0] = 3;
			matrix1[1, 1] = 4;

			matrix1[2, 0] = 5;
			matrix1[2, 1] = 6;

			for (int i = 0; i < 3; i++) {
				for (int j = 0; j < 2; j++) {
					if(matrix1[i, j] != raw[i, j]){
						Assert.Fail("Fail access", i, j);
					}
				}
			}
		}

		[TestMethod]
		public void MatrixPlusTest() {
			IRDL rdl = new UniformRDL();

			Matrix m1 = Matrix.GetRandomMatrix(3, rdl);
			Matrix m2 = Matrix.GetRandomMatrix(3, rdl);

			Matrix rm = m1 - m2;

			for (int i = 0; i < rm.RowsCount; i++) {
				for (int j = 0; j < rm.ColumnsCount; j++) {
					if (rm[i, j] != m1[i, j] - m2[i, j]) Assert.Fail("Fail ", i, j);
				}
			}
		}

		[TestMethod]
		public void MatrixTransposeTest() {
			IRDL rdl = new UniformRDL();
			Matrix matrix = Matrix.GetRandomMatrix(2, 3, rdl);

			Matrix tr = ~matrix;
			Matrix tr2 = ~tr;

			Assert.AreEqual(true, tr2.IsEqual(matrix));
		}

		[TestMethod]
		public void MatrixInverseTest() {
			IRDL rdl = new UniformRDL();
			Matrix matrix = Matrix.GetRandomMatrix(3, 3, rdl);

			Matrix inversed = !matrix;
			//RealMatrix inversed2 = !inversed;
			Matrix identity = inversed * matrix;

			for (int i = 0; i < identity.RowsCount; i++)
			{
				Console.WriteLine();
				for (int j = 0; j < identity.ColumnsCount; j++)
				{

					Console.Write(identity[i, j] + " ");

				}
			}

			Assert.AreEqual(true, identity.IsIdentityMatrix());

		}


	}
}
