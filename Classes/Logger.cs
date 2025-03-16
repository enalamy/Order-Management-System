using System;
using System.IO;

public static class Logger
{
    public static string logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Log.txt");


    public static void Log(string message)
    {
        using (StreamWriter writer = new StreamWriter(logFilePath, true))
        {
            writer.WriteLine($"[{DateTime.Now}] {message}");
        }
    }
}