using PhoneBook.Models;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace PhoneBook
{
    public class PhonebookContext: DbContext
    {
        public DbSet<Contact>? Contact { get; set; }

        private static  string dataSource = Environment.GetEnvironmentVariable("DB_DATASOURCE");
        private static string connectionString = ConfigurationManager.AppSettings["PhonebookDBConnection"]
                                  .Replace("{DataSource}", dataSource);


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
