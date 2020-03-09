using Common;
using DataAccess.SQLDataBase;
using log4net;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace DataAccess
{
    public class StudentDao : IStudentDao
    {
        private Student addedStudent;
        private static readonly ILog log = LogManager.GetLogger(typeof(StudentDao));
        public Student Add(Student student)
        {
            
            try
            {
                using (VuelingDbContext vueling = new VuelingDbContext())
                {
                    var studentTable =  StudentMap.ToStudentTable(student);
                    var TableAddedStudent = vueling.TableStudents.Add(studentTable);
                    addedStudent = StudentMap.ToStudent(TableAddedStudent);
                    vueling.SaveChanges();     
                }
            }
            catch (DbUpdateException ex)
            {
                log.Error("DataBase Update Exception With Data" + LogMessage.Student(addedStudent), ex);
                throw;
            }
            catch (DbEntityValidationException ex)
            {
                log.Error("Entity Validation Exception With Data" + LogMessage.Student(addedStudent), ex);
                throw;
            }
            catch (NotSupportedException ex)
            {
                log.Error("Action Not Supported With Data" + LogMessage.Student(addedStudent), ex);
                throw;
            }
            log.Info("ADDED: " + LogMessage.Student(addedStudent));
            return addedStudent;
        }

        public bool Delete(Student student)
        {
            try { 
                using (VuelingDbContext vueling = new VuelingDbContext())
                    {
                        var deleteStudent = vueling.TableStudents.Where(s => s.StudentId == student.StudentId).FirstOrDefault();
                        vueling.TableStudents.Remove(deleteStudent);
                        vueling.SaveChanges();
                    }
            }
            catch (ArgumentNullException ex)
            {
                log.Error("Null Argument With Data" + LogMessage.Student(student), ex);
                throw;
            }
            catch (DbUpdateException ex)
            {
                log.Error("DataBase Update Exception With Data" + LogMessage.Student(student), ex);
                throw;
            }
            catch (DbEntityValidationException ex)
            {
                log.Error("Entity Validation Exception With Data" + LogMessage.Student(student), ex);
                throw;
            }
            catch (NotSupportedException ex)
            {
                log.Error("Action Not Supported With Data" + LogMessage.Student(student), ex);
                throw;
            }
            log.Info("DELETED: " + LogMessage.Student(student));
            return true;
        }

        public List<Student> GetAll()
        {
            List<Student> students = new List<Student>();
            try
            {
                using (VuelingDbContext vueling = new VuelingDbContext())
                {
                    var studentsTable = vueling.TableStudents.ToList();
                    studentsTable.ForEach(studentTable => students.Add(StudentMap.ToStudent(studentTable)));
                }
            }
            catch (ArgumentNullException ex)
            {
                log.Error("Null Argument", ex);
                throw;
            }

            log.Info("Get All Students");
            return students;
        }


        public Student GetById(int id)
        {
            try { 
                using (VuelingDbContext vueling = new VuelingDbContext())
                {
                    var findedStudent = vueling.TableStudents.Where(s => s.StudentId == id).FirstOrDefault();
                    return StudentMap.ToStudent(findedStudent);
                }
            }
            catch (ArgumentNullException ex)
            {
                log.Error("Null Argument With Student Id "+ id, ex);
                throw;
            }
        }

        public Student Update(Student student)
        {
            using (VuelingDbContext vueling = new VuelingDbContext())
            {
                var studentUpdate = vueling.TableStudents.Where(s => s.StudentId == student.StudentId).FirstOrDefault();
                var studentUpdated = StudentMap.ToStudentTable(student);
                vueling.Entry(studentUpdate).CurrentValues.SetValues(studentUpdated);
                vueling.SaveChanges();
                return student;
            }
        }
    }
}
