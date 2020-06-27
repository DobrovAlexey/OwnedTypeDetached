using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OwnedTypeDetached.Entities;

namespace OwnedTypeDetached.Db
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<TokenEntity> Tokens { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TokenEntity>().ToTable("Test", "Test");

            builder.Entity<TokenEntity>().HasKey(x => x.Id);

            builder.Entity<TokenEntity>().OwnsOne(o => o.Extension);

            base.OnModelCreating(builder);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            //ChangeTracker.DetectChanges();

            var entries = ChangeTracker.Entries<TokenEntity>().ToList();

            for (int i = 0; i < entries.Count(); i++)
            {
                var entry = entries[i];
                var entryOwns = entry.Entity?.Extension != null ? Entry(entry.Entity?.Extension) : null;

                Debug.WriteLine("Start");

                Debug.WriteLine("{0}: {1}", entry.Entity, entry.State);
                Debug.WriteLine("{0}: {1}", entryOwns?.Entity, entryOwns?.State);

                if (entry.State == EntityState.Added)
                {
                    //entryOwns.Entity.EntityState = 1;
                }

                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;

                    if (entryOwns == null)
                    {
                        entry.Entity.Extension = new Extension();

                        entryOwns = Entry(entry.Entity?.Extension);

                        
                    }


                    if (entryOwns != null)
                    {
                        entryOwns.State = EntityState.Added;

                        entryOwns.Entity.UpdateDate = DateTime.Now;
                        entryOwns.Entity.IsDelete = true;

                        entryOwns.Entity.EntityState = 4;
                    }


                    Debug.WriteLine("State change");

                    Debug.WriteLine("{0}: {1}", entry.Entity, entry.State);
                    Debug.WriteLine("{0}: {1}", entryOwns?.Entity, entryOwns?.State);
                }


                Debug.WriteLine("End");
            }

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

    }
}