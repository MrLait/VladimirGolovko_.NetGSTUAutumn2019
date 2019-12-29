using System;
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

        /// <summary>
        /// Comparing one StudentTestResultRepository with another.
        /// </summary>
        /// <param name="obj">The compared StudentTestResultRepository.</param>
        /// <returns>True if equal. False if not equal.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            StudentTestResultRepository studentTestResultRepository = (StudentTestResultRepository)obj;

            return BinaryTreeStudentTestResult.Equals(studentTestResultRepository.BinaryTreeStudentTestResult);
        }

        /// <summary>
        /// Calculate hash code.
        /// </summary>
        /// <returns>The total hash code.</returns>
        public override int GetHashCode()
        {
            return BinaryTreeStudentTestResult.GetHashCode();
        }

    }
}
