namespace CodingKatas.UserStory1
{
    public class NumberBlock
    {
        public List<string> Lines { get; }

        public NumberBlock(List<string> lines)
        {
            if (lines == null || lines.Count != 4)
            {
                throw new ArgumentException("The number block doesn't have 4 lines.");
            }

            Lines = lines;
        }

        public List<string> GetBlocks()
        {
            var blocks = new List<string>();

            for (int i = 0; i < 9; i++)
            {
                var block =
                    Lines[0].Substring(i * 3, 3) +
                    Lines[1].Substring(i * 3, 3) +
                    Lines[2].Substring(i * 3, 3) +
                    Lines[3].Substring(i * 3, 3);

                blocks.Add(block);
            }
            
            return blocks;

            // TODO: an object of a list of characters to put them into blocks (write a test for this)

            // TODO: new method returning number chars. loop through the lines and put the characters
        }
    }
}
