namespace EF.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<TModel> where TModel : class
    {
        //DbContext Context { get; set; }

        IEnumerable<TModel> Get(Expression<Func<TModel, bool>> filter = null, Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null);
        TModel GetByID(int id);
        void Insert(TModel model);
        void Delete(TModel model);
        void Update(TModel model);
        void Save();

    }
}