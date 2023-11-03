using Micro.Data.Domain.Dtos;
using Micro.Data.Domain.Entities;
using Micro.Data.Domain.Interfaces.Repository;
using Micro.Data.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Data.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;        

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
            
        }

        public async Task<ProdutoDto> Consultar(int id)
        {
            var _produtos = await _repository.Consultar(id);
            ProdutoDto newProdutoDto = new ProdutoDto();

            if (_produtos != null)
            {
                newProdutoDto.Id = _produtos.Id;
                newProdutoDto.CodidoProduto = _produtos.CodidoProduto;
                newProdutoDto.Valor = _produtos.Valor;
            }

            return newProdutoDto;
        }
        public async Task<bool> Create(ProdutoDto produtoDto)
        {
            Produto _produto = new Produto();

            if (produtoDto != null)
            {
                _produto.Id = produtoDto.Id;
                _produto.CodidoProduto = produtoDto.CodidoProduto;
                _produto.Valor = produtoDto.Valor;
                try
                {
                    await _repository.Create(_produto);

                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        public async Task<bool> Edit(ProdutoDto produtoDto)
        {
            if (produtoDto != null)
            {
                if (produtoDto.Id > 0)
                {
                    Produto produto = new Produto();

                    produto.Id = produtoDto.Id;
                    produto.CodidoProduto = produtoDto.CodidoProduto;
                    produto.Valor = produtoDto.Valor;

                    try
                    {
                        await _repository.Edit(produto);

                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
                return false;
            }

            return false;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    await _repository.Delete(id);
                    return true;
                }
                else
                {
                    return false;
                }
            } catch { return false; }
        }

        public async Task<IList<ProdutoDto>> ListProdutos()
        {
            var lista = await _repository.ListProdutos();

            IList<ProdutoDto> listaRetorno = new List<ProdutoDto>();

            foreach (Produto _produto in lista)
            {
                ProdutoDto newConta = new ProdutoDto();
                newConta.Id = _produto.Id;
                newConta.CodidoProduto = _produto.CodidoProduto;
                newConta.Valor = _produto.Valor;

                listaRetorno.Add(newConta);
            }

            return listaRetorno;
        }

        public async Task<ItemPedidoDto> ConsultarPorItemPedido(int id)
        {
            var itenm = await _repository.ConsultarPorItemPedido(id);
            ItemPedidoDto dto = new ItemPedidoDto();

            if (itenm != null)
            {
                dto.Id = itenm.Id;
                dto.IdPedido = itenm.IdPedido;
                dto.IdProduto = itenm.IdProduto;
                dto.Quantidade = itenm.Quantidade;
                dto.ValorTotal = itenm.ValorTotal;
            }
            return dto;
        }
    }

   
}
