using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2
{
    class Program : ProcessDiagnostic
    {
        static void Main(string[] args)
        {
            ProcessDiagnostic processesInfo = new ProcessDiagnostic();

            processesInfo.ShowExecutedProcesses();
            processesInfo.ShowProcessInfo("Discord");
            processesInfo.ShowThreadInfo("Discord");









            _ = Console.ReadKey();
        }
    }
}
