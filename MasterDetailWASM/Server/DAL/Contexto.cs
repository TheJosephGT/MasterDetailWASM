using MasterDetailWASM.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace MasterDetailWASM.Server.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Venta> Ventas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                    Id = 1,
                    Nombre = "Leche Milex",
                    Precio = 80,
                    Existencia = 100
                },
                new Producto
                {
                    Id = 2,
                    Nombre = "Galletas princesa",
                    Precio = 50,
                    Existencia = 100
                }
            ); // Cierra el bloque para la entidad 'Producto'

            modelBuilder.Entity<Cliente>().HasData(
                new Cliente
                {
                    Id = 1,
                    Nombre = "Joseph"
                },
                new Cliente
                {
                    Id = 2,
                    Nombre = "Jorge"
                }
            ); // Agrega el punto y coma y cierra el bloque para la entidad 'Cliente'
        }

    }
}
