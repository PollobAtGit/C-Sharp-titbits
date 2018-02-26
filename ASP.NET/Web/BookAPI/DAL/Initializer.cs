using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookAPI.DAL
{
    public class Initializer : MigrateDatabaseToLatestVersion<BooksContext, Configuration>
    {
    }
}