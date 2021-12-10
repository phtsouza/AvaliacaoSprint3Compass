using System;

namespace SistemaAgendamento.Core.Models
{
    public class AgendamentoModel
    {
        public AgendamentoModel()
        {

        }

        public AgendamentoModel(int id, string titulo, Sala sala, DateTime inicio, DateTime fim, StatusAgendamento status)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Sala = sala;
            this.Inicio = inicio;
            this.Fim = fim;
            this.Status = status;
        }

        
        public int Id { get; set; }

        public string Titulo { get; set; }

        public Sala Sala { get; set; }

        public DateTime Inicio { get; set; }

        public DateTime Fim { get; set; }

        public StatusAgendamento Status { get; set; }

        public override string ToString()
        {
            return $"{Id}, {Titulo}, {Sala.Nome}, {Inicio.ToString("dd/MM/yyyy")}";
        }
    }
}
