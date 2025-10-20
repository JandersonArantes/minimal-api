using MinimalApi.Dominio.Entidades;

namespace Minimal_Api.Dominio.Interfaces
{
    public interface IVeiculoServico
    {
        List<Veiculo> ListarVeiculos(int? pagina = 1, string? nome = null, string? marca = null);

        Veiculo? ObterVeiculoPorId(int id);

        void AdicionarVeiculo(Veiculo veiculo);

        void AtualizarVeiculo(Veiculo veiculo);

        void RemoverVeiculo(Veiculo veiculo);
    }
}