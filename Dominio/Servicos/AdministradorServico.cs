using Minimal_Api.Dominio.Interfaces;
using MinimalApi.Dominio.DTOs;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Infraestrutura.Db;

namespace Minimal_Api.Dominio.Servicos
{
    public class AdministradorServico : IAdministradorServico
    {
        private readonly DbContexto _contexto;
        public AdministradorServico(DbContexto contexto)
        {
            _contexto = contexto;

        }

        public Administrador AdicionarAdministrador(Administrador administrador)
        {
            _contexto.Administradores.Add(administrador);
            _contexto.SaveChanges();
            return administrador;
        }

        public Administrador? Login(LoginDTO loginDTO) => _contexto.Administradores.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();

        public List<Administrador> ListarAdministradores(int? pagina)
        {
            var query = _contexto.Administradores.AsQueryable();

            int itensPorPagina = 10;

            if (pagina != null)
            {
                query = query.Skip(((int)pagina - 1) * itensPorPagina).Take(itensPorPagina);
            }

            return query.ToList();
        }

        public Administrador? ObterAdministradorPorId(int id)
        {
            return _contexto.Administradores.Where(a => a.Id == id).FirstOrDefault();
        }
    }
}