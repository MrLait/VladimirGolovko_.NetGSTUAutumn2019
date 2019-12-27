using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeLib.Model
{
    public enum TestItems
    {
        Algebra, Art, Biology, Chemistry, English, Geometry
    }

    public class Test
    {
        public TestItems TestName { get; set; }
        public DateTime DateTime { get; set; }

        public Test(TestItems testName, DateTime dateTime)
        {
            TestName = testName;
            DateTime = dateTime;
        }
    }

}
