using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.DTOs;

namespace Minimal_Api.Dominio.Interfaces
{
    public interface IAdministradorServico
    {
        Administrador? Login(LoginDTO loginDTO);
        Administrador AdicionarAdministrador(Administrador administrador);
        List<Administrador> ListarAdministradores(int? pagina);
        Administrador? ObterAdministradorPorId(int id);
    }
}
