using Common;
using DataAccess.SQLDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class StudentMap
    {
        
        public TableStudent ToStudentTable(Student student)
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

        public Student ToStudent(TableStudent studentTable)
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

