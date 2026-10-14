using System;
using System.Collections.Generic;
using System.Text;

namespace COMEX.Modelos;

internal class Carrinho
{
    public Cliente cliente { get; set; }
    public List<Produto> produtos { get; set; }
}
