﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using UserNotifications.Models;

namespace UserNotifications.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<EventHistory> EventHistory { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //User - Mapping property
            modelBuilder.Entity<User>().HasKey(c => c.Id); //configurando uma chave primária

            modelBuilder.Entity<User>()
                .Property(u => u.FullName)
                .HasMaxLength(150)
                .HasColumnType("varchar")
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.CreateAt)
                .IsRequired()
                .IsConcurrencyToken(); //propriedade a ser usada como um token de simultaneidade. Se o valor tiver sido alterado por outra transação,lança uma exceção.


            //Subscription - Mapping property

            modelBuilder.Entity<Subscription>().HasKey(c => c.Id);

            modelBuilder.Entity<Subscription>()
                .Property(s => s.UserId)
                .IsRequired();

            modelBuilder.Entity<Subscription>()
                .HasOne(u => u.User)
                .WithOne(s => s.Subscription)
                .HasForeignKey<Subscription>(s => s.UserId)
                .IsRequired();

            modelBuilder.Entity<Subscription>()
                .Property(s => s.StatusId)
                .IsRequired();

            modelBuilder.Entity<Subscription>()
                .HasOne(s => s.Status)
                .WithOne(s => s.Subscription)
                .HasForeignKey<Subscription>(s => s.StatusId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Subscription>()
                .Property(s => s.CreatedAt)
                .IsRequired()
                .IsConcurrencyToken();

            modelBuilder.Entity<Subscription>()
                .Property(s => s.UpdateAt)
                .IsRequired();
            


            //Status - Mapping property
            modelBuilder.Entity<Status>().HasKey(s => s.Id);


            modelBuilder.Entity<Status>()
                .Property(s => s.StatusName)
                .HasColumnType("varchar")
                .IsRequired();


            //EventHistory - Mapping property

            modelBuilder.Entity<EventHistory>().HasKey(e => e.Id);

            modelBuilder.Entity<EventHistory>()
                .Property(e => e.SubscriptionId)
                .IsRequired();

            modelBuilder.Entity<EventHistory>()
                .HasOne(e => e.Subscription)
                .WithMany(e => e.EventHistory)
                .HasForeignKey(e => e.SubscriptionId);

            modelBuilder.Entity<EventHistory>()
                .Property(e => e.Type)  //compra, cancel, reativação
                .HasColumnType("varchar")
                .IsRequired();

            modelBuilder.Entity<EventHistory>()
                .Property(s => s.CreatedAt)
                .IsConcurrencyToken()
                .IsRequired();

        }
    }
}