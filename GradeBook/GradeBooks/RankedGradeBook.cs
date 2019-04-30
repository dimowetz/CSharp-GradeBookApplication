using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
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

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}
