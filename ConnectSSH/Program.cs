﻿namespace ConnectSSH
{
    using System;
    using System.Windows.Forms;

    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Config.GetConfig();
            Application.Run(new FormMain());
        }
    }
}

