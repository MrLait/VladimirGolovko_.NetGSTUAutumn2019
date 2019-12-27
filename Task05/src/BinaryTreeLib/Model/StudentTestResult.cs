using System;

namespace BinaryTreeLib.Model
{
    public class StudentTestResult: IComparable
    {
        public Student Student { get; private set; }
        public Test Test { get; private set; }
        public int TestResult { get; private set; }

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
