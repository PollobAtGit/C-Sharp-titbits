namespace EF.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Data;

    public class SchoolRepository<TModel> : IRepository<TModel> where TModel : class
    {
        private readonly SchoolContext _context;
        private readonly DbSet<TModel> _modelSet;

        // POI: Making Context private
        // TODO: Why can't we access this contex in constructor?
        //DbContext IRepository<Student>.Context
        //{
        //    get
        //    {
        //        return _context;
        //    }

        //    set
        //    {
        //        if (_context == null && !(_context is SchoolContext) && value != null && value is SchoolContext)
        //        {
        //            _context = value as SchoolContext;
        //        }
        //    }
        //}

        public SchoolRepository(SchoolContext context)
        {
            _context = context;
            _modelSet = _context.Set<TModel>();
        }

        public void Delete(TModel model)
        {
            if (_context.Entry(model).State == EntityState.Detached)
            {
                _modelSet.Attach(model);
            }
            _modelSet.Remove(model);
        }

        public TModel GetByID(int id)
        {
            return _modelSet.Find(id);
        }

        public IEnumerable<TModel> Get(Expression<Func<TModel, bool>> filter = null,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null)
        {
            var queryFilter = filter != null ? _modelSet.Where(filter) : _modelSet;
            var queryOrder = (orderBy != null ? orderBy(queryFilter) : queryFilter) as IOrderedQueryable<TModel>;

            return queryOrder.ToList();
        }

        public void Insert(TModel model)
        {
            _modelSet.Add(model);
        }

        public void Save()
        {
            _context.SaveChangesAsync();
        }

        public void Update(TModel model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }
    }
}
