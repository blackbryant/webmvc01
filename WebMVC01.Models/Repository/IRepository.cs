using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC01.Models.Repository
{
    public interface IRepository<T>
    {
        T FindById(int id);
        IEnumerable<T> FindAll();
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity); 

    }
}
