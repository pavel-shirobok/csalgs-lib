﻿using System;
using System.Collections.Generic;
using System.Text;

namespace csalgs.math
{
    public partial class Matrix
    {

        /// <summary>
        /// Append matrix
        /// </summary>
        /// <param name="mtx"></param>
        /// <returns></returns>
        public Matrix Append(Matrix mtx)
        {
            AssertNonNull(mtx);
            AssertMatrixSizeEqual(mtx);

            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    this[i, j] += mtx[i, j];
                }
            }

            return this;
        }

        /// <summary>
        /// Subtract matrix
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public Matrix Subtract(Matrix m)
        {
            AssertMatrixSizeEqual(m);

            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    this[i, j] -= m[i, j];
                }
            }

            return this;
        }

        /// <summary>
        /// Multiply by number
        /// </summary>
        /// <param name="number"></param>
        /// <returns>current matrix multiplied by number</returns>
        public Matrix Multiply(double number)
        {
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    this[i, j] *= number;
                }
            }

            return this;
        }

        /// <summary>
        /// Multiply by matrix
        /// </summary>
        /// <param name="m2"></param>
        /// <returns>new matrix equals this*m2</returns>
        public Matrix Multiply(Matrix m2)
        {
            if (this.ColumnsCount != m2.RowsCount) throw new ArgumentException("Invalid matrix size for multiply");

            Matrix result = Matrix.GetMatrix(RowsCount, m2.ColumnsCount);

            double temp;
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < m2.ColumnsCount; j++)
                {
                    temp = 0;

                    for (int k = 0; k < this.ColumnsCount; k++)
                    {
                        temp += this[i, k] * m2[k, j];
                    }

                    result[i, j] = temp;
                }
            }

            return result;
        }

        /// <summary>
        /// Divide by number
        /// </summary>
        /// <param name="number"></param>
        /// <returns>current matrix divided by number</returns>
        public Matrix Divide(double number)
        {
            this.Multiply(1 / number);
            return this;
        }

        /// <summary>
        /// Return double[] array of column elements
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public double[] GetColumnArray(int index)
        {
            double[] result = new double[rowsCount];
            for (int i = 0; i < rowsCount; i++)
            {
                result[i] = this[i, index];
            }

            return result;
        }

        /// <summary>
        /// Return double[] array of row elements
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public double[] GetRowArray(int index)
        {
            double[] result = new double[columnsCount];

            for (int i = 0; i < columnsCount; i++)
            {
                result[i] = this[index, i];
            }

            return result;
        }


        /// <summary>
        /// Change row's position
        /// </summary>
        /// <param name="index">row's index </param>
        /// <param name="target">index of target position</param>
        public void ChangeRowsPosition(int index, int target)
        {
            if (index < 0 || index > RowsCount - 1 || target < 0 || target > RowsCount - 1) throw new ArgumentOutOfRangeException("indexes in out of range");
            if (index == target) return;

            double temp = 0;

            for (int j = 0, len = ColumnsCount; j < len; j++)
            {
                temp = this[index, j];
                this[index, j] = this[index, target];
                this[index, target] = temp;
            }
        }

        /// <summary>
        /// Change column's position
        /// </summary>
        /// <param name="index">column's index </param>
        /// <param name="target">index of target position</param>
        public void ChangeColumnsPosition(int index, int target)
        {
            if (index < 0 || index > ColumnsCount - 1 || target < 0 || target > ColumnsCount - 1) throw new ArgumentOutOfRangeException("indexes in out of range");
            if (index == target) return;
            double temp = 0;

            for (int j = 0, len = RowsCount; j < len; j++)
            {
                temp = this[j, index];
                this[j, index] = this[target, index];
                this[target, index] = temp;
            }
        }
    }
}
