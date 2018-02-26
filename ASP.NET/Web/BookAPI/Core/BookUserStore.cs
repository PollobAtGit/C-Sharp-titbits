using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookAPI.DAL;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookAPI.Core
{
    public class BookUserStore : UserStore<IdentityUser>
    {
        public BookUserStore() : base(new BooksContext())
        {

        }
    }
}