using System;
using System.Collections.Generic;
using System.Text;

namespace csalgs.math
{
    public partial class Matrix
    {
        /// <summary>
        /// Create matrix rowCount*columnCount
        /// </summary>
        /// <param name="rowCount">count of rows</param>
        /// <param name="columnCount">count of columns</param>
        /// <returns>instance of new matrix</returns>
        public static Matrix GetMatrix(int rowCount, int columnCount)
        {
            return new Matrix(rowCount, columnCount);
        }

        /// <summary>
        /// Create new square matrix
        /// </summary>
        /// <param name="size">size of new square matrix</param>
        /// <returns></returns>
        public static Matrix GetQuadroMatrix(int size)
        {
            return new Matrix(size, size);
        }

        /// <summary>
        /// Generate square matrix with random values
        /// </summary>
        /// <param name="sizeOfQuadroMatrix">size</param>
        /// <param name="rdl"><see cref="csalgs.math.IRDL"/> using for generation</param>
        /// <returns><see cref="csalgs.math.Matrix"/></returns>
        public static Matrix GetRandomMatrix(int sizeOfQuadroMatrix, IRDL rdl)
        {
            return GetRandomMatrix(sizeOfQuadroMatrix, sizeOfQuadroMatrix, rdl);
        }

        /// <summary>
        /// Generate matrix with random values
        /// </summary>
        /// <param name="rowsCount">count of rows</param>
        /// <param name="columnsCount">count of columns</param>
        /// <param name="rdl"><see cref="csalgs.math.IRDL"/> using for generation</param>
        /// <returns><see cref="csalgs.math.Matrix"/></returns>
        public static Matrix GetRandomMatrix(int rowsCount, int columnsCount, IRDL rdl)
        {
            Matrix result = new Matrix(rowsCount, columnsCount);

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    result[i, j] = rdl.Get();
                }
            }

            return result;
        }
    }
}
