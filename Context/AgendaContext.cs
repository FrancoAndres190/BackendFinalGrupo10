using BackendFinalGrupo10.Entitys;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackendFinalGrupo10.Context
{
    public class AgendaContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public AgendaContext(DbContextOptions<AgendaContext> options) 
            : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            User user1 = new()
            {
                Id = 1,
                Name = "Franco",
                LastName = "Ligorria",
                Email = "a@gmail.com",
                Password = "12345",
                UserName = "franco12345"
            };

            User user2 = new()
            {
                Id = 2,
                Name = "Olivia",
                LastName = "Luciano",
                Email = "a@gmail.com",
                Password = "12345",
                UserName = "olivia12345"
            };

            User user3 = new()
            {
                Id = 3,
                Name = "Agustin",
                LastName = "Maranzana",
                Email = "a@gmail.com",
                Password = "12345",
                UserName = "agustin12345"
            };

            Contact contact1 = new()
            {
                Id = 1,
                Name = "Andrea",
                Number = "(341) 155-544-333",
                Description = "Mama",
                UserId = user1.Id,
            };

            Contact contact2 = new()
            {
                Id = 2,
                Name = "Ariana",
                Number = "(341) 155-222-333",
                Description = "Novia",
                UserId = user1.Id,
            };

            Contact contact3 = new()
            {
                Id = 3,
                Name = "Victor",
                Number = "(341) 155-111-333",
                Description = "Primo",
                UserId = user2.Id,
            };

            Contact contact4 = new()
            {
                Id = 4,
                Name = "Carlos",
                Number = "(341) 155-544-683",
                Description = "Tio",
                UserId = user3.Id,
            };

            modelBuilder.Entity<User>().HasData(user1, user2, user3);

            modelBuilder.Entity<Contact>().HasData(contact1, contact2, contact3,contact4);

            modelBuilder.Entity<User>().HasMany<Contact>(u => u.Contacts).WithOne(c => c.User);

            base.OnModelCreating(modelBuilder);
        }
    }
}
