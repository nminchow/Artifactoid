﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using Artifact.Models;

namespace Artifact
{
    public class DataBase : DbContext
    {
        public DbSet<Guild> Guilds { get; set; }

        private string _connection;

        public DataBase(string connection) : base()
        {
            _connection = connection;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($@"{_connection}");
        }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataBase>
    {
        public DataBase CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();
            return new DataBase(configuration.GetConnectionString("sql"));
        }
    }

}
