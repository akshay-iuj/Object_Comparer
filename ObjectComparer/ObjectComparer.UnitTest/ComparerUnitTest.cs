using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectComparer.Models;

namespace ObjectComparer.UnitTest
{
    [TestClass]
    public class ComparerUnitTest
    {
        [TestMethod]
        public void PrimitiveProperty_Positive()
        {
            var student1 = new Student
            {
                Name = "Akshay",
                Id = 101,
                Marks = new[] { 90, 80, 100, 102, 123 },
                Sub = new String[] { "Hindi", "Eng" },
                Abc = new Employee { Dept = "Akshay" },
                lis = new List<int> { 1, 2, 3, 4 },
                Garment = new Dictionary<char, float>()
                {
                      {'a',20},
                      {'b',30},
                       {'c',40},
                       {'d',60},
                }
            };
            var student2 = new Student
            {
                Name = "Akshay",
                Id = 101,
                Marks = new[] { 80, 100, 90, 123, 102 },
                Sub = new String[] { "Eng", "Hindi" },
                Abc = new Employee { Dept = "Akshay" },
                lis = new List<int> { 2, 1, 3, 4 },
                Garment = new Dictionary<char, float>()
                {
                  {'a',20},
                      {'b',30},
                       {'c',40},
                       {'d',60},
                }
            };
            bool actualResult = student1.SimilarComparer(student2);
            bool expectedResult = true;
            Assert.AreEqual(actualResult, expectedResult, "Objects are equal");
        }

        [TestMethod]
        public void PrimitiveProperty_Negative()
        {
            var student1 = new Student
            {
                Name = "Vishal",
                Id = 101,
                Marks = new[] { 90, 80, 100, 102, 123 },
                Sub = new String[] { "Hindi", "Eng" },
                Abc = new Employee { Dept = "Akshay" },
                lis = new List<int> { 1, 2, 3, 4 },
                Garment = new Dictionary<char, float>()
                {
                      {'a',20},
                      {'b',30},
                       {'c',40},
                       {'d',60},
                }
            };
            var student2 = new Student
            {
                Name = "Akshay",
                Id = 101,
                Marks = new[] { 80, 100, 90, 123, 102 },
                Sub = new String[] { "Eng", "Hindi" },
                Abc = new Employee { Dept = "Akshay" },
                lis = new List<int> { 2, 1, 3, 4 },
                Garment = new Dictionary<char, float>()
                {
                  {'a',20},
                      {'b',30},
                       {'c',40},
                       {'d',60},
                }
            };
            bool actualResult = student1.SimilarComparer(student2);
            bool expectedResult = false;
            Assert.AreEqual(actualResult, expectedResult, "Objects are not equal");
        }


        [TestMethod]
        public void ReferenceProperty_Positive()
        {
            var student1 = new Student
            {
                Name = "Akshay",
                Id = 101,
                Marks = new[] { 90, 80, 100, 102, 123 },
                Sub = new String[] { "Hindi", "Eng" },
                Abc = new Employee { Dept = "Akshay" },
                lis = new List<int> { 1, 2, 3, 4 },
                Garment = new Dictionary<char, float>()
                {
                       {'a',20},
                       {'b',30},
                       {'c',40},
                       {'d',60},
                }
            };
            var student2 = new Student
            {
                Name = "Akshay",
                Id = 101,
                Marks = new[] { 80, 100, 90, 123, 102 },
                Sub = new String[] { "Eng", "Hindi" },
                Abc = new Employee { Dept = "Akshay" },
                lis = new List<int> { 2, 1, 3, 4 },
                Garment = new Dictionary<char, float>()
                {
                       {'a',20},
                       {'b',30},
                       {'c',40},
                       {'d',60},
                }
            };
            bool actualResult = student1.SimilarComparer(student2);
            bool expectedResult = true;
            Assert.AreEqual(actualResult, expectedResult, "Objects are equal");
        }

        [TestMethod]
        public void ReferenceProperty_Negative()
        {
            var student1 = new Student
            {
                Name = "Akshay",
                Id = 101,
                Marks = new[] { 90, 80, 100, 102, 123 },
                Sub = new String[] { "Hindi", "Eng" },
                Abc = new Employee { Dept = "Akshay" },
                lis = new List<int> { 1, 2, 3, 4 },
                Garment = new Dictionary<char, float>()
                {
                       {'a',20},
                       {'b',30},
                       {'c',40},
                       {'d',60},
                }
            };
            var student2 = new Student
            {
                Name = "Akshay",
                Id = 101,
                Marks = new[] { 80, 100, 90, 123, 102 },
                Sub = new String[] { "Eng", "Hindi" },
                Abc = new Employee { Dept = "Akshay" },
                lis = new List<int> { 2, 1, 3, 4 },
                Garment = new Dictionary<char, float>()
                {
                       {'a',20},
                       {'b',30},
                       {'c',40},
                       {'d',100},
                }
            };
            bool actualResult = student1.SimilarComparer(student2);
            bool expectedResult = false;
            Assert.AreEqual(actualResult, expectedResult, "Objects are not equal");
        }

