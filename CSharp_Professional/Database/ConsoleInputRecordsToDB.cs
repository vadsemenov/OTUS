using System;

namespace Database
{
    class ConsoleInputRecordsToDB
    {
        public static void AddRecordToStudentsTable()
        {
            DBWriteTables writeTables = new DBWriteTables(DBConnectionString.GetConnectionString());
            Console.WriteLine("--------------Добавление записи в таблицу students------------------");

            Console.WriteLine("Введите ID студента:");
            int studentId;
            if (!Int32.TryParse(Console.ReadLine(), out studentId))
                return;

            Console.WriteLine("Введите имя студента:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Введите фамилию студента:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Введите отчество студента:");
            string middleName = Console.ReadLine();

            Console.WriteLine("Введите email студента:");
            string email = Console.ReadLine();

            Console.WriteLine("Введите ID курса студента:");
            int courseID;
            if (!Int32.TryParse(Console.ReadLine(), out courseID))
                return;

            writeTables.WriteToStudentsTable(studentId, firstName, lastName, middleName, email, courseID);
            Console.WriteLine("--------------------------------");
        }

        public static void AddRecordToTeachersTable()
        {
            DBWriteTables writeTables = new DBWriteTables(DBConnectionString.GetConnectionString());
            Console.WriteLine("--------------Добавление записи в таблицу teachers------------------");

            Console.WriteLine("Введите ID учителя:");
            int teacherId;
            if (!Int32.TryParse(Console.ReadLine(), out teacherId))
                return;

            Console.WriteLine("Введите имя учителя:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Введите фамилию учителя:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Введите отчество учителя:");
            string middleName = Console.ReadLine();

            Console.WriteLine("Введите email учителя:");
            string email = Console.ReadLine();

            Console.WriteLine("Введите ID курса учителя:");
            int courseID;
            if (!Int32.TryParse(Console.ReadLine(), out courseID))
                return;

            writeTables.WriteToTeachersTable(teacherId, firstName, lastName, middleName, email, courseID);
            Console.WriteLine("--------------------------------");
        }

        public static void AddRecordToCoursesTable()
        {
            DBWriteTables writeTables = new DBWriteTables(DBConnectionString.GetConnectionString());
            Console.WriteLine("--------------Добавление записи в таблицу courses------------------");
            Console.WriteLine("Введите ID курса:");
            int courseId;
            if (!Int32.TryParse(Console.ReadLine(), out courseId))
                return;

            Console.WriteLine("Введите название курса:");
            string courseName = Console.ReadLine();


            writeTables.WriteToCoursesTable(courseId, courseName);
            Console.WriteLine("--------------------------------");
        }

        public static void AddRecordToScheduleTable()
        {
            DBWriteTables writeTables = new DBWriteTables(DBConnectionString.GetConnectionString());
            Console.WriteLine("--------------Добавление записи в таблицу schedule------------------");


            Console.WriteLine("Введите дату: (Пример: 10/10/2021)");
            DateTime dateTime;
            if (!DateTime.TryParse(Console.ReadLine(), out dateTime))
                return;

            Console.WriteLine("Введите ID курса:");
            int courseId;
            if (!Int32.TryParse(Console.ReadLine(), out courseId))
                return;

            Console.WriteLine("Введите ID учителя:");
            int teacherID;
            if (!Int32.TryParse(Console.ReadLine(), out teacherID))
                return;

            writeTables.WriteToScheduleTable(dateTime, courseId, teacherID);
            Console.WriteLine("--------------------------------");
        }
    }
}