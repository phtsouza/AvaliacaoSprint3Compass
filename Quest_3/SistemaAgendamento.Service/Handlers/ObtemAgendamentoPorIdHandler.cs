using SistemaAgendamento.Core.Commands;
using SistemaAgendamento.Core.Models;
using SistemaAgendamento.Infrastructure;

namespace SistemaAgendamento.Services.Handlers
{
    public class ObtemAgendamentoPorIdHandler
    {
        IRepositorioAgendamento _repo;

        public ObtemAgendamentoPorIdHandler()
        {
            _repo = new RepositorioAgendamento();
        }

        public AgendamentoModel Execute(ObtemAgendamentoPorId comando)
        {
            return _repo.ObtemAgendamentoPorId(comando.IdAgendamento);
        }
    }
}
