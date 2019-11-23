using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OverloadOperationsTask2
{
    public class Polynomial
    {
        private readonly double[] elements;

        public double[] Elements => elements;
        public double[] QuotientElements { get;}
        public double[] RemainderElements { get;}

        /// <summary>
        /// Constructor for initializing polynomial elements.
        /// The array element index is the degree of the polynomial.
        /// </summary>
        /// <param name="elements">Elements of the polynomial.</param>
        public Polynomial(double[] elements)
        {
            this.elements = elements;
        }

        /// <summary>
        /// Constructor for initializing polynomial elements in quotient remainder format.
        /// The array element index is the degree of the polynomial.
        /// </summary>
        /// <param name="quotientElements">Quotient elements of the polynomial.</param>
        /// <param name="remainderElements">Remainder elements of the polynomial.</param>
        public Polynomial(double[] quotientElements, double[] remainderElements)
        {
            QuotientElements = quotientElements;
            RemainderElements = remainderElements;
        }

        /// <summary>
        /// Access polynomial elements by index.
        /// Where the index number is the degree of the polynomial.
        /// </summary>
        /// <param name="i">Polynomial index.</param>
        /// <returns>The element with a given index.</returns>
        public double this[int i]
        {
            get
            {
                if (i <= elements.Length)
                    return elements[i];
                else
                    throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// The method of dividing a polynomial into a polynomial.
        /// Where polynomial index is degree.
        /// </summary>
        /// <param name="dividend">Parameters of a divisible polynomial.</param>
        /// <param name="divider">Polynomial divisor coefficients.</param>
        /// <returns>Returns the new polynomial in the quotient remainder format.</returns>
        public static Polynomial operator /(Polynomial dividend, Polynomial divider)
        {
            double[] dividendParams = dividend.Elements;
            double[] dividerParams = divider.Elements;

            if (dividend.Elements.Length < divider.Elements.Length)
                throw new ArithmeticException("The degree of the divisor must be less than or equal" +
                    " to the degree of the dividend!");
            if (dividend.Elements[dividend.Elements.Length - 1] == 0
                | divider.Elements[divider.Elements.Length - 1] == 0)
            {
                throw new ArgumentException("The Last Polynomial parameters can't be is zero");
            }

            double[] quotientElements = new double[dividendParams.Length - dividerParams.Length + 1];
            double[] remainderElements = dividend.Elements;

            for (int i = 0; i < quotientElements.Length; i++)
            {
                double coeff = remainderElements[dividendParams.Length - i - 1] / dividerParams[dividerParams.Length - 1];
                quotientElements[quotientElements.Length - 1 - i] = coeff;

                for (int j = 0; j < dividerParams.Length; j++)
                {
                    remainderElements[dividendParams.Length - 1 - i - j] = remainderElements[dividendParams.Length - 1 - i - j]
                        - dividerParams[dividerParams.Length - 1 - j] * coeff;
                }
            }

            return new Polynomial(quotientElements, remainderElements);
        }

        /// <summary>
        /// The method of multiplication a polynomial into a polynomial.
        /// Where polynomial index is degree.
        /// <param name="PolynomialOne">Elements of the polynomial one.</param>
        /// <param name="PolynomialTwo">Elements of the polynomial two.</param>
        /// <returns>Returns the new polynomial.</returns>
        public static Polynomial operator *(Polynomial PolynomialOne, Polynomial PolynomialTwo)
        {
            double[] multResultPolynomial = new double[PolynomialOne.Elements.Length + PolynomialTwo.Elements.Length - 1];

            for (int i = 0; i < PolynomialOne.Elements.Length; i++)
            {
                for (int j = 0; j < PolynomialTwo.Elements.Length; j++)
                {
                    multResultPolynomial[i + j] += PolynomialOne.Elements[i] * PolynomialTwo.Elements[j];
                }
            }

            return new Polynomial(multResultPolynomial);
        }

        /// <summary>
        /// Method for summing a polynomial into a polynomial.
        /// Where polynomial index is degree.
        /// <param name="PolynomialOne">Elements of the polynomial one.</param>
        /// <param name="PolynomialTwo">Elements of the polynomial two.</param>
        /// <returns>Returns the new polynomial.</returns>
        public static Polynomial operator +(Polynomial PolynomialOne, Polynomial PolynomialTwo)
        {
            double[] sumPolynomialResult = PolynomialOne.Elements.Length >= PolynomialTwo.Elements.Length
                ? PolynomialOne.Elements
                : PolynomialTwo.Elements;

            if (PolynomialOne.Elements.Length >= PolynomialTwo.Elements.Length)
                sumPolynomialResult = SumPolynomialElementsWithArray(PolynomialTwo.Elements, sumPolynomialResult);
            else 
                sumPolynomialResult = SumPolynomialElementsWithArray(PolynomialOne.Elements, sumPolynomialResult);

            return new Polynomial(sumPolynomialResult);
        }

        /// <summary>
        /// Method for substracting a polynomial from polynomial.
        /// Where polynomial index is degree.
        /// <param name="PolynomialOne">Elements of the polynomial one.</param>
        /// <param name="PolynomialTwo">Elements of the polynomial two.</param>
        /// <returns>Returns the new polynomial.</returns>
        public static Polynomial operator -(Polynomial PolynomialOne, Polynomial PolynomialTwo)
        {
            double[] sumPolynomialResult = PolynomialOne.Elements.Length >= PolynomialTwo.Elements.Length
                ? PolynomialOne.Elements
                : PolynomialTwo.Elements;

            if (PolynomialOne.Elements.Length >= PolynomialTwo.Elements.Length)
                sumPolynomialResult = SubtractionPolynomialElementsFromArray(PolynomialTwo.Elements, sumPolynomialResult);
            else
                sumPolynomialResult = SubtractionPolynomialElementsFromArray(PolynomialOne.Elements, sumPolynomialResult);

            return new Polynomial(sumPolynomialResult);
        }

        /// <summary>
        /// Method for summing a polinomial elements with an array.
        /// Where polynomial elements index is degree.
        /// </summary>
        /// <param name="polynomialElements"> Elements of a polynomial.</param>
        /// <param name="arrNumber">Array for summing with a polynomial elements.</param>
        /// <returns>Returns the summation of polynomial elements with array elements.</returns>
        private static double[] SumPolynomialElementsWithArray(double[] polynomialElements, double[] arrNumber)
        {
            for (int i = 0; i < polynomialElements.Length; i++)
            {
                arrNumber[i] += polynomialElements[i];
            }

            return arrNumber;
        }

        /// <summary>
        /// Subtracting a polynomial from an array.
        /// Where polynomial elements index is degree.
        /// </summary>
        /// <param name="polynomialElements"> Elements of a polynomial.</param>
        /// <param name="arrNumber">Array for summing with a polynomial elements.</param>
        /// <returns>Returns the substracion of polynomial elements from array elements.</returns>
        private static double[] SubtractionPolynomialElementsFromArray(double[] polynomialElements, double[] arrNumber)
        {
            for (int i = 0; i < polynomialElements.Length; i++)
            {
                arrNumber[i] -= polynomialElements[i];
            }

            return arrNumber;
        }
    }
}
