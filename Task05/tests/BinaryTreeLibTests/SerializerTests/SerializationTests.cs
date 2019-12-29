using BinaryTreeLib.Model;
using BinaryTreeLib.Repositories;
using BinaryTreeLib.Serializer;
using NUnit.Framework;
using System;
using System.IO;

namespace BinaryTreeLibTests.SerializerTests
{
    /// <summary>
    /// SerializationTests type test and related classes with it.
    /// </summary>
    [TestFixture()]
    public class SerializationTests
    {
        /// <summary>
        /// Testing <see cref="Serialization.XmlSerialaizer{T}(T)"/>
        /// </summary>
        [TestCase()]
        public void GivenXmlSerialaizerWhenInputIsStudentTestResultRepositoryThenOutIsXMLFileStudentTestResultRepository()
        {
            //Arrange
            StudentTestResult studentVasaTestResult = new StudentTestResult(new Student(0, "Vasa"), new Test(TestItems.Algebra, new DateTime(10, 10, 10)), 100);
            StudentTestResult studentVovaTestResult = new StudentTestResult(new Student(1, "Andrey"), new Test(TestItems.Algebra, new DateTime(10, 10, 20)), 990);
            StudentTestResult studentDimaTestResult = new StudentTestResult(new Student(2, "Dima"), new Test(TestItems.Art, new DateTime(30, 1, 20)), 80);

            StudentTestResultRepository studentTestResultRepository = new StudentTestResultRepository();
            bool fileIsExist = false;
            string path = "../netcoreapp3.1/StudentTestResultRepository.xml";

            //Act
            studentTestResultRepository.AddStudentTestResultToBinaryTree(studentVasaTestResult);
            studentTestResultRepository.AddStudentTestResultToBinaryTree(studentVovaTestResult);
            studentTestResultRepository.AddStudentTestResultToBinaryTree(studentDimaTestResult);

            Serialization.XmlSerialaizer<StudentTestResultRepository>(studentTestResultRepository);

            FileInfo fileInfo = new FileInfo(path);

            if (fileInfo.Exists)
            {
                fileIsExist = true;
            }

            //Assert
            Assert.AreEqual(true, fileIsExist);
        }

        /// <summary>
        /// Testing <see cref="Serialization.XmlDeserialize{T}(string)"/>
        /// </summary>
        /// <param name="pathToXmlFile">The path to Xml file.</param>
        [TestCase("../netcoreapp3.1/StudentTestResultRepository.xml")]
        public void GivenXmlDeserializeWhenInputIsPathToFileOutIsNewStudentTestResultRepository(string pathToXmlFile)
        {
            //Arrange
            StudentTestResult studentVasaTestResult = new StudentTestResult(new Student(0, "Vasa"), new Test(TestItems.Algebra, new DateTime(10, 10, 10)), 100);
            StudentTestResult studentVovaTestResult = new StudentTestResult(new Student(1, "Andrey"), new Test(TestItems.Algebra, new DateTime(10, 10, 20)), 990);
            StudentTestResult studentDimaTestResult = new StudentTestResult(new Student(2, "Dima"), new Test(TestItems.Art, new DateTime(30, 1, 20)), 80);

            StudentTestResultRepository studentTestResultRepository = new StudentTestResultRepository();

            //Act
            studentTestResultRepository.AddStudentTestResultToBinaryTree(studentVasaTestResult);
            studentTestResultRepository.AddStudentTestResultToBinaryTree(studentVovaTestResult);
            studentTestResultRepository.AddStudentTestResultToBinaryTree(studentDimaTestResult);

            var actualDeserialazedObj = Serialization.XmlDeserialize<StudentTestResultRepository>(pathToXmlFile);

            //Assert
            Assert.AreEqual(studentTestResultRepository, actualDeserialazedObj);
        }

        /// <summary>
        /// Testing <see cref="Serialization.XmlDeserialize{T}(string)"/> when file is not exist.
        /// </summary>
        /// <param name="pathToXmlFile">The path to Xml file.</param>
        [TestCase("../notExist")]
        public void GivenXmlDeserializeWhenInputIsPathToNotExistThenOutIsFileNotFoundException(string pathToXmlFile)
        {
            //Assert
            Assert.That(() => Serialization.XmlDeserialize<StudentTestResultRepository>(pathToXmlFile), Throws.TypeOf<FileNotFoundException>());
        }
    }
}
