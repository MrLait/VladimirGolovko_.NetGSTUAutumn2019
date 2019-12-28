using BinaryTreeLib.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using BinaryTreeLib.Repositories;
using BinaryTreeLib.Model;
using BinaryTreeLib.Serializer;

namespace ConsoleApp1
{
    public class Program
    {

        // Beginning of nested classes.

        // Nested class to do ascending sort on year property.
        private class sortYearAscendingHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                car c1 = (car)a;
                car c2 = (car)b;

                if (c1.Year > c2.Year)
                    return 1;

                if (c1.Year < c2.Year)
                    return -1;

                else
                    return 0;
            }
        }

        // Nested class to do descending sort on year property.
        private class sortYearDescendingHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                car c1 = (car)a;
                car c2 = (car)b;

                if (c1.Year < c2.Year)
                    return 1;

                if (c1.Year > c2.Year)
                    return -1;

                else
                    return 0;
            }
        }

        // Nested class to do descending sort on make property.
        private class sortMakeDescendingHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                car c1 = (car)a;
                car c2 = (car)b;
                return String.Compare(c2.Make, c1.Make);
            }
        }

        // End of nested classes.

        public class car : IComparable
        {
            private int year;
            private string make;

            public car(string Make, int Year)
            {
                make = Make;
                year = Year;
            }

            public int Year
            {
                get { return year; }
                set { year = value; }
            }

            public string Make
            {
                get { return make; }
                set { make = value; }
            }

            // Implement IComparable CompareTo to provide default sort order.
            int IComparable.CompareTo(object obj)
            {
                car c = (car)obj;
                return String.Compare(this.make, c.make);
            }

            // Method to return IComparer object for sort helper.
            public static IComparer sortYearAscending()
            {
                return (IComparer)new sortYearAscendingHelper();
            }

            // Method to return IComparer object for sort helper.
            public static IComparer sortYearDescending()
            {
                return (IComparer)new sortYearDescendingHelper();
            }

            // Method to return IComparer object for sort helper.
            public static IComparer sortMakeDescending()
            {
                return (IComparer)new sortMakeDescendingHelper();
            }

        }


        static void Main(string[] args)
        {
            BinaryTree<int> treeOne = new BinaryTree<int>();
            treeOne.Add(5);
            treeOne.Add(3);
            treeOne.Add(8);
            treeOne.Add(7);
            treeOne.Add(10);
            treeOne.Add(11);
            treeOne.Add(12);


            List<BinaryTree<int>> list = new List<BinaryTree<int>>();
            list.Add(new BinaryTree<int>());
            //list.Add(new AssemblyBO() { DisplayName = "Try", Identifier = "243242" });
            XDocument doc = new XDocument();
           // SerializeParams<T>(doc, list);
            //List<AssemblyBO> newList = DeserializeParams<AssemblyBO>(doc);

            BinaryTree<int> treeTwo = new BinaryTree<int>();

            treeTwo.Add(7);
            treeTwo.Add(1);
            treeTwo.Add(5);
            treeTwo.Add(2);
            treeTwo.Add(8);
            treeTwo.Add(6);
            treeTwo.Add(9);
            treeTwo.Add(10);

            BinaryTree<int> treeThree = new BinaryTree<int>();

            treeThree.Add(1);
            treeThree.Add(7);
            treeThree.Add(5);


            BinaryTree<int> treeFour = new BinaryTree<int>();

            treeFour.Add(8);
            treeFour.Add(4);
            treeFour.Add(12);
            treeFour.Add(2);
            treeFour.Add(6);
            treeFour.Add(10);
            treeFour.Add(14);
            treeFour.Add(16);
            treeFour.Add(17);
            treeFour.Add(18);

            Console.WriteLine("PreOrder");
            foreach (var item in treeFour.PreOrder())
            {
                Console.Write(item + ", ");
            }

            Console.WriteLine();
            Console.WriteLine("PostOrder");
            foreach (int item in treeFour.PostOrder())
            {
                Console.Write(item + ", ");
            }

            Console.WriteLine();
            Console.WriteLine("InOrder");
            foreach (int item in treeFour.InOrder())
            {
                Console.Write(item + ", ");
            }

            var testNull = treeFour.FindNode(3);
            var testFindEightNode = treeFour.FindNode(8);

            BinaryTree<string> treeFive = new BinaryTree<string>();

            treeFive.Add("v");
            treeFive.Add("a");
            treeFive.Add("b");
            treeFive.Add("c");
            treeFive.Add("d");
            //treeFour.Add(6);
            //treeFour.Add(10);
            //treeFour.Add(14);
            //treeFour.Add(16);
            //treeFour.Add(17);
            //treeFour.Add(18);

            Console.WriteLine();
            Console.WriteLine("InOrdertreeFive");
            foreach (string item in treeFive.InOrder())
            {
                Console.Write(item + ", ");
            }


            StudentTestResult studentVasaTestResult = new StudentTestResult(new Student(0, "Vasa"), new Test(TestItems.Algebra, new DateTime(10, 10, 10)), 100);
            StudentTestResult studentVovaTestResult = new StudentTestResult(new Student(1, "Andrey"), new Test(TestItems.Algebra, new DateTime(10, 10, 20)), 990);
            StudentTestResult studentDimaTestResult = new StudentTestResult(new Student(2, "Dima"), new Test(TestItems.Art, new DateTime(30, 1, 20)), 80);

            StudentTestResultRepository studentTestResultRepository = new StudentTestResultRepository();

            studentTestResultRepository.AddStudentTestResultToBinaryTree(studentVasaTestResult);
            studentTestResultRepository.AddStudentTestResultToBinaryTree(studentVovaTestResult);
            studentTestResultRepository.AddStudentTestResultToBinaryTree(studentDimaTestResult);

            XmlSerializer formatter = new XmlSerializer(typeof(StudentTestResultRepository));

            using (FileStream fs = new FileStream("studentTestResultRepository.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, studentTestResultRepository);
            }


            Serialization.XmlSerialaizer<StudentTestResultRepository>(studentTestResultRepository);
            Serialization.XmlSerialaizer<BinaryTree<string>>(treeFive);
            var test = Serialization.XmlDeserialize<BinaryTree<string>>("BinaryTree`1.xml");

        }

        //private void SerializeParams<T>(XDocument doc, List<T> paramList)
        //{
        //    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(paramList.GetType());

        //    System.Xml.XmlWriter writer = doc.CreateWriter();

        //    serializer.Serialize(writer, paramList);
        //    ,
        //    writer.Close();
        //}

        //private List<T> DeserializeParams<T>(XDocument doc)
        //{
        //    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<T>));

        //    System.Xml.XmlReader reader = doc.CreateReader();

        //    List<T> result = (List<T>)serializer.Deserialize(reader);
        //    reader.Close();

        //    return result;
        //}

    }
}
