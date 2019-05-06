using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectComparer.Models
{
    public class Student
    {
        public String Name { get; set; }

        public int Id { get; set; }

        public int[] Marks { get; set; }

        public Dictionary<char, float> Garment { get; set; }

        public List<int> lis { get; set; }

        public String[] Sub { get; set; }

        public Employee Abc { get; set; }

    }
}
