using System;
using System.Collections.Generic;
using BinaryTreeLib.Core;
using BinaryTreeLib.Model;

namespace BinaryTreeLib.Repositories
{
    public class StudentTestResultRepository
    {
        public BinaryTree<StudentTestResult> BinaryTreeStudentTestResult { get; private set; }

        public StudentTestResultRepository()
        {
            BinaryTreeStudentTestResult = new BinaryTree<StudentTestResult>();
        }

        public void AddStudentTestResultToBinaryTree(StudentTestResult studentTestResult)
        {
            if (studentTestResult != null)
            {
                BinaryTreeStudentTestResult.Add(studentTestResult);
            }
        }

    }
}
