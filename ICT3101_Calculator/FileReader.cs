using System.Runtime.InteropServices;

namespace ICT3101_Calculator
{
    public class FileReader : IFileReader
    {
        public string[] Read(string fileName)
        {
            // Construct the path based on the OS using Path.DirectorySeparatorChar
            string projectRoot = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..");

            // Use different paths depending on the environment
            string relativePath;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                relativePath = Path.Combine(projectRoot, "ICT3101_Calculator", fileName);
            }
            else
            {
                relativePath = Path.Combine(projectRoot, "ICT3101_Calculator", fileName);
            }

            // Resolve the absolute path
            string fullPath = Path.GetFullPath(relativePath);

            // Check if the file exists
            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException($"MagicNumbers.txt file not found at {fullPath}");
            }

            // Read the file and return its contents
            return File.ReadAllLines(fullPath);
        }
    }
}