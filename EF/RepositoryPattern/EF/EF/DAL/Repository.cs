namespace EF.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Data;
    using System.Threading.Tasks;

    public class Repository<TModel> : IRepository<TModel>, IDisposable where TModel : class
    {
        private readonly SchoolContext _context;
        private readonly DbSet<TModel> _modelSet;
        private bool _isDisposed;

        public Repository(SchoolContext context)
        {
            _context = context;

            // POI: What's the point of using .Set<TModel>? We can simply use the property from context
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

        public async void SaveAsync()
        {
            // POI: Task.Run can be used to avoid the compilation error that says void return type can't be aysnc
            await Task.Run(() =>
            {
                _context.SaveChangesAsync();
            });
        }

        public void Update(TModel model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }


        protected virtual void Dispose(bool isDisposeNow)
        {
            if (isDisposeNow & !_isDisposed)
            {
                _context.Dispose();
                _isDisposed = true;
            }
        }

        // POI: Dispose is private
        void IDisposable.Dispose()
        {
            Dispose(true);
        }
    }
}

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
