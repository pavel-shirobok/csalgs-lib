// ReSharper disable CheckNamespace
namespace csalgs.math
// ReSharper restore CheckNamespace
{
    public partial class Matrix
    {
        /// <summary>
        /// Check equal of current matrix and <paramref name="m"/>
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public bool IsEqual(Matrix m)
        {
            AssertNonNull(m);

            if (!IsSizeEqual(m)) return false;

            for (int i = 0; i < m.RowsCount; i++)
            {
                for (int j = 0; j < m.ColumnsCount; j++)
                {
                    if (this[i, j] != m[i, j]) return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Check current matrix for identity
        /// </summary>
        /// <returns>true if current matrix is identity</returns>
        public bool IsIdentityMatrix()
        {
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {

                    if (i == j)
                    {
                        if (this[i, j] != 1) return false;
                    }
                    else
                    {
                        if (this[i, j] != 0) return false;
                    }

                }
            }
            return true;
        }

        /// <summary>
        /// Check for size equals between this and <paramref name="matrix"/>
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public bool IsSizeEqual(Matrix matrix)
        {
            return matrix.RowsCount == RowsCount && matrix.ColumnsCount == ColumnsCount;
        }
    }
}
