using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities.Common;
using ECommerceAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Repositories
{
  public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
  {
    private readonly ECommerceDbContext _context;

    public ReadRepository(ECommerceDbContext context)
    {
      _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public IQueryable<T> GetAll(bool tracking = true)
    //=> Table;  -> Tracking is enabled by default
    // below makes tracking disabled
    {
      var query = Table.AsQueryable();
      if (!tracking)
        query = query.AsNoTracking();
      return query;
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
    //=> Table.Where(method);
    {
      var query = Table.Where(method);
      if (!tracking)
        query = query.AsNoTracking();
      return query;
    }


    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
    //=> await Table.FirstOrDefaultAsync(method);
    {
      var query = Table.AsQueryable();
      if (!tracking)
        query = query.AsNoTracking();
      return await query.FirstOrDefaultAsync(method);
    }


    public async Task<T> GetByIdAsync(string id, bool tracking = true)
    //=> await Table.FindAsync(id);
    //=> await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
    {
      var query = Table.AsNoTracking();
      if(!tracking)
        query = query.AsNoTracking();
      return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
    }
  }
}