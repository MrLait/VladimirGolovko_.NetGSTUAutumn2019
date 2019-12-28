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
        public int Id { get;  set; }

        /// <summary>
        /// Student name.
        /// </summary>
        public string Name { get;  set; }

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
    }
}
