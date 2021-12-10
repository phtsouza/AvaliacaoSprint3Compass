namespace SistemaAgendamento.Core.Models
{
    public class Sala
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public override string ToString()
        {
            return $"{Id}, {Nome}";
        }

        public Sala(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }

        public Sala()
        {

        }
    }
}
