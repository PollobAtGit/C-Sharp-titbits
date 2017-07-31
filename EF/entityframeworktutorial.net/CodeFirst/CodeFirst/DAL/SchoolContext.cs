﻿using System.Data.Entity;
using CodeFirst.Model;

namespace CodeFirst.DAL
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base()
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Standard> Standards { get; set; }
    }
}
