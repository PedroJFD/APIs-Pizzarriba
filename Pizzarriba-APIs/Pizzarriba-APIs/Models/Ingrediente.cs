namespace IngredienteAPI.Models
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Fornecedor { get; set; }
        public string Medida { get; set; }
        public double Quantidade { get; set; }

    }
}
