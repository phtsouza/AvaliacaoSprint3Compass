using System;
using System.Collections.Generic;
using SistemaAgendamento.Core.Models;

namespace SistemaAgendamento.Infrastructure
{
    public interface IRepositorioAgendamento
    {
        void IncluirAgendamentos(params AgendamentoModel[] agendamento);
        void IncluirAgendamento(AgendamentoModel agendamento);
        void AtualizarAgendamentos(params AgendamentoModel[] agendamento);
        void ExcluirAgendamentos(params AgendamentoModel[] agendamento);

        AgendamentoModel ObtemAgendamentoPorId(int id);
        IEnumerable<AgendamentoModel> ObtemAgendamentos(Func<AgendamentoModel, bool> filtro);
    }
}
