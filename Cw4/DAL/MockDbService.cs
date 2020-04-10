using Cw4.Models;
using System.Collections.Generic;

namespace Cw4.DAL
{
    public class MockDbService : IDbService
    {
        private static IEnumerable<Student> _students;

        static MockDbService()
        {
            _students = new List<Student>
            {
                new Student { IdStudent = 1, FirstName = "Jan", LastName = "Kowalski"},
                new Student { IdStudent = 2, FirstName = "Krzysztof", LastName = "Ross"},
                new Student { IdStudent = 3, FirstName = "Marcin", LastName = "Krab"}
            };
        }

        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }
    }
}
