using System;
using System.Collections.Generic;
using System.Text;

namespace csalgs.math
{
    public partial class Matrix
    {
        /// <summary>
        /// Raw 2D matrix
        /// </summary>
        private double[,] rawData;

        /// <summary>
        /// Rows count
        /// </summary>
        private int rowsCount;

        /// <summary>
        /// Columns count
        /// </summary>
        private int columnsCount;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="rowCount">Rows count</param>
        /// <param name="columnCount">Colums count</param>
        public Matrix(int rowCount, int columnCount){
            AssertInitSizeCount(rowCount, columnCount);

            initStartMatrix(rowCount, columnCount);
        }

        /// <summary>
        /// Initing raw 2D array
        /// </summary>
        /// <param name="rowCount">Rows count</param>
        /// <param name="columnCount">Columns count</param>
        private void initStartMatrix(int rowCount, int columnCount)
        {
            this.rowsCount = rowCount;
            this.columnsCount = columnCount;

            rawData = new double[rowCount, columnCount];

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    rawData[i, j] = 0;
                }
            }
        }

        /// <summary>
        /// Data access indexator
        /// </summary>
        /// <param name="row">row's index</param>
        /// <param name="column">column's index</param>
        /// <returns>value on <paramref name="row"/>,<paramref name="column"/></returns>
        public double this[int row, int column]
        {

            get
            {
                return rawData[row, column];
            }

            set
            {
                rawData[row, column] = value;
            }
        }

        /// <summary>
        /// Rows count (read-only)
        /// </summary>
        public int RowsCount {
            get {
                return this.rowsCount;
            }
        }

        /// <summary>
        /// Columns count (read-only)
        /// </summary>
        public int ColumnsCount {
            get {
                return this.columnsCount;
            }
        }

        /// <summary>
        /// Clone current matrix
        /// </summary>
        /// <returns>clone</returns>
        public Matrix Clone()
        {
            Matrix clone = Matrix.GetMatrix(rowsCount, columnsCount);

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    clone[i, j] = this[i, j];
                }
            }

            return clone;
        }
    }
}
