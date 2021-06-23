using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonesManager
{
    public interface IRepository<T> where T : class
    {
        public List<T> GetAll();
        public T Get( int id );
        public void Create( T entity );
        public void Update( T entity );
        public void Delete( int id );
    }
}