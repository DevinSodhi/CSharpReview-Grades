using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Grades;

namespace Grades.Tests
{
    // TestClass, but also needs to be a public class for the Test Runner to read it.
    [TestClass]
    public class GradeBookTests
    {
        [TestMethod]
        public void ComputesHighestGrade()
        {
            //we need to first establish a reference from the other project in this solution
            //right click reference, add reference, choose from solution the Grades project assembly
            //next we need to address the access level of GradeBook
            //we need to adjust the accessmodifier for the Class level, which is by default "internal" -> only code in same project can use such a class. we need to mark it public
            //in .net we can use exe or dll as library
            GradeBook book = new GradeBook();

            book.AddGrade(10);
            book.AddGrade(90);

            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(90, result.HighestGrade);
        }

        [TestMethod]
        public void ComputeLowestGrade()
        {
            //we need to first establish a reference from the other project in this solution
            //right click reference, add reference, choose from solution the Grades project assembly
            //next we need to address the access level of GradeBook
            //we need to adjust the accessmodifier for the Class level, which is by default "internal" -> only code in same project can use such a class. we need to mark it public
            //in .net we can use exe or dll as library
            GradeBook book = new GradeBook();

            book.AddGrade(10);
            book.AddGrade(90);

            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(10, result.LowestGrade);
        }


        [TestMethod]
        public void ComputeAverageGrade()
        {
            //we need to first establish a reference from the other project in this solution
            //right click reference, add reference, choose from solution the Grades project assembly
            //next we need to address the access level of GradeBook
            //we need to adjust the accessmodifier for the Class level, which is by default "internal" -> only code in same project can use such a class. we need to mark it public
            //in .net we can use exe or dll as library
            GradeBook book = new GradeBook();
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics result = book.ComputeStatistics();
            // the 0.01 is a delta that has tolerance for differences
            Assert.AreEqual(85.16f, result.AverageGrade, 0.01);
        }
    }
}
