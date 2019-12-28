using System;

namespace BinaryTreeLib.Model
{
    /// <summary>
    /// A type that contains the test result for the student.
    /// </summary>
    [Serializable]
    public class StudentTestResult: IComparable
    {
        /// <summary>
        /// Student type.
        /// </summary>
        public Student Student { get;  set; }

        /// <summary>
        /// Test type.
        /// </summary>
        public Test Test { get;  set; }

        /// <summary>
        /// Test result type for student.
        /// </summary>
        public int TestResult { get;  set; }

        /// <summary>
        /// Constructor without parameters.
        /// </summary>
        public StudentTestResult()
        {
        }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="student">Input student.</param>
        /// <param name="test">Input test.</param>
        /// <param name="testResult">input test result for student.</param>
        public StudentTestResult(Student student, Test test, int testResult)
        {
            Student = student;
            Test = test;
            TestResult = testResult;
        }

        /// <summary>
        /// Implementation of IComparable interface.
        /// </summary>
        /// <param name="obj">An object to compare with this instance..</param>
        /// <returns>Returns Int32 A value that indicates the relative order of the objects 
        /// being compared.The return value has these meanings: 
        /// Value               Meaning 
        /// Less than zero      This instance precedes obj in the sort order.
        /// Zero                This instance occurs in the same position in the sort order as obj.
        /// Greater than zero   This instance follows obj in the sort order.</returns>
        public int CompareTo(object obj)
        {
            if (obj is StudentTestResult item)
                return TestResult.CompareTo(item.TestResult);
            else
                throw new ArgumentException("Types do not match");
        }
    }
}
