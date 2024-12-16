namespace CodingKatas.UserStory1
{
    public class ReadFile
    {
        public string[] ReadFileLines(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The file was not found.");
            }

            var lines = File.ReadAllLines(filePath);

            if (lines.Length < 4)
            {
                throw new InvalidOperationException("The file is too short to contain a block (a block is 4 lines).");
            }

            if (lines == null)
            {
                throw new ArgumentException("The file is empty.");
            }

            return lines;
        }
    }
}
