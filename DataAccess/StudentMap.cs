using Common;
using DataAccess.SQLDataBase;


namespace DataAccess
{
    public static class StudentMap
    { 
        public static TableStudent ToStudentTable(Student student)
        {
            var studentTable = new TableStudent()

            {
                StudentId = student.StudentId,
                Name = student.Name,
                Surname = student.Surname,
                Birthday = student.AgeOfBirth
            };

            return studentTable;
        }

        public static Student ToStudent(TableStudent studentTable)
        {
            var student = new Student()
            {
                StudentId = studentTable.StudentId,
                Name = studentTable.Name,
                Surname = studentTable.Surname,
                AgeOfBirth = studentTable.Birthday
            };
            return student;
        }

    }
}

