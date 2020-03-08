using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    interface IStudentDao
    {
        Student Add(Student student);
        bool Delete(Student student);
        List<Student> GetAll();
        Student Update(Student student);
        Student GetById(int id);
    }
}
