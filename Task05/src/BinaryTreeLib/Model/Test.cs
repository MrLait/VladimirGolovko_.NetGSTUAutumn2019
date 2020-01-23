using BinaryTreeLib.Enums;
using System;

namespace BinaryTreeLib.Model
{
    /// <summary>
    /// Type test.
    /// </summary>
    [Serializable]
    public class Test
    {
        /// <summary>
        /// Test name.
        /// </summary>
        public TestItems TestName { get; set; }

        /// <summary>
        /// Date of test completion.
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Constructor without paremeters.
        /// </summary>
        public Test()
        {
        }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="testName">Test name.</param>
        /// <param name="dateTime">Data ot test completion.</param>
        public Test(TestItems testName, DateTime dateTime)
        {
            TestName = testName;
            DateTime = dateTime;
        }

        /// <summary>
        /// Comparing one test with another.
        /// </summary>
        /// <param name="obj">The compared test.</param>
        /// <returns>True if equal. False if not equal.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Test test = (Test)obj;

            return TestName.Equals(test.TestName) &&
                DateTime.Equals(test.DateTime);
        }

        /// <summary>
        /// Calculate hash code.
        /// </summary>
        /// <returns>The total hash code.</returns>
        public override int GetHashCode()
        {
            return DateTime.GetHashCode() + TestName.GetHashCode();
        }

    }

}
