using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lab2
{
    class ProcessesInfo
    {
        public static void ShowExecutedProcesses()
        {
            Process[] localAll = Process.GetProcesses();

            for (int i = 0; i < localAll.Length; i++)
            {
                Console.WriteLine($"Process: {localAll[i].ProcessName}");
            }
            Console.WriteLine("\n\n");
        }

        public static void ShowProcessInfo(string processName)
        {
            Process[] proc = Process.GetProcessesByName(processName);

            IfProcessExist(processName);

            for (int i = 0; i < proc.Length; i++)
            {
                Console.WriteLine(
                    $"Process Name : {proc[i].ProcessName}\n" +
                    $"Process ID : {proc[i].Id}\n" +
                    $"MachineName : {Environment.MachineName}\n" +
                    $"StartTime : {proc[i].StartTime}\n\n");
            }
        }

        public static void ShowThreadInfo(string processName)
        {
            Process[] proc = Process.GetProcessesByName(processName);
            List<ProcessThreadCollection> threads = new List<ProcessThreadCollection>();

            IfProcessExist(processName);

            for (int i = 0; i < proc.Length; i++)
            {
                threads.Add(proc[i].Threads);
            }

            for (int i = 0; i < threads.Count; i++)
            {
                for (int j = 0; j < threads[i].Count; j++)
                {
                    Console.WriteLine(
                    $"Thread #{i} id: {threads[i][j].Id}\n" +
                    $"priorityLevel: {threads[i][j].PriorityLevel}\n" +
                    $"basePriority: {threads[i][j].BasePriority}\n" +
                    $"currentPriority: {threads[i][j].CurrentPriority}\n" +
                    $"startTime: {threads[i][j].StartTime}\n" +
                    $"executionTime: {threads[i][j].TotalProcessorTime}\n\n");
                }
            }
        }

        public static void ShowModuleInfo(string processName)
        {
            Process[] proc = Process.GetProcessesByName(processName);
            List<ProcessModuleCollection> threads = new List<ProcessModuleCollection>();

            IfProcessExist(processName);

            try
            {
                for (int i = 0; i < proc.Length; i++)
                {   
                    threads.Add(proc[0].Modules);
                }

            
                for (int i = 0; i < threads.Count; i++)
                {
                    for (int j = 0; j < threads[i].Count; j++)
                    {
                        Console.WriteLine(
                        $"Module name: {threads[i][j].ModuleName}\n" +
                        $"file name: {threads[i][j].FileName}\n" +
                        $"module version: {threads[i][j].FileVersionInfo.FileVersion}\n" +
                        $"needed memory size: {threads[i][j].ModuleMemorySize}\n");
                    }
                }
            }
            catch (System.ComponentModel.Win32Exception)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Cannot access 64-bit module from 32-bit process!!!");
                Console.ResetColor();
            }            
        }

        private static void IfProcessExist(string processName)
        {
            Process[] proc = Process.GetProcessesByName(processName);

            if (proc.Length == 0)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"There is no process {processName}!");
                Console.ResetColor();
                return;
            }
        }

        public static void OpenApplication(string processName)
        {
            Process.Start(processName);

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{processName} was started successfully");
            Console.ResetColor();
        }

        public static void OpenWithStartInfo(string processName)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(processName)
            {
                WindowStyle = ProcessWindowStyle.Minimized
            };

            Process.Start(startInfo);

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{processName} was started successfully with ProcessStartInfo");
            Console.ResetColor();
        }

        public static void CloseApplication(string processName)
        {
            foreach (Process proc in Process.GetProcessesByName(processName))
            {
                proc.Kill();
            }
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{processName} was closed");
            Console.ResetColor();
        }
    }
}
