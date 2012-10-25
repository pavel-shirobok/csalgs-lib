using System;
using System.Collections.Generic;
using System.Text;

namespace csalgs.math
{
    public partial class Matrix
    {
        /// <summary>
        /// Appends two matrix
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns>new matrix equals summ of m1 and m2</returns>
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (!m1.IsSizeEqual(m2)) throw new ArgumentException("Matrix's size not equal!");
            return m1.Clone().Append(m2);
        }

        /// <summary>
        /// Subtract two matrix
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns>new matrix equals subtract between m1 and m2</returns>
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            if (!m1.IsSizeEqual(m2)) throw new ArgumentException("Matrix's size not equal!");
            return m1.Clone().Subtract(m2);
        }

        /// <summary>
        /// Multiply two matrix
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns>new matrix equals multiply m1 and m2</returns>
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            return m1.Multiply(m2);
        }

        /// <summary>
        /// Multiply matrix and number
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns>new matrix equals myltiply m1 and m2</returns>
        public static Matrix operator *(Matrix m1, Double m2)
        {
            return m1.Clone().Multiply(m2);
        }

        /// <summary>
        /// Divide matrix and number
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns>new matrix equals divide m1 and m2</returns>
        public static Matrix operator /(Matrix m1, Double m2)
        {
            return m1.Divide(m2);
        }

        /// <summary>
        /// Get inverse matrix
        /// </summary>
        /// <param name="m1"></param>
        /// <returns>new inverse matrix</returns>
        public static Matrix operator !(Matrix m1)
        {
            return m1.GetInverse();
        }

        /// <summary>
        /// Get transpose matrix
        /// </summary>
        /// <param name="m1"></param>
        /// <returns></returns>
        public static Matrix operator ~(Matrix m1)
        {
            return m1.Transpose();
        }
    }
}
