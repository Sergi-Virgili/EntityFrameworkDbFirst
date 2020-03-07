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
        Student Add(StudentDao student);
        Student Delete(StudentDao student);
        Student GetAll();
        Student Update(StudentDao student);
        Student GetById(int id);
    }
}
