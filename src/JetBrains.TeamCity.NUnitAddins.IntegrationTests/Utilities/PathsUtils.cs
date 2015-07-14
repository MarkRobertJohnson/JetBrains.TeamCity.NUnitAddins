namespace JetBrains.TeamCity.NUnitAddins.IntegrationTests.Utilities
{
    using System;
    using System.IO;

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

        public static string LibPath
        {
            get
            {
                return Path.GetFullPath(Path.Combine(SolutionPath, "lib"));
            }
        }

        public static string GetBinPathByVersion(string nUnitVersion)
        {
            return Path.Combine(BinPath, nUnitVersion);
        }

        public static string GetLibPathByVersion(string nUnitVersion)
        {
            return Path.Combine(Path.Combine(LibPath, nUnitVersion), "bin");
        }
    }
}