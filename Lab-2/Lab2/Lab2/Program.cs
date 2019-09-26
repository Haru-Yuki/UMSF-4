using System;

namespace Lab2
{
    class Program : ProcessesInfo
    {
        private static void Main(string[] args)
        {
            ShowExecutedProcesses();
            ShowProcessInfo("chrome");
            ShowThreadInfo("chrome");
            ShowModuleInfo("Telegram");
            OpenApplication("chrome");
            CloseApplication("chrome");
            OpenWithStartInfo("chrome");


            _ = Console.ReadKey();
        }
    }
}
