namespace EF.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity;

    public class StudentRepository : IStudentRepository, IDisposable
    {
        private readonly SchoolContext _context;
        private bool _isDisposed = false;

        public StudentRepository(SchoolContext context)
        {
            _context = context;
        }

        public void DeleteStudent(int studentId)
        {
            _context.Students.Remove(_context.Students.Find(studentId));
        }

        // POI: We need this custom Dispose method because we want the derived Types of
        // StudentRepository to be able to Dispose certain resources that they might
        // acquire
        // POI: Making 'protected' enables derived Types to be able to inherit this method
        // also not expose to the client of this Type
        protected virtual void Dispose(bool isDispose)
        {
            if (!_isDisposed && isDispose)
            {
                _context.Dispose();
                _isDisposed = true;
            }
        }

        //POI: It's here becaue IStudentRepository interface inherits from IDisposable
        public void Dispose()
        {
            Dispose(true);

            // POI: Why?
            GC.SuppressFinalize(this);
        }

        public Student GetStudentByID(int studentId)
        {
            return _context.Students.Find(studentId);
        }

        public IEnumerable<Student> GetStudents()
        {
            return _context.Students.ToList();
        }

        public void InsertStudent(Student student)
        {
            _context.Students.Add(student);
        }

        public void Save()
        {
            _context.SaveChangesAsync();
        }

        public void UpdateStudent(Student student)
        {
            // POI: Just updating the entity's state. Nothing else. It will
            // force the Entity to be pushed via context
            // POI: The updated entity is passed as the parameter in Entity(...)
            _context.Entry(student).State = EntityState.Modified;
        }
    }
}
