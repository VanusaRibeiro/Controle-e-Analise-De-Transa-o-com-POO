using System;
using System.Collections.Generic;
using System.Linq;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
string entradaLimite = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
if (entradaLimite == null || !decimal.TryParse(entradaLimite, out decimal limite))
{
    return;
}

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
string entradaQuantidade = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
if (entradaQuantidade == null || !int.TryParse(entradaQuantidade, out int quantidade) || quantidade <= 0)
{
    return;
}

var cartaoCorporativo = new CartaoCorporativo(limite);

for (int i = 0; i < quantidade; i++)
{
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
    string entradaValor = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
    if (entradaValor == null || !decimal.TryParse(entradaValor, out decimal valor))
    {
        i--; // repete a iteração
        continue;
    }

    cartaoCorporativo.AdicionarTransacao(valor);
}

cartaoCorporativo.ExibirResumo();

class CartaoCorporativo
{
    private decimal limite;
    private List<decimal> transacoes;

    public CartaoCorporativo(decimal limite)
    {
        this.limite = limite;
        transacoes = new List<decimal>();
    }

    public void AdicionarTransacao(decimal valor)
    {
        transacoes.Add(valor);
    }

    public void ExibirResumo()
    {
        var suspeitas = transacoes.Where(t => t > limite).ToList();

        if (suspeitas.Count == 0)
        {
            Console.WriteLine("Nenhuma transacao suspeita encontrada.");
        }
        else
        {
            Console.WriteLine($"Transacoes suspeitas: {suspeitas.Sum():F2}");

            string texto = suspeitas.Count == 1 ? "transacao suspeita" : "transacoes suspeitas";
            Console.WriteLine($"{suspeitas.Count} {texto}");
        }
    }
}
