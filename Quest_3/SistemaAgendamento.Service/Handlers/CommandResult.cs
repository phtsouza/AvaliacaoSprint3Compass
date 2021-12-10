using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaAgendamento.Service.Handlers
{
    public class CommandResult
    {
        public CommandResult(bool success)
        {
            IsSuccess = success;
        }

        public bool IsSuccess { get; }
    }
}
