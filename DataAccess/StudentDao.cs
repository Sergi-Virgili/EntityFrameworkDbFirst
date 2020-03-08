﻿using Common;
using DataAccess.SQLDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class StudentDao : IStudentDao
    {
        public Student Add(Student student)
        {
            using (VuelingDbContext vueling = new VuelingDbContext())
            {
                var studentTable = new StudentMap().ToStudentTable(student);
                vueling.TableStudents.Add(studentTable);
                vueling.SaveChanges();
                return student;
            }
        }

        public bool Delete(Student student)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAll()
        {
            throw new NotImplementedException();
        }

        public Student GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Student Update(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
