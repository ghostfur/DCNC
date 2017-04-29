﻿using System;
using Shared.Util;

namespace AreaServer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                AreaServer.Instance.Run();
            }
            catch (Exception ex)
            {
                Log.Exception(ex, "An exception occured while starting the server.");
                ConsoleUtil.Exit(1);
            }
        }
    }
}
