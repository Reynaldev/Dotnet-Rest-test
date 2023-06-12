namespace Dotnet_Rest_test
{
    using System;
    using System.IO;

    public static class DotEnv
    {
        public static string Load(string filePath)
        {
            string output = "";

            if (!File.Exists(filePath))
                return null;

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(
                    '=',
                    StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 2)
                {
                    continue;
                }

                Environment.SetEnvironmentVariable(parts[0], parts[1]);
                output = parts[1];
            }

            return output;
        }
    }
}