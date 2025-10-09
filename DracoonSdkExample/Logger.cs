using System;

namespace Dracoon.Sdk.Example {
    public class Logger : ILog {

        public void Debug(string tag, string message) {
            PrintMessage("DEBUG", tag, message);
        }

        public void Debug(string tag, string message, Exception e) {
            PrintMessage("DEBUG", tag, message);
            System.Diagnostics.Debug.WriteLine(e.StackTrace);
        }

        public void Error(string tag, string message) {
            PrintMessage("ERROR", tag, message);
        }

        public void Error(string tag, string message, Exception e) {
            PrintMessage("ERROR", tag, message);
            System.Diagnostics.Debug.WriteLine(e.StackTrace);
        }

        public void Info(string tag, string message) {
            PrintMessage("INFO", tag, message);
        }

        public void Info(string tag, string message, Exception e) {
            PrintMessage("INFO", tag, message);
            System.Diagnostics.Debug.WriteLine(e.StackTrace);
        }

        public void Warn(string tag, string message) {
            PrintMessage("WARN", tag, message);
        }

        public void Warn(string tag, string message, Exception e) {
            PrintMessage("WARN", tag, message);
            System.Diagnostics.Debug.WriteLine(e.StackTrace);
        }

        internal void WriteLine(string message) {
            PrintMessage("OUTPUT", nameof(DracoonExamples), message);
        }

        internal void WriteStatistics(string message) {
            PrintMessage("STATS", nameof(DracoonExamples), message);
        }

        private static void PrintMessage(string severity, string tag, string message) {
            System.Diagnostics.Debug.WriteLine($"{severity}{new string(' ', 8 - severity.Length)} {tag}: {message}");
        }
    }
}
