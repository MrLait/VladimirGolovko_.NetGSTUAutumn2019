using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }

}
