using System;

namespace SistemaAgendamento.Core.Commands
{
    public class GerenciaFimAgendamento
    {
        public GerenciaFimAgendamento()
        {
            DataHoraAtual = DateTime.Now;
        }

        public DateTime DataHoraAtual { get; }
    }
}
