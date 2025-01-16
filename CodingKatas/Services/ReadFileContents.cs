namespace CodingKatas.Services
{
    public class ReadFileContents
    {
        public static string[] ReadFileLines(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The file was not found.");
            }

            var lines = File.ReadAllLines(filePath);

            return lines.Length switch
            {
                0 => throw new ArgumentException("The file is empty."),
                < 4 => throw new InvalidOperationException("The file is too short to contain a block (a block is 4 lines)."),
                _ => lines
            };
        }
    }
}
