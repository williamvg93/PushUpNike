using System;
using System.Collections.Generic;
using System.Reflection;
using Domain.Entities.BusinessMovements;
using Domain.Entities.Inventory;
using Domain.Entities.Location;
using Domain.Entities.Person;
using Domain.Entities.UserAuthenti;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data;

public partial class ApiNikeContext : DbContext
{
    public ApiNikeContext()
    {
    }

    public ApiNikeContext(DbContextOptions<ApiNikeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Addresstype> Addresstypes { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Contacttype> Contacttypes { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Gendertype> Gendertypes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Orderdetail> Orderdetails { get; set; }

    public virtual DbSet<Orderstatus> Orderstatuses { get; set; }

    public virtual DbSet<Paymenttype> Paymenttypes { get; set; }

    public virtual DbSet<Prodcategory> Prodcategories { get; set; }

    public virtual DbSet<Prodcolor> Prodcolors { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Token> Tokens { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userrol> Userrols { get; set; }

    /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=nike;user=root;password=campus2024", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql")); */

    /*     protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            OnModelCreatingPartial(modelBuilder);
        } */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*modelBuilder.Entity<Cliente>()
       .HasOne(a => a.ClienteDireccion)
       .WithOne(b => b.Clientes)
       .HasForeignKey<ClienteDireccion>(b => b.IdCliente);*/

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    /* partial void OnModelCreatingPartial(ModelBuilder modelBuilder); */
}
