using Cw4.Models;
using System.Collections.Generic;

namespace Cw4.DAL
{
    public interface IDbService
    {
        public IEnumerable<Student> GetStudents(string orderBy);
        public Student GetStudent(string indexNumber);
        public int CreateStudent(Student student);
        public int UpdateStudent(string indexNumber, Student student);
        public int DeleteStudent(string indexNumber);
        object GetStudentEnrollment(string indexNumber);
    }
}
