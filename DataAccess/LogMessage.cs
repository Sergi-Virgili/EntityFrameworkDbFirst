using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class LogMessage
    {
         public static string Student(Student student)
        {
            string message = $"Student: id = {student.StudentId}, Name = {student.Name}, Surname = {student.Surname}, Birth = {student.AgeOfBirth.Date}";
            return message;
        } 
    }
}
