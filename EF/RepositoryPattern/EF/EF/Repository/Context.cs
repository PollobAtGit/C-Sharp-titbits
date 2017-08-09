namespace EF.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SchoolContext<TModel> : DbContext where TModel : class
    {
        public SchoolContext()
        {

        }

        DbSet<TModel>
    }
}
