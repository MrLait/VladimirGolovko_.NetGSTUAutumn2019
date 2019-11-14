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
        /// Readonly property X
        /// </summary>
        public double X => x;
        /// <summary>
        /// Readonly property Y
        /// </summary>
        public double Y => y;
        /// <summary>
        /// Readonly property Z
        /// </summary>
        public double Z => z;

        public double Magnitude
        {
            get => Math.Sqrt(x * x + y * y + z * z);
        }

        public Vector Normalized
        {
            get => new Vector(
                x / Magnitude,
                y / Magnitude,
                z / Magnitude);
        }
        public double SqrMagnitude
        {
            get => (x * x + y * y + z * z);
        }

        public double this[int i]
        {
            get
            {
                switch(i)
                {
                    case 0: { return x; }
                    case 1: { return y; }
                    case 2: { return z; }
                    default: throw new ArgumentException("A vector can " +
                        "contain only three elements.");
                }
            }
        }

        /// <summary>
        /// Operator -Subtracts one vector from another.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns the vector after subtraction.</returns>
        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(
                v1.X - v2.X,
                v1.Y - v2.Y,
                v1.Z - v2.Z);
        }

        /// <summary>
        /// Operator == Returns true if two vectors are approximately equal.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns bool after comparison.</returns>
        public static bool operator ==(Vector v1, Vector v2)
        {
            return ((v1.X == v2.X) &&
                    (v1.Y == v2.Y) &&
                    (v1.Z == v2.Z));
        }

        /// <summary>
        /// Operator != Returns true if vectors different.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns bool after comparison.</returns>
        public static bool operator !=(Vector v1, Vector v2)
        {
            return !(v1 == v2);
        }

        /// <summary>
        /// Operator +Adds two vectors.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>Returns the vector after summation.</returns>
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(
                v1.X + v2.X,
                v1.Y + v2.Y,
                v1.Z + v2.Z);
        }

        /// <summary>
        /// Operator *Multiplies a vector by a number.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The first number.</param>
        /// <returns>Returns the vector after multiplication.</returns>
        public static Vector operator *(Vector v1, double d1)
        {
            return new Vector(
                v1.X * d1,
                v1.Y * d1,
                v1.Z * d1);
        }
        /// <summary>
        /// Operator *Multiplies a number by a vector.
        /// </summary>
        /// <param name="v1">The first number./param>
        /// <param name="v2">The first vector.</param>
        /// <returns>Returns the vector after multiplication.</returns>
        public static Vector operator *(double d1, Vector v1)
        {
            return new Vector(
                v1.X * d1,
                v1.Y * d1,
                v1.Z * d1);
        }

        /// <summary>
        /// Operator / Divides a vector by a number.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The first number.</param>
        /// <returns>Returns the vector after division.</returns>
        public static Vector operator /(Vector v1, double d1)
        {
            return new Vector(
                v1.X / d1,
                v1.Y / d1,
                v1.Z / d1);
        }
        /// <summary>
        /// Operator / Divides a number by a vector.
        /// </summary>
        /// <param name="v1">The first number.</param>
        /// <param name="v2">The first vector.</param>
        /// <returns>Returns the vector after division.</returns>
        public static Vector operator /(double d1, Vector v1)
        {
            return new Vector(
                v1.X / d1,
                v1.Y / d1,
                v1.Z / d1);
        }
        /// <summary>
        /// Comparison of the properties of vectors.
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>Returns bool after comparison.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Vector v)
            {
                return ((this.X == v.X) &&
                        (this.Y == v.Y) &&
                        (this.Z == v.Z));
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