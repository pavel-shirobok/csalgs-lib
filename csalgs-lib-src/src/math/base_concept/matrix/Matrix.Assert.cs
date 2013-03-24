using System;

// ReSharper disable CheckNamespace
namespace csalgs.math
// ReSharper restore CheckNamespace
{
    public partial class Matrix
    {
        private void AssertMatrixSizeEqual(Matrix matrix) {
            if (!IsSizeEqual(matrix))
            {
                throw new ArgumentException(
                    String.Format(
                        "matrix not size-equal current[{0}{1}], received[{2}{3}]",
                            RowsCount, ColumnsCount, matrix.RowsCount, matrix.ColumnsCount
                            )
                );
            }
        }

        private static void AssertInitSizeCount(int rowCount, int columnCount) {
            if (rowCount <= 0) {
                throw new ArgumentException("Row count must be more than zero");
            }

            if (columnCount <= 0) {
                throw new ArgumentException("Column count must be more than zero");
            }
        }
		
		private void AssertNonNull(Matrix matrix){
			AssertNonNull(matrix, "Matrix must be non-null");
		}

		private void AssertNonNull(Matrix matrix, String assertText){
			if(matrix == null){
				throw new ArgumentException(assertText);
			}
		}

    }
}
