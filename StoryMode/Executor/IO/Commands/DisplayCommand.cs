namespace Executor.IO.Commands
{
    using System;
    using System.Collections.Generic;
    using Attributes;
    using Contracts;
    using Exceptions;

    [Alias("display")]
    class DisplayCommand : Command, IExecutable
    {
        [Inject]
        private IDatabase repository;

        public DisplayCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            string[] data = this.Data;
            if (data.Length != 3)
            {
                throw new InvalidOperationException(this.Input);
            }

            var entityToDisplay = data[1];
            var sortType = data[2];

            if (entityToDisplay.Equals("students", StringComparison.OrdinalIgnoreCase))
            {

                IComparer<Student> studentComparator = this.CreateStudentComparator(sortType);
                ISimpleOrderedBag<Student> list = this.repository.GetAllStudentsSorted(studentComparator);
                OutputWriter.WriteMessageOnNewLine(list.JoinWith(Environment.NewLine));
            }
            else if (entityToDisplay.Equals("courses", StringComparison.OrdinalIgnoreCase))
            {
                IComparer<Course> courseComparator = this.CreateCourseComparator(sortType);
                ISimpleOrderedBag<Course> list = this.repository.GetAllCoursesSorted(courseComparator);
                OutputWriter.WriteMessageOnNewLine(list.JoinWith(Environment.NewLine));
            }
            else
            {
                throw new InvalidOperationException(this.Input);
            }
        }

        private IComparer<Course> CreateCourseComparator(string sortType)
        {
            if (sortType.Equals("ascending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<Course>.Create((s1, s2) => s1.CompareTo(s2));
            }
            else if (sortType.Equals("descending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<Course>.Create((s1, s2) => s2.CompareTo(s1));
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }

        private IComparer<Student> CreateStudentComparator(string sortType)
        {
            if (sortType.Equals("ascending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<Student>.Create((s1, s2) => s1.CompareTo(s2));
            }
            else if (sortType.Equals("descending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<Student>.Create((s1, s2) => s2.CompareTo(s1));
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
