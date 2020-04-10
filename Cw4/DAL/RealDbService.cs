using Cw4.Models;
using Microsoft.VisualBasic.CompilerServices;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Cw4.DAL
{
    public class RealDbService : IDbService
    {
        private readonly string connectionString = "Data Source=db-mssql;Initial Catalog=s16556;Integrated Security=True";

        public int CreateStudent(Student student)
        {
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand
            {
                Connection = connection,
                CommandText = $"INSERT INTO Student " +
                $"VALUES('{student.IndexNumber}', '{student.FirstName}', '{student.LastName}', " +
                $"'{student.BirthDate}', {student.IdEnrollment})"
            };
            connection.Open();
            return command.ExecuteNonQuery();
        }

        public int DeleteStudent(string indexNumber)
        {
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand
            {
                Connection = connection,
                CommandText = $"DELETE FROM Student WHERE IndexNumber = '{indexNumber}'"
            };
            connection.Open();
            return command.ExecuteNonQuery();
        }

        public Student GetStudent(string indexNumber)
        {
            using var connection = new SqlConnection(connectionString);
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = $"SELECT * FROM Student WHERE IndexNumber = '{indexNumber}'";
                connection.Open();
                var executeReader = command.ExecuteReader();
                while (executeReader.Read())
                {
                    var student = new Student
                    {
                        IndexNumber = executeReader["IndexNumber"].ToString(),
                        FirstName = executeReader["FirstName"].ToString(),
                        LastName = executeReader["LastName"].ToString(),
                        BirthDate = executeReader["BirthDate"].ToString(),
                        IdEnrollment = IntegerType.FromObject(executeReader["IdEnrollment"])
                    };
                    return student;
                }
            }
            return null;
        }

        public IEnumerable<Student> GetStudents(string orderBy)
        {
            if (orderBy == null)
                orderBy = "IndexNumber";
            List<Student> students = new List<Student>();
            using var connection = new SqlConnection(connectionString);
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = $"SELECT * FROM Student ORDER BY {orderBy}";
                connection.Open();
                var executeReader = command.ExecuteReader();
                while (executeReader.Read())
                {
                    var student = new Student
                    {
                        IndexNumber = executeReader["IndexNumber"].ToString(),
                        FirstName = executeReader["FirstName"].ToString(),
                        LastName = executeReader["LastName"].ToString(),
                        BirthDate = executeReader["BirthDate"].ToString(),
                        IdEnrollment = IntegerType.FromObject(executeReader["IdEnrollment"])
                    };
                    students.Add(student);
                }
            }
            return students;
        }

        public int UpdateStudent(string indexNumber, Student student)
        {
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand
            {
                Connection = connection,
                CommandText = $"UPDATE Student " +
                $"SET IndexNumber='{student.IndexNumber}', FirstName='{student.FirstName}', " +
                $"LastName='{student.LastName}', BirthDate='{student.BirthDate}', " +
                $"IdEnrollment={student.IdEnrollment}" +
                $"WHERE IndexNumber='{indexNumber}'"
            };
            connection.Open();
            return command.ExecuteNonQuery();
        }
    }
}
