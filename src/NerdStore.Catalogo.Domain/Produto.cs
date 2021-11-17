using NerdStore.Core.DomainObjects;
using System;

namespace NerdStore.Catalogo.Domain
{
    public class Produto : Entity, IAggregateRoot
    {
        public Guid CategiriaId { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool  Ativo { get; private set; }
        public Decimal Valor { get; private set; } 
        public DateTime  DataCadastro { get; private set; }
        public string Imagem { get; private set; }
        public int QuantidadeEstoque { get; private set; }

        public Categoria Categoria { get; private set; }

        public Produto(
            string nome, 
            string descricaom,
            bool ativo,
            Guid categiriaId,
            DateTime dataCadastro,
            string imagem)
        {
            Nome = nome;    
            Descricao = descricaom;
            CategiriaId = categiriaId;
            Ativo = ativo;  
            DataCadastro = dataCadastro;    
            Imagem = imagem;

            Validar();
        }

        public void Ativar() => Ativo = true;

        public void Desativar() => Ativo = false;

        public void AlterarCategoria(Categoria categoria)
        {
            Categoria = categoria;
            CategiriaId = CategiriaId;
        }

        public void AlterarDescricao(string descricao)
        {

            Validacoes.ValidarSeVazio(Descricao, "O campo Descrição do produto não pode estar vazio");
            Descricao = descricao;  
        }

        public void DebitarEstoque(int quantidade)
        {
            if (quantidade < 0) quantidade *= -1;
            if (!PossuiEstoque(quantidade)) throw new DomainException("Estoque insuficiente");
            QuantidadeEstoque -= quantidade;
        }

        public void ReporEstoque(int quantidade)
        {
            QuantidadeEstoque += quantidade;
        }

        public bool PossuiEstoque(int quantidade)
        {
            return QuantidadeEstoque >= quantidade;
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome do produto não pode estar vazio");
            Validacoes.ValidarSeVazio(Descricao, "O campo Descrição do produto não pode estar vazio");
            Validacoes.ValidarSeDiferente(CategiriaId, Guid.Empty, "O campo CategoriaId do porduto não pode ser vazio");
            Validacoes.ValidarSeMaiorIgualMinimo(Valor, 0, "O campo Valor do produto não pode ser menor igual a 0");
            Validacoes.ValidarSeVazio(Imagem, "O campo Imagem do produto não pode estar vazio");
        }
    }
} 
  