namespace EF.DAL
{
    using System;
    using System.Collections.Generic;

    // POI: Implementation for IDisposable should be provided by the implement
    public interface IStudentRepository : IDisposable
    {
        IEnumerable<Student> GetStudents();
        Student GetStudentByID(int studentId);

        void InsertStudent(Student student);
        void DeleteStudent(int studentId);
        void UpdateStudent(Student student);
        void Save();
    }
}
