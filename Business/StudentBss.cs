using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class StudentBss
    {
        public Student Add(Student student)
        {
            //TODO: Add GUID
            var AddedStudent = new StudentDao().Add(student);
            return AddedStudent;
        }

        public bool Delete(Student student)
        {
            new StudentDao().Add(student);
            return true;
        }

        public List<Student> GetAll()
        {
            //TODO: Calculate AGE
            var studentsList = new StudentDao().GetAll();
            return studentsList;
        }

        public Student GetById(int id)
        {
            //TODO: Calculate AGE
            var student = new StudentDao().GetById(id);
            return student;
        }

        public Student Update(Student student)
        {
            var updatedStudent = new StudentDao().Update(student);
            return updatedStudent;
        }
    }
}
