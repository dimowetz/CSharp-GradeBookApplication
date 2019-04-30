using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            var allGrades = this.Students.Select(x => x.AverageGrade).ToList().OrderBy(x => x).ToList();
            var threshold = (int)Math.Ceiling(Students.Count / 5.0);

            if (allGrades.ElementAt(threshold * 4) <= averageGrade)
            {
                return 'A';
            }

            if (allGrades.ElementAt(threshold * 3) <= averageGrade)
            {
                return 'B';
            }

            if (allGrades.ElementAt(threshold * 2) <= averageGrade)
            {
                return 'C';
            }

            if (allGrades.ElementAt(threshold * 1) <= averageGrade)
            {
                return 'D';
            }

            return 'F';
        }
    }
}
