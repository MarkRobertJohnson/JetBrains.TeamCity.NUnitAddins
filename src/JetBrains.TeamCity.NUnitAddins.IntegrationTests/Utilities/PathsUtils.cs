using System;
using System.IO;

namespace JetBrains.TeamCity.NUnitAddins.IntegrationTests.Utilities
{
    internal class PathsUtils
    {
        public static string SolutionPath
        {
            get
            {
                var currentDirectory = Environment.CurrentDirectory;
                return Path.GetFullPath(Path.Combine(currentDirectory, "..\\.."));
            }
        }

        public static string BinPath
        {
            get
            {
#if DEBUG
                return Path.GetFullPath(Path.Combine(SolutionPath, "bin\\Debug"));
#else
                return Path.GetFullPath(Path.Combine(SolutionRootPath, "bin\\Release"));
#endif
            }
        }

        public static string NUnitConsolePath
        {
            get
            {
                return Path.GetFullPath(Path.Combine(SolutionPath, "lib\\NUnit-3.0.0\\bin"));
            }
        }

        public static string NUnitConsoleBinPath
        {
            get
            {
                return Path.Combine(BinPath, "NUnitConsole");
            }
        }

        public static string NUnitConsoleExeFileName
        {
            get
            {
                return Path.Combine(NUnitConsoleBinPath, "nunit-console.exe");
            }
        }

        public static string GetBinPathByVersion(string nUnitVersion)
        {
            return Path.Combine(BinPath, nUnitVersion);
        }
    }
}