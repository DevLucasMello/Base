using System.Data.Entity.Migrations;
using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.Base
{

    /// <summary>
    /// Class to abstract data manipulation
    /// </summary>
    /// <typeparam name="T">Type of Entity</typeparam>
    public class PersistentRepository<T> where T : PersistentEntity
    {

        internal DbContext context;
        internal DbSet<T> set;

        public PersistentRepository(DbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        /// <summary>
        /// Get a single item based on id field
        /// </summary>
        /// <param name="id">ID of item</param>
        /// <returns>Single entity</returns>
        public virtual T Get(int id)
        {
            return this.set.SingleOrDefault(i => i.ID == id);
        }

        /// <summary>
        /// List of items based on expression
        /// </summary>
        /// <param name="expression">Linq expression to be used in the query</param>
        /// <returns>List of entities</returns>
        public virtual IQueryable<T> GetByExpression(Expression<Func<T, bool>> expression)
        {
            return this.set.Where(expression);
        }

        /// <summary>
        /// List of all items
        /// </summary>
        /// <returns>List of entities</returns>
        public virtual IQueryable<T> GetAll()
        {
            return this.set;
        }

        /// <summary>
        /// Save a new or existing item
        /// </summary>
        /// <param name="entity">Entity that was saved</param>
        public virtual void Save(T entity)
        {
            if (entity.ID == 0)
            {
                entity.DataCriacao = DateTime.Now;
            }
            entity.DataAlteracao = DateTime.Now;
            this.context.Set<T>().AddOrUpdate(entity);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Delete an item based on id
        /// </summary>
        /// <param name="id">ID of Entity</param>
        public virtual void Delete(int id)
        {
            Delete(Get(id));
        }

        /// <summary>
        /// Delete an item based on entity
        /// </summary>
        /// <param name="entity">Entity to be deleted</param>
        public virtual void Delete(T entity)
        {
            this.set.Remove(entity);
            this.context.SaveChanges();
        }

    }
}