using System;

namespace CustomMenuPointers
{
    public static class Logger
    {
        public static void Info(string message) => Log("INFO", message);
        public static void Error(string message) => Log("ERROR", message);

        private static void Log(string level, string message) => Console.WriteLine($"{nameof(CustomMenuPointers)} | {level}] {message}");
    }
}
