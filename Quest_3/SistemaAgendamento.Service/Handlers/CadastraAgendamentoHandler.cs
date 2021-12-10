using SistemaAgendamento.Core.Models;
using SistemaAgendamento.Core.Commands;
using SistemaAgendamento.Infrastructure;
using System;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using SistemaAgendamento.Service.Handlers;

namespace SistemaAgendamento.Services.Handlers
{
    public class CadastraAgendamentoHandler
    {
        IRepositorioAgendamento _repo;

        public CadastraAgendamentoHandler(IRepositorioAgendamento repositorio)
        {
            _repo = repositorio;
        }

        public CommandResult Execute(CadastrarAgendamento comando)
        {
            try
            {
                var agendamento = new AgendamentoModel
                (
                    id: 0,
                    titulo: comando.Titulo,
                    sala: comando.Sala,
                    inicio: comando.Inicio,
                    fim: comando.Fim,
                    status: StatusAgendamento.Criada

                );
                _repo.IncluirAgendamento(agendamento);
                return new CommandResult(true);
            }
            catch (Exception)
            {
                return new CommandResult(false);
            }
        }
    }
}
