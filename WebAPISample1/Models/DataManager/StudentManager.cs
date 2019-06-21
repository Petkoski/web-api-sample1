using System;
using System.Linq;
using WebAPISample1.Models.Repository;

namespace WebAPISample1.Models.DataManager
{
    public class StudentManager : IStudentRepository<Student>
    {
        readonly EntityContext _context;

        public StudentManager(EntityContext context)
        {
            _context = context;
        }

        public IQueryable GetAll()
        {
            return _context.Students;
        }

        public Student Get(int id)
        {
            return _context.Students.FirstOrDefault(e => e.Id == id);
        }

        public Student Add(Student entity)
        {
            _context.Students.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Update(Student entityToUpdate, Student entity)
        {
            entityToUpdate.FirstName = entity.FirstName;
            entityToUpdate.LastName = entity.LastName;
            _context.SaveChanges();
        }

        public void Delete(Student entity)
        {
            _context.Students.Remove(entity);
            _context.SaveChanges();
        }
    }
}