using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhonesManager.DbContexts;
using PhonesManager.Entities;

namespace PhonesManager.Repositories
{
    public class EFRepository<TEntity> where TEntity : Entity
    {
        private readonly PhoneOperatorContext _context;
        protected DbSet<TEntity> Entities => _context.Set<TEntity>();

        public EFRepository( PhoneOperatorContext context )
        {
            _context = context;

        }

        public List<TEntity> GetAll() => Entities.ToList();

        public TEntity GetById( int id ) => Entities.Find( id );

        public void Create( TEntity item )
        {
            Entities.Add( item );
        }

        public void Remove( TEntity item )
        {
            Entities.Remove( item );
        }
    }
}
