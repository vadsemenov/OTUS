using System;
using Npgsql;

namespace Database
{

    class Program
    {
        static void Main(string[] args)
        {

            var tablesName = new string[] { "teachers", "students", "schedule", "courses" };
            DBReadTables readTables = new DBReadTables(DBConnectionString.GetConnectionString());
            DBWriteTables writeTables = new DBWriteTables(DBConnectionString.GetConnectionString());
            ConsoleKey consoleKey;

            Console.WriteLine("------------Программа для работы с БД PostgreSQL----------");

            while (true)
            {
                Console.WriteLine("1 - Вывести все таблицы");
                Console.WriteLine("2 - Добавить запись в таблицу teachers");
                Console.WriteLine("3 - Добавить запись в таблицу students");
                Console.WriteLine("4 - Добавить запись в таблицу schedule");
                Console.WriteLine("5 - Добавить запись в таблицу courses");
                Console.WriteLine("6 - Завершить работу");

                consoleKey = Console.ReadKey(true).Key;

                if (consoleKey == ConsoleKey.D1)
                    readTables.GetTables(tablesName);

                if (consoleKey == ConsoleKey.D2)
                    ConsoleInputRecordsToDB.AddRecordToTeachersTable();

                if (consoleKey == ConsoleKey.D3)
                    ConsoleInputRecordsToDB.AddRecordToStudentsTable();

                if (consoleKey == ConsoleKey.D4)
                    ConsoleInputRecordsToDB.AddRecordToScheduleTable();

                if (consoleKey == ConsoleKey.D5)
                    ConsoleInputRecordsToDB.AddRecordToCoursesTable();

                if (consoleKey == ConsoleKey.D6)
                    return;
            }

        }
    }


}
