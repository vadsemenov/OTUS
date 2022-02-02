using System;
using System.Data;
using Npgsql;
using NpgsqlTypes;

namespace Database
{
    public class DBWriteTables
    {
        private string _connectionString;

        public DBWriteTables(string connectionString)
        {
            _connectionString = connectionString;
        }

        //https://www.npgsql.org/doc/basic-usage.html
        public void WriteToCoursesTable(int courseId, string courseName)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            using var transaction = connection.BeginTransaction();
            try
            {
                var sql = @"
                            INSERT INTO courses(course_id, course_name) 
                            VALUES (:course_id, :course_name)
                            RETURNING course_id;
                            ";
                using var cmd1 = new NpgsqlCommand(sql, connection);
                var parameters = cmd1.Parameters;
                parameters.Add(new NpgsqlParameter("course_id", courseId));
                parameters.Add(new NpgsqlParameter("course_name", courseName));

                var clientId = (int)cmd1.ExecuteScalar();
                Console.WriteLine($"Insert into courses table. ClientId = {clientId}");

                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                Console.WriteLine(e.Message);
                Console.WriteLine($"Rolled back the transaction");
                return;
            }
        }



        public void WriteToTeachersTable(int teacherId, string firstName, string lastName, string middleName, string email, int courseID)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            using var transaction = connection.BeginTransaction();
            try
            {
                var sql = @"
                            INSERT INTO teachers(teacher_id, first_name, last_name, middle_name, email, course) 
                            VALUES (:teacher_id, :first_name, :last_name, :middle_name, :email, :course)
                            RETURNING teacher_id;
                            ";

                using var cmd1 = new NpgsqlCommand(sql, connection);
                var parameters = cmd1.Parameters;
                parameters.Add(new NpgsqlParameter("teacher_id", teacherId));
                parameters.Add(new NpgsqlParameter("first_name", firstName));
                parameters.Add(new NpgsqlParameter("last_name", lastName));
                parameters.Add(new NpgsqlParameter("middle_name", middleName));
                parameters.Add(new NpgsqlParameter("email", email));
                parameters.Add(new NpgsqlParameter("course", courseID));


                var teachersId = (int)cmd1.ExecuteScalar();
                Console.WriteLine($"Insert into teachers table. TeacherId = {teachersId}");

                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                Console.WriteLine(e.Message);
                Console.WriteLine($"Rolled back the transaction");
                return;
            }
        }


        public void WriteToStudentsTable(int studentId, string firstName, string lastName, string middleName, string email, int courseID)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            using var transaction = connection.BeginTransaction();
            try
            {
                var sql = @"
                            INSERT INTO students(student_id, first_name, last_name, middle_name, email, course) 
                            VALUES (:student_id, :first_name, :last_name, :middle_name, :email, :course)
                            RETURNING student_id;
                            ";

                using var cmd1 = new NpgsqlCommand(sql, connection);
                var parameters = cmd1.Parameters;
                parameters.Add(new NpgsqlParameter("student_id", studentId));
                parameters.Add(new NpgsqlParameter("first_name", firstName));
                parameters.Add(new NpgsqlParameter("last_name", lastName));
                parameters.Add(new NpgsqlParameter("middle_name", middleName));
                parameters.Add(new NpgsqlParameter("email", email));
                parameters.Add(new NpgsqlParameter("course", courseID));

                var studId = (int)cmd1.ExecuteScalar();
                Console.WriteLine($"Insert into students table. ClientId = {studId}");

                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                Console.WriteLine(e.Message);
                Console.WriteLine($"Rolled back the transaction");
                return;
            }
        }


        public void WriteToScheduleTable(DateTime lessonDate, int course, int teacher)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            using var transaction = connection.BeginTransaction();
            try
            {
                var sql = @"
                            INSERT INTO schedule(lesson_date, course, teacher ) 
                            VALUES (:lesson_date, :course, :teacher );";


                using var cmd1 = new NpgsqlCommand(sql, connection);
                var parameters = cmd1.Parameters;
                var paramDate = new NpgsqlParameter("lesson_date", NpgsqlDbType.Date);
                paramDate.Value = lessonDate;
                parameters.Add(paramDate);
                parameters.Add(new NpgsqlParameter("course", course));
                parameters.Add(new NpgsqlParameter("teacher", teacher));

                cmd1.ExecuteScalar();
                Console.WriteLine($"Insert into schedule table.");

                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                Console.WriteLine(e.Message);
                Console.WriteLine($"Rolled back the transaction");
                return;
            }
        }

    }
}