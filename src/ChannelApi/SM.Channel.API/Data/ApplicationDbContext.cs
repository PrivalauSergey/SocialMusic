using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SM.Channel.API.Data.Entities;
using System;
using ChannelEntity = SM.Channel.API.Data.Entities.Channel;

namespace SM.Channel.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<AspNetUser> AspNetUsers { get; set; }

        public DbSet<ChannelEntity> Channels { get; set; }

        public DbSet<ChannelUser> ChannelUsers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ChannelUser>()
                .HasIndex(cu => new { cu.ChannelId, cu.UserId })
                .IsUnique();
        }
    }
}