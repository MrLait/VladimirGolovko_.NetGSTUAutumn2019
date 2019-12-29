using BinaryTreeLib.Core;
using BinaryTreeLib.Model;
using BinaryTreeLib.Repositories;
using NUnit.Framework;
using System;

namespace BinaryTreeLibTests.RepositoriesTests
{
    /// <summary>
    /// StudentTestResultRepositoryTests type test and related classes with it.
    /// </summary>
    [TestFixture()]
    public class StudentTestResultRepositoryTests
    {
        /// <summary>
        /// Testing <see cref="StudentTestResultRepository.AddStudentTestResultToBinaryTree(StudentTestResult)"/>
        /// </summary>
        [TestCase()]
        public void GivenAddStudentTestResultToBinaryTreeThenOutIsStudentBinaryTree()
        {
            //Arrange
            StudentTestResult studentVasaTestResult = new StudentTestResult(new Student(0, "Vasa"), new Test(TestItems.Algebra, new DateTime(10, 10, 10)), 100);
            StudentTestResult studentVovaTestResult = new StudentTestResult(new Student(1, "Andrey"), new Test(TestItems.Algebra, new DateTime(10, 10, 20)), 990);
            StudentTestResult studentDimaTestResult = new StudentTestResult(new Student(2, "Dima"), new Test(TestItems.Art, new DateTime(30, 1, 20)), 80);
            StudentTestResultRepository studentTestResultRepository = new StudentTestResultRepository();
            BinaryTree<StudentTestResult> expectedBinaryTree = new BinaryTree<StudentTestResult>();

            //Act
            studentTestResultRepository.AddStudentTestResultToBinaryTree(studentVasaTestResult);
            studentTestResultRepository.AddStudentTestResultToBinaryTree(studentVovaTestResult);
            studentTestResultRepository.AddStudentTestResultToBinaryTree(studentDimaTestResult);

            var actualBinaryTreeStudentTestResult = studentTestResultRepository.BinaryTreeStudentTestResult;

            expectedBinaryTree.Count = 3;
            expectedBinaryTree.Root =
                                new Node<StudentTestResult>(
                                    studentVasaTestResult,
                    new Node<StudentTestResult>(
                        studentDimaTestResult), new Node<StudentTestResult>(
                                                        studentVovaTestResult));

            //Assert
            Assert.AreEqual(expectedBinaryTree, actualBinaryTreeStudentTestResult);
        }


    }
}
