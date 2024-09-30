namespace ICT3101_Calculator;

public class FileReader : IFileReader
{
    public string[] Read(string fileName)
    {
        string fullPath = "/Users/alainpierre/Projects/ICT3101_Calculator/ICT3101_Calculator/MagicNumbers.txt";
        
        return File.ReadAllLines(fullPath);
    }
}