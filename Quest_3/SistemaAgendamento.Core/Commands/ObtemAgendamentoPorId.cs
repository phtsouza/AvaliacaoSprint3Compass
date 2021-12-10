using SistemaAgendamento.Core.Models;
using MediatR;

namespace SistemaAgendamento.Core.Commands
{
    public class ObtemAgendamentoPorId: IRequest<Sala>
    {
        public ObtemAgendamentoPorId(int idAgendamento)
        {
            IdAgendamento = idAgendamento;
        }

        public int IdAgendamento { get; }
    }
}
