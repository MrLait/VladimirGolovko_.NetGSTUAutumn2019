using System;

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
        public double X => x;
        public double Y => y;
        public double Z => z;

        /// <summary>
        /// operator -Subtracts one vector from another.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>  </returns>
        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(
                v1.X - v2.X, 
                v1.Y - v2.Y, 
                v1.Z - v2.Z);
        }
        //operator == Returns true if two vectors are approximately equal.
        public static bool operator ==(Vector v1, Vector v2)
        {
            return ((v1.X == v2.X) &&
                    (v1.Y == v2.Y) &&
                    (v1.Z == v2.Z));
        }
        //operator != Returns true if vectors different.
        public static bool operator !=(Vector v1, Vector v2)
        {
            return !(v1 == v2);
        }

        //operator +Adds two vectors.
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(
                v1.X + v2.X, 
                v1.Y + v2.Y, 
                v1.Z + v2.Z);
        }
        //operator *Multiplies a vector by a number.
        public static Vector operator *(Vector v1, double d1)
        {
            return new Vector(
                v1.X * d1,
                v1.Y * d1,
                v1.Z * d1);
        }
        public static Vector operator *(double d1, Vector v1)
        {
            return new Vector(
                v1.X * d1,
                v1.Y * d1,
                v1.Z * d1);
        }

        //operator / Divides a vector by a number.
        public static Vector operator /(Vector v1, double d1)
        {
            return new Vector(
                v1.X / d1,
                v1.Y / d1,
                v1.Z / d1);
        }
        public static Vector operator /(double d1, Vector v1)
        {
            return new Vector(
                v1.X / d1,
                v1.Y / d1,
                v1.Z / d1);
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector)
            {
                Vector v = (Vector)obj;
                return ((this.X == v.X) &&
                        (this.Y == v.Y) &&
                        (this.Z == v.Z));
            }
            else
                return false;
        }
        public override int GetHashCode()
        {
            return 33 * X.GetHashCode() + Y.GetHashCode()
                + Z.GetHashCode();
        }

    }
}