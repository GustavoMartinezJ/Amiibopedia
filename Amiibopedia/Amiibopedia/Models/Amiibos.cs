namespace Amiibopedia.Models
{

    public class Platillos
    {
        public Platillo[] food2u { get; set; }
    }

    public class Platillo
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string imagen_1 { get; set; }
        public string imagen_2 { get; set; }
        public string imagen_3 { get; set; }
        public Ingrediente[] ingredientes { get; set; }
        public Receta receta { get; set; }
    }

    public class Ingrediente
    {
        public string nombre { get; set; }
        public string cantidad { get; set; }
        public string imagen { get; set; }
    }

    public class Receta
    {
        public int tiempo { get; set; }
        public string pasos { get; set; }
        public Categoria[] categorias { get; set; }
    }

    public class Categoria
    {
        public string nombre { get; set; }
    }
}
