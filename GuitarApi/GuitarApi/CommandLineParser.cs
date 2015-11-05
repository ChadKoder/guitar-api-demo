using System;
using System.Linq;

namespace GuitarApi
{
    public class CommandLineParser
    {
        public static bool ShouldRunAsService(string[] args)
        {
            if (args.Length > 0)
            {
                if (args.Any(arg => arg == "-d"))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