        [TestMethod]
        public void ArrayElementsDifferentOrder_Positive()
        {
            var student1 = new Student
            {
                Name = "Akshay",
                Id = 101,
                Marks = new[] { 90, 80, 100, 102, 123 },
                Sub = new String[] { "Hindi", "Eng" },
                Abc = new Employee { Dept = "Akshay" },
                lis = new List<int> { 1, 2, 3, 4 },
                Garment = new Dictionary<char, float>()
                {
                      {'a',20},
                      {'b',30},
                       {'c',40},
                       {'d',60},
                }
            };
            var student2 = new Student
            {
                Name = "Akshay",
                Id = 101,
                Marks = new[] { 80, 100, 90, 123, 102 },
                Sub = new String[] { "Eng", "Hindi" },
                Abc = new Employee { Dept = "Akshay" },
                lis = new List<int> { 2, 1, 3, 4 },
                Garment = new Dictionary<char, float>()
                {
                  {'a',20},
                      {'b',30},
                       {'c',40},
                       {'d',60},
                }
            };
            bool actualResult = student1.SimilarComparer(student2);
            bool expectedResult = true;
            Assert.AreEqual(actualResult, expectedResult, "Objects are equal");
        }

        [TestMethod]
        public void ArrayElementsDifferentOrder_Negative()
        {
            var student1 = new Student
            {
                Name = "Akshay",
                Id = 101,
                Marks = new[] { 90, 80, 100, 102, 123, 22 },
                Sub = new String[] { "Hindi", "Eng" },
                Abc = new Employee { Dept = "Akshay" },
                lis = new List<int> { 1, 2, 3, 4 },
                Garment = new Dictionary<char, float>()
                {
                      {'a',20},
                      {'b',30},
                       {'c',40},
                       {'d',60},
                }
            };
            var student2 = new Student
            {
                Name = "Akshay",
                Id = 101,
                Marks = new[] { 80, 100, 90, 123, 102 },
                Sub = new String[] { "Eng", "Hindi" },
                Abc = new Employee { Dept = "Akshay" },
                lis = new List<int> { 2, 1, 3, 4 },
                Garment = new Dictionary<char, float>()
                {
                  {'a',20},
                      {'b',30},
                       {'c',40},
                       {'d',60},
                }
            };
            bool actualResult = student1.SimilarComparer(student2);
            bool expectedResult = false;
            Assert.AreEqual(actualResult, expectedResult, "Objects are not equal");
        }

        [TestMethod]
        public void ObjectContainingComplexObject_Positive()
        {
            var student1 = new Student
            {
                Name = "Akshay",
                Id = 101,
                Marks = new[] { 90, 80, 100, 102, 123 },
                Sub = new String[] { "Hindi", "Eng" },
                Abc = new Employee { Dept = "Akshay" },
                lis = new List<int> { 1, 2, 3, 4 },
                Garment = new Dictionary<char, float>()
                {
                      {'a',20},
                      {'b',30},
                       {'c',40},
                       {'d',60},
                }
            };
            var student2 = new Student
            {
                Name = "Akshay",
                Id = 101,
                Marks = new[] { 80, 100, 90, 123, 102 },
                Sub = new String[] { "Eng", "Hindi" },
                Abc = new Employee { Dept = "Akshay" },
                lis = new List<int> { 2, 1, 3, 4 },
                Garment = new Dictionary<char, float>()
                {
                  {'a',20},
                      {'b',30},
                       {'c',40},
                       {'d',60},
                }
            };
            bool actualResult = student1.SimilarComparer(student2);
            bool expectedResult = true;
            Assert.AreEqual(actualResult, expectedResult, "Objects are equal");
        }

        [TestMethod]
        public void ObjectContainingComplexObject_Negative()
        {
            var student1 = new Student
            {
                Name = "Akshay",
                Id = 101,
                Marks = new[] { 90, 80, 100, 102, 123 },
                Sub = new String[] { "Hindi", "Eng" },
                Abc = new Employee { Dept = "Akshay" },
                lis = new List<int> { 1, 2, 3, 4 },
                Garment = new Dictionary<char, float>()
                {
                      {'a',20},
                      {'b',30},
                       {'c',40},
                       {'d',60},
                }
            };
            var student2 = new Student
            {
                Name = "Akshay",
                Id = 101,
                Marks = new[] { 80, 100, 90, 123, 102 },
                Sub = new String[] { "Eng", "Hindi" },
                Abc = new Employee { Dept = "Vishal" },
                lis = new List<int> { 2, 1, 3, 4 },
                Garment = new Dictionary<char, float>()
                {
                  {'a',20},
                      {'b',30},
                       {'c',40},
                       {'d',60},
                }
            };
            bool actualResult = student1.SimilarComparer(student2);
            bool expectedResult = false;
            Assert.AreEqual(actualResult, expectedResult, "Objects are not equal");
        }


        [TestMethod]
        public void TestMethod1()
        {
            var student1 = new Student
            {
                Name = "Akshay",
                Id = 101,
                Marks = new[] { 90, 80, 100, 102, 123 },
                Sub = new String[] { "Hindi", "Eng" },
                Abc = new Employee { Dept = "Akshay" },
                lis = new List<int> { 1, 2, 3, 4 },
                Garment = new Dictionary<char, float>()
                {
                      {'a',20},
                      {'b',30},
                       {'c',40},
                       {'d',60},
                }
            };
            var student2 = new Student
            {
                Name = "Akshay",
                Id = 101,
                Marks = new[] { 80, 100, 90, 123, 102 },
                Sub = new String[] { "Eng", "Hindi" },
                Abc = new Employee { Dept = "Akshay" },
                lis = new List<int> { 2, 1, 3, 4 },
                Garment = new Dictionary<char, float>()
                {
                  {'a',20},
                      {'b',30},
                       {'c',40},
                       {'d',60},
                }
            };
            bool actualResult = student1.SimilarComparer(student2);
            bool expectedResult = true;
            Assert.AreEqual(actualResult, expectedResult, "Objects are equal");
        }
    }
}
