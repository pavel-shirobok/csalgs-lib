// ReSharper disable CheckNamespace
namespace csalgs.math
// ReSharper restore CheckNamespace
{
    public partial class Matrix
    {
        /// <summary>
        /// Raw 2D matrix
        /// </summary>
        private double[,] _rawData;

	    /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="rowCount">Rows count</param>
        /// <param name="columnCount">Colums count</param>
        public Matrix(int rowCount, int columnCount){
            AssertInitSizeCount(rowCount, columnCount);

            InitStartMatrix(rowCount, columnCount);
        }

        /// <summary>
        /// Initing raw 2D array
        /// </summary>
        /// <param name="rowCount">Rows count</param>
        /// <param name="columnCount">Columns count</param>
        private void InitStartMatrix(int rowCount, int columnCount)
        {
            RowsCount = rowCount;
            ColumnsCount = columnCount;

            _rawData = new double[rowCount, columnCount];

            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < columnCount; j++)
                {
                    _rawData[i, j] = 0;
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
                return _rawData[row, column];
            }

            set
            {
                _rawData[row, column] = value;
            }
        }

	    /// <summary>
	    /// Rows count (read-only)
	    /// </summary>
	    public int RowsCount { get; private set; }

	    /// <summary>
	    /// Columns count (read-only)
	    /// </summary>
	    public int ColumnsCount { get; private set; }

	    /// <summary>
        /// Clone current matrix
        /// </summary>
        /// <returns>clone</returns>
        public Matrix Clone()
        {
            Matrix clone = GetMatrix(RowsCount, ColumnsCount);

            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    clone[i, j] = this[i, j];
                }
            }

            return clone;
        }
    }
}
