using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_ComplexEx.Models
{
    public interface IRepository<T> where T:IEntity
    {
        void Add(T item);
        void Delete(int id);
        void Edit(T item);
        IEnumerable<T> GetList();
        T getById(int id);
        int Length { get; }
    }
}
