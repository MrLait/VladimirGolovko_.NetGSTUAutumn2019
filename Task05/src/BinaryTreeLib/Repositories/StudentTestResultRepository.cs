using System;
using System.Collections.Generic;
using BinaryTreeLib.Core;
using BinaryTreeLib.Model;

namespace BinaryTreeLib.Repositories
{
    [Serializable]
    public class StudentTestResultRepository
    {
        public BinaryTree<StudentTestResult> BinaryTreeStudentTestResult { get; set; }

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
