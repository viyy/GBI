using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace Geekbrains
{
    
    public static class Logger
    {
        [Conditional("LOG_INFO")]
        public static void Info(string log)
        {
            Debug.Log(log);
        }

        [Conditional("LOG_WARNING")]
        public static void Warning(string log)
        {
            Debug.LogWarning(log);
        }

        [Conditional("LOG_ERROR")]
        public static void Error(string log)
        {
            Debug.LogError(log);
        }
    }
}