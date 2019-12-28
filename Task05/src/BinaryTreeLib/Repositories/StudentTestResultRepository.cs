using System;
using System.Collections.Generic;
using BinaryTreeLib.Core;
using BinaryTreeLib.Model;

namespace BinaryTreeLib.Repositories
{
    /// <summary>
    /// A type that stores student test results in a balanced binary tree.
    /// </summary>
    [Serializable]
    public class StudentTestResultRepository
    {
        /// <summary>
        /// Binary tree for student test results.
        /// </summary>
        public BinaryTree<StudentTestResult> BinaryTreeStudentTestResult { get; set; }

        /// <summary>
        /// Constructor without parameters for init BinaryTreeStudentTestResult.
        /// </summary>
        public StudentTestResultRepository()
        {
            BinaryTreeStudentTestResult = new BinaryTree<StudentTestResult>();
        }

        /// <summary>
        /// Adding student test results to a binary tree
        /// </summary>
        /// <param name="studentTestResult">Student test results.</param>
        public void AddStudentTestResultToBinaryTree(StudentTestResult studentTestResult)
        {
            if (studentTestResult != null)
            {
                BinaryTreeStudentTestResult.Add(studentTestResult);
            }
        }
    }
}
