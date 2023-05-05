using DataAccess.Abstract;
using Entities.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public IRepository<Product> ProductRepository { get; }
       

        public UnitOfWork(DbContext context, IRepository<Product> productRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            ProductRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }

    public interface IUnitOfWork
    {
    }
}
