using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OverloadOperationsTask2
{
    public class Polinom
    {
        public double[] Quotient { get; set; }
        public double[] Remainder { get; set; }
        public double[] PolinomParams { get; set; }

        public Polinom(double[] polinomParams)
        {
            PolinomParams = polinomParams;
        }

        public Polinom(double[] quotient, double[] remainder)
        {
            Quotient = quotient;
            Remainder = remainder;
        }

        /// <summary>
        /// The method of dividing a polynomial into a polynomial.
        /// Where polinom index is degree.
        /// </summary>
        /// <param name="dividend">Parameters of a divisible polynomial.</param>
        /// <param name="divider">Polynomial divisor coefficients.</param>
        /// <param name="quotient">Parameters of a quotient polynomial.</param>
        /// <param name="remainder">Parameters of a remainder polynomial.</param>
        public static Polinom operator /(Polinom dividend, Polinom divider)
        {
            double[] dividendParams = dividend.PolinomParams;
            double[] dividerParams = divider.PolinomParams;

            if (dividend.PolinomParams.Length < divider.PolinomParams.Length)
                throw new ArithmeticException("The degree of the divisor must be less than or equal" +
                    " to the degree of the dividend!");
            if (dividend.PolinomParams[dividend.PolinomParams.Length - 1] == 0
                | divider.PolinomParams[divider.PolinomParams.Length - 1] == 0)
            {
                throw new ArgumentException("The Last polinom parameters can't be is zero");
            }

            double[] quotient = new double[dividendParams.Length - dividerParams.Length + 1];
            double[] remainder = dividend.PolinomParams;

            for (int i = 0; i < quotient.Length; i++)
            {
                double coeff = remainder[dividendParams.Length - i - 1] / dividerParams[dividerParams.Length - 1];
                quotient[quotient.Length - 1 - i] = coeff;

                for (int j = 0; j < dividerParams.Length; j++)
                {
                    remainder[dividendParams.Length - 1 - i - j] = remainder[dividendParams.Length - 1 - i - j]
                        - dividerParams[dividerParams.Length - 1 - j] * coeff;
                }
            }

            return new Polinom(quotient, remainder);
        }

        public static Polinom operator *(Polinom polinomOne, Polinom polinomTwo)
        {
            double[] multResultPolinom = new double[polinomOne.PolinomParams.Length + polinomTwo.PolinomParams.Length - 1];

            for (int i = 0; i < polinomOne.PolinomParams.Length; i++)
            {
                for (int j = 0; j < polinomTwo.PolinomParams.Length; j++)
                {
                    multResultPolinom[i + j] += polinomOne.PolinomParams[i] * polinomTwo.PolinomParams[j];
                }
            }

            return new Polinom(multResultPolinom);
        }

        public static Polinom operator +(Polinom polinomOne, Polinom polinomTwo)
        {
            double[] sumPolinomResult = polinomOne.PolinomParams.Length >= polinomTwo.PolinomParams.Length
                ? polinomOne.PolinomParams
                : polinomTwo.PolinomParams;

            if (polinomOne.PolinomParams.Length >= polinomTwo.PolinomParams.Length)
                sumPolinomResult = SumPolinomByArray(polinomTwo, sumPolinomResult);
            else 
                sumPolinomResult = SumPolinomByArray(polinomOne, sumPolinomResult);

            return new Polinom(sumPolinomResult);
        }

        public static Polinom operator -(Polinom polinomOne, Polinom polinomTwo)
        {
            double[] sumPolinomResult = polinomOne.PolinomParams.Length >= polinomTwo.PolinomParams.Length
                ? polinomOne.PolinomParams
                : polinomTwo.PolinomParams;

            if (polinomOne.PolinomParams.Length >= polinomTwo.PolinomParams.Length)
                sumPolinomResult = SubtractionPolinomFromArray(polinomTwo, sumPolinomResult);
            else
                sumPolinomResult = SubtractionPolinomFromArray(polinomOne, sumPolinomResult);

            return new Polinom(sumPolinomResult);
        }

        private static double[] SumPolinomByArray(Polinom polinom, double[] arrNumber)
        {
            for (int i = 0; i < polinom.PolinomParams.Length; i++)
            {
                arrNumber[i] += polinom.PolinomParams[i];
            }

            return arrNumber;
        }

        private static double[] SubtractionPolinomFromArray(Polinom polinom, double[] arrNumber)
        {
            for (int i = 0; i < polinom.PolinomParams.Length; i++)
            {
                arrNumber[i] -= polinom.PolinomParams[i];
            }

            return arrNumber;
        }

    }
}
