using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeStatistics
    {
        //we should initialize values in this class.
        public GradeStatistics()
        {
            HighestGrade = 0;
            LowestGrade = float.MaxValue;
        }

        public string LetterGrade
        {
            get
            {
                if(AverageGrade >= 90)
                { return "A"}
            }
        }

        //hold down alt key to select multiple lines of code at the same time.
        public float AverageGrade;
        public float HighestGrade;
        public float LowestGrade;
    }
}
