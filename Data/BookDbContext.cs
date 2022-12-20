using BookShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options)
            : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}