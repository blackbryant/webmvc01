using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC01.Models.Repository
{
    public class EntityRepository<T> : IRepository<T> where T : class
    {
        protected KangtingBizModel _model ;

        public EntityRepository()
        {
            _model = new KangtingBizModel();

        }


        public int Add(T entity)
        {
            _model.Set<T>().Add(entity);
            int result = _model.SaveChanges();
            return result; 
        }

        public int  Delete(T entity)
        {
            _model.Set<T>().Remove(entity);
            int result = _model.SaveChanges();
            return result;
        }

        public IEnumerable<T> FindAll()
        {
           return  _model.Set<T>(); 
        }

        public T FindById(int id)
        {
            return _model.Set<T>().Find(id);
        }

        public int Update(T entity)
        {
            var entry = _model.Entry(entity);
            _model.Set<T>().Attach(entity);
            entry.State = System.Data.Entity.EntityState.Modified;
            int result = _model.SaveChanges();
            return result;
        }
    }
}
