using NerdStore.Core.DomainObjects;
using System;
using Xunit;

namespace NerdStore.Catalogo.Domain.Test
{
    public class ProdutoTest
    {
        [Fact]
        public void Produto_Validar_ValidacoesDevemRetornarExeptions()
        {
            //Arrange & Act & Assert

            var ex = Assert.Throws<DomainException>(() =>
                new Produto(string.Empty, "Descri��o", false, 100, Guid.NewGuid(), DateTime.Now, "Imagem", new Dimencoes(10, 10, 10))
            );

            Assert.Equal("O campo Nome do produto n�o pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
               new Produto("Nome", "", false, 100, Guid.NewGuid(), DateTime.Now, "Imagem", new Dimencoes(10, 10, 10))
            );

            Assert.Equal("O campo Descri��o do produto n�o pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
               new Produto("Nome", "Descri��o", false, 0, Guid.NewGuid(), DateTime.Now, "Imagem", new Dimencoes(10, 10, 10))
            );

            Assert.Equal("O campo Valor do produto n�o pode ser menor igual a 0", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
               new Produto("Nome", "Descri��o", false, 0, Guid.Empty, DateTime.Now, "Imagem", new Dimencoes(10, 10, 10))
            );

            Assert.Equal("O campo CategoriaId do porduto n�o pode ser vazio", ex.Message);
        }
    }
}
