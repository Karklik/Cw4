using Cw4.Models;
using System.Collections.Generic;

namespace Cw4.DAL
{
    public interface IDbService
    {
        public IEnumerable<Student> GetStudents();
        public Student GetStudent(int idStudent);
        public int CreateStudent(Student student);
        public int UpdateStudent(int idStudent, Student student);
        public int DeleteStudent(int idStudent);
    }
}
