using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    public class Dimencoes
    {
        public Dimencoes(decimal altura, decimal largura, decimal profundidade)
        {
            Altura = altura;
            Largura = largura;
            Profundidade = profundidade;

            Validar();
        }

        public decimal Altura { get; private set; }
        public decimal Largura { get; private set; }
        public decimal Profundidade { get; private set; }


        public void Validar()
        {
            Validacoes.ValidarSeMenorIgualMinimo(Altura, 1, "O campo Altura da categoria não pode ser menor igual a 0");
            Validacoes.ValidarSeMenorIgualMinimo(Largura, 1, "O campo Largura da categoria não pode ser menor igual a 0");
            Validacoes.ValidarSeMenorIgualMinimo(Profundidade, 1, "O campo Profundidade da categoria não pode ser menor igual a 0");
        }

        public string DescricaoFormatada()
        {
            return $"LxAxP: {Largura} x {Altura} x {Profundidade}";

        }
    }
}
