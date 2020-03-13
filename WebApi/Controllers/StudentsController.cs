using Common;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace WebApi.Controllers
{
    public class StudentsController : ApiController
    {
        // GET api/values
        public IEnumerable<Student> Get()
        {
           
            List<Student> studentList =  new StudentDao().GetAll();
            return studentList;
             
        }

        // GET api/values/5
        public Student Get(int id)
        {
            return new StudentDao().GetById(id);
        }

        // POST api/values
        public Student Post([FromBody] Student student)
        {
            Student newStudent = new StudentDao().Add(student);
            return newStudent;
        }

        // PUT api/values/5
        public Student Put( [FromBody] Student student)
        {
            Student updatedStudent = new StudentDao().Update(student);
            return updatedStudent;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            Student deleteStudent = new StudentDao().GetById(id);
            new StudentDao().Delete(deleteStudent);

        }
    }
}
