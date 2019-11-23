using System;
using System.Text.RegularExpressions;

namespace OverloadOperationsTask1
{
    public class Vector
    {
        private readonly double x;
        private readonly double y;
        private readonly double z;

        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// X component of the vector.
        /// </summary>
        public double X => x;

        /// <summary>
        /// Y component of the vector.
        /// </summary>
        public double Y => y;

        /// <summary>
        /// Z component of the vector.
        /// </summary>
        public double Z => z;

        /// <summary>
        /// Returns the length of this vector (Read Only).
        /// </summary>
        public double Magnitude
        {
            get => Math.Sqrt(x * x + y * y + z * z);
        }

        /// <summary>
        /// Returns this vector with a magnitude of 1 (Read Only).
        /// </summary>
        public Vector Normalized
        {
            get => new Vector(
                x / Magnitude,
                y / Magnitude,
                z / Magnitude);
        }

        /// <summary>
        /// Returns the squared length of this vector (Read Only).
        /// </summary>
        public double SqrMagnitude
        {
            get => (x * x + y * y + z * z);
        }

        /// <summary>
        /// Access the x, y, z components using [0], [1], [2] respectively.
        /// </summary>
        /// <param name="i">index</param>
        /// <returns></returns>
        public double this[int i]
        {
            get
            {
                switch(i)
                {
                    case 0: { return x; }
                    case 1: { return y; }
                    case 2: { return z; }
                    default: throw new ArgumentOutOfRangeException("A vector can " +
                        "contain only three elements.");
                }
            }
        }

        /// <summary>
        /// Operator -Subtracts one vector from another.
        /// </summary>
        /// <param name="vectorOne">The first vector.</param>
        /// <param name="vectorTwo">The second vector.</param>
        /// <returns>Returns the vector after subtraction.</returns>
        public static Vector operator -(Vector vectorOne, Vector vectorTwo)
        {
            return new Vector(
                vectorOne.X - vectorTwo.X,
                vectorOne.Y - vectorTwo.Y,
                vectorOne.Z - vectorTwo.Z);
        }

        /// <summary>
        /// Operator == Returns true if two vectors are approximately equal.
        /// </summary>
        /// <param name="vectorOne">The first vector.</param>
        /// <param name="vectorTwo">The second vector.</param>
        /// <returns>Returns bool after comparison.</returns>
        public static bool operator ==(Vector vectorOne, Vector vectorTwo)
        {
            return ((vectorOne.X == vectorTwo.X) &&
                    (vectorOne.Y == vectorTwo.Y) &&
                    (vectorOne.Z == vectorTwo.Z));
        }

        /// <summary>
        /// Operator != Returns true if vectors different.
        /// </summary>
        /// <param name="vectorOne">The first vector.</param>
        /// <param name="vectorTwo">The second vector.</param>
        /// <returns>Returns bool after comparison.</returns>
        public static bool operator !=(Vector vectorOne, Vector vectorTwo)
        {
            return !(vectorOne == vectorTwo);
        }

        /// <summary>
        /// Operator +Adds two vectors.
        /// </summary>
        /// <param name="vectorOne">The first vector.</param>
        /// <param name="vectorTwo">The second vector.</param>
        /// <returns>Returns the vector after summation.</returns>
        public static Vector operator +(Vector vectorOne, Vector vectorTwo)
        {
            return new Vector(
                vectorOne.X + vectorTwo.X,
                vectorOne.Y + vectorTwo.Y,
                vectorOne.Z + vectorTwo.Z);
        }

        /// <summary>
        /// Operator *Multiplies a vector by a number.
        /// </summary>
        /// <param name="vectorOne">The first vector.</param>
        /// <param name="vectorTwo">The first number.</param>
        /// <returns>Returns the vector after multiplication.</returns>
        public static Vector operator *(Vector vectorOne, double number)
        {
            return new Vector(
                vectorOne.X * number,
                vectorOne.Y * number,
                vectorOne.Z * number);
        }

        /// <summary>
        /// Operator *Multiplies a number by a vector.
        /// </summary>
        /// <param name="vectorOne">The first number./param>
        /// <param name="vectorTwo">The first vector.</param>
        /// <returns>Returns the vector after multiplication.</returns>
        public static Vector operator *(double number, Vector vectorOne)
        {
            return new Vector(
                vectorOne.X * number,
                vectorOne.Y * number,
                vectorOne.Z * number);
        }

        /// <summary>
        /// Operator / Divides a vector by a number.
        /// </summary>
        /// <param name="vectorOne">The first vector.</param>
        /// <param name="vectorTwo">The first number.</param>
        /// <returns>Returns the vector after division.</returns>
        public static Vector operator /(Vector vectorOne, double number)
        {
            return new Vector(
                vectorOne.X / number,
                vectorOne.Y / number,
                vectorOne.Z / number);
        }

        /// <summary>
        /// Operator / Divides a number by a vector.
        /// </summary>
        /// <param name="vectorOne">The first number.</param>
        /// <param name="vectorTwo">The first vector.</param>
        /// <returns>Returns the vector after division.</returns>
        public static Vector operator /(double number, Vector vectorOne)
        {
            return new Vector(
                number / vectorOne.X,
                number / vectorOne.Y,
                number / vectorOne.Z);
        }

        /// <summary>
        /// Comparison of the properties of vectors.
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>Returns bool after comparison.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Vector vector)
            {
                return ((this.X == vector.X) &&
                        (this.Y == vector.Y) &&
                        (this.Z == vector.Z));
            }
            else
                return false;
        }

        /// <summary>
        /// Hash calculation.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return 33 * X.GetHashCode() + Y.GetHashCode()
                + Z.GetHashCode();
        }
    }
}