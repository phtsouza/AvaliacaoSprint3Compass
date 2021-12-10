using System;
using System.Linq;
using SistemaAgendamento.Core.Commands;
using SistemaAgendamento.Core.Models;
using SistemaAgendamento.Infrastructure;

namespace SistemaAgendamento.Services.Handlers
{
    public class GerenciaFimAgendamentoHandler
    {
        IRepositorioAgendamento _repo;

        public GerenciaFimAgendamentoHandler(IRepositorioAgendamento repositorio)
        {
            _repo = repositorio;
        }

        public void Execute(GerenciaFimAgendamento comando)
        {
            var agora = comando.DataHoraAtual;

            //pegar todas as tarefas não concluídas que passaram do prazo
            var tarefas = _repo
                .ObtemAgendamentos(t => t.Fim <= agora && t.Status != StatusAgendamento.Concluida)
                .ToList();

            //atualizá-las com status Atrasada
            tarefas.ForEach(t => t.Status = StatusAgendamento.Cancelada);

            //salvar tarefas
            _repo.AtualizarAgendamentos(tarefas.ToArray());
        }
    }
}
