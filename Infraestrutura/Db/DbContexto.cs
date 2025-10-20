using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Entidades; 

namespace MinimalApi.Infraestrutura.Db
{
    public class DbContexto : DbContext
    {
        private readonly IConfiguration _configurationAppSettings;
        public DbContexto(IConfiguration configurationAppSettings)
        {
            _configurationAppSettings = configurationAppSettings;
        }
        public DbSet<Administrador> Administradores { get; set; } = default!;
        public DbSet<Veiculo> Veiculos { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>().HasData(
                new Administrador
                {
                    Id = 1,
                    Email = "administrador@teste.com",
                    Senha = "123456",
                    Perfil = "Adm"
                }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var stringDeConexao = _configurationAppSettings.GetConnectionString("MySql")?.ToString();

                if (!string.IsNullOrEmpty(stringDeConexao))
                {
                    optionsBuilder.UseMySql(
                        stringDeConexao,
                        ServerVersion.AutoDetect(stringDeConexao)
                    );
                }
            }
        }
    }
}