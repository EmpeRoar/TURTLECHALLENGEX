using System;
using System.Collections.Generic;
using System.Text;

namespace CommandInputs.interfaces
{
    public interface ICommandInput
    {
        string GetReportMessage();
        void Execute();
    }
}
