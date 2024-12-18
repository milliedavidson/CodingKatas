namespace CodingKatas
{
    public class NumberCharacter
    {
        private static readonly Dictionary<string, char> Grid = new Dictionary<string, char>
        {
            { " _ | ||_|   ", '0' },
            { "     |  |   ", '1' },
            { " _  _||_    ", '2' },
            { " _  _| _|   ", '3' },
            { "   |_|  |   ", '4' },
            { " _ |_  _|   ", '5' },
            { " _ |_ |_|   ", '6' },
            { " _   |  |   ", '7' },
            { " _ |_||_|   ", '8' },
            { " _ |_| _|   ", '9' }
        };

        public string CharacterString { get; }
        public char MappedCharacter => Grid.ContainsKey(CharacterString) ? Grid[CharacterString] : '?';

        public NumberCharacter(string characterString)
        {
            if (characterString.Length != 12)
            {
                CharacterString = new string(' ', 12);
            }

            else
            {
                CharacterString = characterString;
            }

            CharacterString = characterString;
        }
    }
}
