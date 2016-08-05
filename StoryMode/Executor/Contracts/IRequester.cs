namespace Executor.Contracts
{
    using System.Collections.Generic;

    public interface IRequester
    {
        void GetAllStudentsFromCourse(string courseName);

        void GetStudentScoresFromCourse(string courseName, string username);

        ISimpleOrderedBag<Course> GetAllCoursesSorted(IComparer<Course> cmp);

        ISimpleOrderedBag<Student> GetAllStudentsSorted(IComparer<Student> cmp);
    }
}
