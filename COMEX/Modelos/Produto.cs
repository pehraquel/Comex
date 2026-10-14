namespace COMEX.Modelos;

class Produto
{
    public Produto(string nome)
    {
        Nome = nome;
    }

    public string Nome { get; set; }

    public double PrecoUnitario { get; set; }

    public int Quantidade { get; set; }
}
