using Microsoft.EntityFrameworkCore;
using Minimal_Api.Dominio.Interfaces;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Infraestrutura.Db;

namespace Minimal_Api.Dominio.Servicos
{
    public class VeiculoServico : IVeiculoServico
    {
        private readonly DbContexto _contexto;
        public VeiculoServico(DbContexto contexto)
        {
            _contexto = contexto;

        }

        public void AdicionarVeiculo(Veiculo veiculo)
        {
            _contexto.Veiculos.Add(veiculo);
            _contexto.SaveChanges();
        }

        public void AtualizarVeiculo(Veiculo veiculo)
        {
            _contexto.Veiculos.Update(veiculo);
            _contexto.SaveChanges();
        }

        public List<Veiculo> ListarVeiculos(int? pagina = 1, string? nome = null, string? marca = null)
        {

            var query = _contexto.Veiculos.AsQueryable();

            if (!string.IsNullOrEmpty(nome))
            {
                query = query.Where(v => EF.Functions.Like(v.Nome.ToLower(), $"%{nome.ToLower()}%"));

            }

            int itensPorPagina = 10;

            if (pagina != null)
            {
                query = query.Skip(((int)pagina - 1) * itensPorPagina).Take(itensPorPagina);
            }
            

            return query.ToList();

            // int tamanhoPagina = 10;
            // int pular = (pagina - 1) * tamanhoPagina;

            // var query = _contexto.Veiculos.AsQueryable();

            // if (!string.IsNullOrEmpty(nome))
            // {
            //     query = query.Where(v => v.Nome.Contains(nome));
            // }

            // if (!string.IsNullOrEmpty(marca))
            // {
            //     query = query.Where(v => v.Marca.Contains(marca));
            // }

            // return query.Skip(pular).Take(tamanhoPagina).ToList();
        }

        public Veiculo? ObterVeiculoPorId(int id)
        {
            return _contexto.Veiculos.Where(v => v.Id == id).FirstOrDefault();
            // return _contexto.Veiculos.Find(id) ?? throw new Exception("Veículo não encontrado");
        }

        public void RemoverVeiculo(Veiculo veiculo)
        {
            _contexto.Veiculos.Remove(veiculo);
            _contexto.SaveChanges();
        }
    }
}