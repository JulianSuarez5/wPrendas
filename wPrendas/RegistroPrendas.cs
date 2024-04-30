using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wPrendas
{
    public class clsRegistroPrendas
    {
        public string TipoRopa { get; set; }
        public string Marca { get; set; }
        public string Talla { get; set; }
        public decimal Precio { get; set; }

        public clsRegistroPrendas(string tipoRopa, string marca, string talla, decimal precio)
        {
            TipoRopa = tipoRopa;
            Marca = marca;
            Talla = talla;
            Precio = precio;
        }

        // Método para registrar una nueva prenda en una lista
        public static void Registrar(List<clsRegistroPrendas> Prendas, string tipoRopa, string marca, string talla, decimal precio)
        {
            clsRegistroPrendas Prenda = new clsRegistroPrendas(tipoRopa, marca, talla, precio);
            Prendas.Add(Prenda);
        }
    }
}

