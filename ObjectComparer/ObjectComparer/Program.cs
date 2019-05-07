using ObjectComparer.Models;
using System;
using System.Collections.Generic;

namespace ObjectComparer
{
    class Program
    {
        static void Main(string[] args)
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
            bool actualResult = student1.SimilarComparer(student2);
            Console.WriteLine(actualResult);
            Console.ReadKey();
        }
    }
}
