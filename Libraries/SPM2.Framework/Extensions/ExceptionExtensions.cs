using System;
using System.Text;
using System.Threading;

namespace SPM2.Framework
{
    public static class ExceptionExtensions
    {
        public static bool IsCritical(this Exception ex)
        {
            if (ex is OutOfMemoryException) return true;
            if (ex is AppDomainUnloadedException) return true;
            if (ex is BadImageFormatException) return true;
            if (ex is CannotUnloadAppDomainException) return true;
            if (ex is ExecutionEngineException) return true;
            if (ex is InvalidProgramException) return true;
            if (ex is ThreadAbortException) return true;
            return false;
        }

        /// <summary>
        /// Combines all messages from the exception and inner exceptions.
        /// </summary>
        /// <returns></returns>
        public static string GetMessages(this Exception ex)
        {
            StringBuilder sb = new StringBuilder();

            Exception temp = ex;
            while (temp != null)
            {
                sb.Append(temp.Message);
                temp = temp.InnerException;
                if (temp != null)
                {
                    sb.Append(" ");
                }
            }

#if DEBUG
            sb.Append(" - StackTrace -> " + ex.StackTrace);
#endif
            
            return sb.ToString();
        }
    }
}
