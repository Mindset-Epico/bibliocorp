using BibliotecaCorporativa.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaCorporativa.API.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Livro> Livros { get; set; }


        //ADDED: FIX para a Injeção de Dependencia da Base de Dados no Program.cs
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json")
                .Build();

            var connectionString = configuration.GetConnectionString("Default");
            optionsBuilder.UseSqlite(connectionString);
    }
    }
}