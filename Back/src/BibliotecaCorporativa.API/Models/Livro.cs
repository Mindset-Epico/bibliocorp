namespace BibliotecaCorporativa.API.Models
{
    public class Livro
    {
        public int LivroId { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public int ISBN { get; set; }
        public string Categoria { get; set; }
        public bool Disponibilidade { get; set; }
        public string Capa { get; set; }
    }
}