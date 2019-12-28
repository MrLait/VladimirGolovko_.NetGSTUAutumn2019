using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeLib.Model
{
    [Serializable]
    public class Test
    {
        public TestItems TestName { get; set; }
        public DateTime DateTime { get; set; }

        public Test()
        {
        }

        public Test(TestItems testName, DateTime dateTime)
        {
            TestName = testName;
            DateTime = dateTime;
        }
    }

}
