using System;

namespace BinaryTreeLib.Model
{
    [Serializable]
    public class StudentTestResult: IComparable
    {
        public Student Student { get;  set; }
        public Test Test { get;  set; }
        public int TestResult { get;  set; }

        public StudentTestResult()
        {
        }

        public StudentTestResult(Student student, Test test, int testResult)
        {
            Student = student;
            Test = test;
            TestResult = testResult;
        }

        public int CompareTo(object obj)
        {
            if (obj is StudentTestResult item)
                return TestResult.CompareTo(item.TestResult);
            else
                throw new ArgumentException("Types do not match");
        }
    }
}
