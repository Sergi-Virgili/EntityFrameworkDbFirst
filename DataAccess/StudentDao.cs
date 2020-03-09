using Common;
using DataAccess.SQLDataBase;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DataAccess
{
    public class StudentDao : IStudentDao
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(StudentDao));
        public Student Add(Student student)
        {
            log.Info(student.Name + " - Start ADD");
            TableStudent addedStudent;
            try
            {
                using (VuelingDbContext vueling = new VuelingDbContext())
                {
                    var studentTable = new StudentMap().ToStudentTable(student);
                    addedStudent = vueling.TableStudents.Add(studentTable);
                    vueling.SaveChanges();     
                }
            }
            catch (Exception ex)
            {
                log.Error("Exception Message", ex);
                throw;
            }
            log.Info("Student saved");
            return new StudentMap().ToStudent(addedStudent);

        }

        public bool Delete(Student student)
        {
            using (VuelingDbContext vueling = new VuelingDbContext())
            {
                var deleteStudent = vueling.TableStudents.Where(s => s.StudentId == student.StudentId).FirstOrDefault();
                vueling.TableStudents.Remove(deleteStudent);
                vueling.SaveChanges();
            }
            return true;
        }

        public List<Student> GetAll()
        {
            using (VuelingDbContext vueling = new VuelingDbContext())
            {
                var studentsTable = vueling.TableStudents.ToList();
                var students = new List<Student>();
                studentsTable.ForEach(studentTable => students.Add(new StudentMap().ToStudent(studentTable)));
                return students;
            }
        }

        public Student GetById(int id)
        {
            using (VuelingDbContext vueling = new VuelingDbContext())
            {
                var findedStudent = vueling.TableStudents.Where(s => s.StudentId == id).FirstOrDefault();
                return new StudentMap().ToStudent(findedStudent);
            }
        }

        public Student Update(Student student)
        {
            using (VuelingDbContext vueling = new VuelingDbContext())
            {
                var studentUpdate = vueling.TableStudents.Where(s => s.StudentId == student.StudentId).FirstOrDefault();
                var studentUpdated = new StudentMap().ToStudentTable(student);
                vueling.Entry(studentUpdate).CurrentValues.SetValues(studentUpdated);
                vueling.SaveChanges();
                return student;
            }
        }
    }
}
