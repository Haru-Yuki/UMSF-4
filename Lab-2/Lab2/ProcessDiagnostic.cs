using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;

namespace Lab2
{
    class ProcessDiagnostic
    {
        public void ShowExecutedProcesses()
        {
            Process[] localAll = Process.GetProcesses();

            for (int i = 0; i < localAll.Length; i++)
            {
                Console.WriteLine($"Process : {localAll[i].ProcessName}");
            }
            Console.WriteLine("\n\n");
        }

        public void ShowProcessInfo(string processName)
        {
            Process[] proc = Process.GetProcessesByName(processName);

            for (int i = 0; i < proc.Length; i++)
            {
                Console.WriteLine(
                    $"Process Name : {proc[i].ProcessName}\n" +
                    $"Process ID   : {proc[i].Id}\n" +
                    $"MachineName  : {Environment.MachineName}\n" +
                    $"StartTime    : {proc[i].StartTime}\n\n");
            }
        }

        public void ShowThreadInfo(string processName) {
            Process[] proc = Process.GetProcessesByName(processName);
            List<ProcessThreadCollection> threads = new List<ProcessThreadCollection>();

            for (int i = 0; i < proc.Length; i++)
            {
                threads.Add(proc[i].Threads);
            }

            for (int i = 0; i < threads.Count; i++)
            {
                for (int j = 0; j < threads[i].Count; j++)
                {
                    Console.WriteLine(
                    $"Thread #{i} id: {threads[i][j].Id}\t"+
                    $"priorityLevel: {threads[i][j].PriorityLevel}\t\t" +
                    $"basicPriority: {threads[i][j].BasePriority}\t" +
                    $"currentPriority: {threads[i][j].CurrentPriority}\t" +
                    $"startTime: {threads[i][j].StartTime}");
                }
            }
        }         
    }
}

