using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Polinomial
{
    public class Polinomial : IEquatable<Polinomial>
    {
        /// <summary>
        /// Store polinomial.
        /// </summary>
        private double[] CoefficientArray;

        public Polinomial(params double[] source)
        {
            this.CoefficientArray = (double[])source.Clone();
        }

        
        /// <summary>
        /// Addition of polinomials.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Polinomial Add(Polinomial x, Polinomial y)
        {
            /*if (x == null && y == null)
                throw new ArgumentNullException();
            if (x == null && y != null)
                return new Polinomial(y.CoefficientArray);
            if (x != null && y == null)
                return new Polinomial(x.CoefficientArray);*/
            return new Polinomial(SumPolynom(x.CoefficientArray, y.CoefficientArray));
        }

        /// <summary>
        /// Substraction of polinomials.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Polinomial Substract(Polinomial x, Polinomial y)
        {
            double[] negY = new double[y.CoefficientArray.Length];
            for (int i = 0; i < y.CoefficientArray.Length; i++)
                negY[i] = y.CoefficientArray[i] * (-1);
            return new Polinomial(SumPolynom(x.CoefficientArray, negY));      
        }

        /// <summary>
        /// Myltiply of polinomials.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Polinomial Multiply(Polinomial x, Polinomial y)
        {
            double[] result = new double[x.CoefficientArray.Length * y.CoefficientArray.Length];
            for (int i=0;i<x.CoefficientArray.Length;i++)
                for (int j = 0; j < y.CoefficientArray.Length; j++)
                    result[i + j] += x.CoefficientArray[i] * y.CoefficientArray[j];
            return new Polinomial(result);
        }

        /// <summary>
        /// Overloaded addition operator.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Polinomial operator +(Polinomial x, Polinomial y)
        {
            return Add(x, y);
        }

        /// <summary>
        /// Overloaded substraction operator.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Polinomial operator -(Polinomial x, Polinomial y)
        {
            return Substract(x, y);
        }

        /// <summary>
        /// Overloaded miltiply operator.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Polinomial operator *(Polinomial x, Polinomial y)
        {
            return Multiply(x, y);
        }

        /// <summary>
        /// Method GetHashCode System.Object
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (int)CoefficientArray.Sum();
        }

        /// <summary>
        /// Overloaded method Equals System.Object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Polinomial)
                return Equals((Polinomial)obj);
            return false;
        }

        public bool Equals(Polinomial p1)
        {
            return CoefficientArray.SequenceEqual(p1.CoefficientArray);
        }

        public static bool Equals(Polinomial p1, Polinomial p2)
        {
            return p1.CoefficientArray.SequenceEqual(p2.CoefficientArray);
        }

        /// <summary>
        /// Overloaded equality operator.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator ==(Polinomial x, Polinomial y)
        {
            return Equals(x, y);
        }

        /// <summary>
        /// Overloaded inequality operator.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator !=(Polinomial x, Polinomial y)
        {
            return !Equals(x, y);
        }

        /// <summary>
        /// String representation Polinomial.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder temp = new StringBuilder();
            for (int i = 0; i < CoefficientArray.Length; i++)
            {
                if (CoefficientArray[i]!=0)
                    temp.Append(String.Format("{0}x^{1}", CoefficientArray[i], (CoefficientArray.Length - 1 - i)));
                if (CoefficientArray.Length - 1 - i > 0)
                    temp.Append(" + ");
            }
            return temp.ToString();
        }

        public double this[int index]
        {
            get
            {
                if (index < 0 || index > CoefficientArray.Length-1)
                    throw new ArgumentOutOfRangeException();
                return CoefficientArray[index];
            }
        }
       
        /// <summary>
        /// Method summation arrays-polinomias.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private static double[] SumPolynom(double[] x, double[] y)
        {
            double[] result;

            if (x.Length > y.Length)
            {
                result = (double[])x.Clone();
                for (int i = 0; i < y.Length; i++)
                    result[result.Length - 1 - i] += y[y.Length - 1 - i];
            }
            else
            {
                result = (double[])y.Clone();
                for (int i = 0; i < x.Length; i++)
                    result[result.Length - 1 - i] += x[x.Length - 1 - i];
            }
            return result;
        }
    }
}
