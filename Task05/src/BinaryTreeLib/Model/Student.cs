using System;

namespace BinaryTreeLib.Model
{
    /// <summary>
    /// Student type.
    /// </summary>
    [Serializable]
    public class Student
    {
        /// <summary>
        /// Student identification number.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Student name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Constructor without parameters.
        /// </summary>
        public Student()
        {
        }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="id">Student identification number.</param>
        /// <param name="name">Student name.</param>
        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Comparing one student with another.
        /// </summary>
        /// <param name="obj">The compared student.</param>
        /// <returns>True if equal. False if not equal.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Student student = (Student)obj;

            return Id.Equals(student.Id) &&
                Name.Equals(student.Name);
        }

        /// <summary>
        /// Calculate hash code.
        /// </summary>
        /// <returns>The total hash code.</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode() + Name.GetHashCode();
        }
    }
}
