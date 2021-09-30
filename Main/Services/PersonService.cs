using AnnotationValidator;
using DataAccessObject;
using Domain.Entities;
using Domain.Interfaces;
using Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class PersonService : BaseValidator<Person>, IEntityService<Person>
    {
        public Result Insert(Person person)
        {
            var response = this.Validate(person);
            if (!response.Success)
            {
                return response;
            }

            try
            {
                using (var db = new ErpDbContext())
                {
                    db.People.Add(person);
                    db.SaveChanges();
                }
                return ResultFactory.CreateSuccessResult();
            }
            catch (Exception)
            {
                return ResultFactory.CreateFailureResult();
            }
           
        }

        public DataResult<Person> GetAll()
        {
            try
            {
                using (var db = new ErpDbContext())
                {
                    return ResultFactory.CreateSuccessDataResult(db.People.ToList());
                }
            }
            catch (Exception)
            {
                throw;
            }  
        }

        public Person GetById(int id)
        {
            try
            {
                using (var db = new ErpDbContext())
                {
                    return db.People.Find(id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public void Delete(int id)
        {
            try
            {
                using (var db = new ErpDbContext())
                {
                    db.People.Remove(db.People.Find(id));
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Person person)
        {
            var response = this.Validate(person);
            if (!response.Success)
            {
                return;
            }

            try
            {
                using(var db = new ErpDbContext())
                {
                    db.People.Update(person);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
