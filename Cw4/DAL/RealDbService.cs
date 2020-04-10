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
                $"'{student.BirthDate}', {student.IdStudent})"
            };
            connection.Open();
            return command.ExecuteNonQuery();
        }

        public int DeleteStudent(int idStudent)
        {
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand
            {
                Connection = connection,
                CommandText = $"delete from Student where IdEnrollment = {idStudent}"
            };
            connection.Open();
            return command.ExecuteNonQuery();
        }

        public Student GetStudent(int idStudent)
        {
            using var connection = new SqlConnection(connectionString);
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = $"select * from Student where IdEnrollment = {idStudent}";
                connection.Open();
                var executeReader = command.ExecuteReader();
                while (executeReader.Read())
                {
                    var student = new Student
                    {
                        IdStudent = IntegerType.FromObject(executeReader["IdEnrollment"]),
                        FirstName = executeReader["FirstName"].ToString(),
                        LastName = executeReader["LastName"].ToString(),
                        IndexNumber = executeReader["IndexNumber"].ToString(),
                        BirthDate = executeReader["BirthDate"].ToString()
                    };
                    return student;
                }
            }
            return null;
        }

        public IEnumerable<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            using var connection = new SqlConnection(connectionString);
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = $"select * from Student";
                connection.Open();
                var executeReader = command.ExecuteReader();
                while (executeReader.Read())
                {
                    var student = new Student
                    {
                        IdStudent = IntegerType.FromObject(executeReader["IdEnrollment"]),
                        FirstName = executeReader["FirstName"].ToString(),
                        LastName = executeReader["LastName"].ToString(),
                        IndexNumber = executeReader["IndexNumber"].ToString(),
                        BirthDate = executeReader["BirthDate"].ToString()
                    };
                    students.Add(student);
                }
            }
            return students;
        }

        public int UpdateStudent(int idStudent, Student student)
        {
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand
            {
                Connection = connection,
                CommandText = $"UPDATE Student " +
                $"SET IndexNumber='{student.IndexNumber}', FirstName='{student.FirstName}', " +
                $"LastName='{student.LastName}', BirthDate='{student.BirthDate}', " +
                $"IdEnrollment={student.IdStudent}" +
                $"WHERE IdEnrollment={idStudent}"
            };
            connection.Open();
            return command.ExecuteNonQuery();
        }
    }
}
