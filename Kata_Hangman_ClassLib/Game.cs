namespace Kata_Hangman_ClassLib
{
    public class Game
    {
        public int      turnsLeft = 8;
        public char[]   alreadyGuessed;

        public string SourceWord { get; set; }

        public Game(string sourceWord)
        {
            SourceWord = sourceWord.ToUpper();
            alreadyGuessed = new String('-', SourceWord.Length).ToArray();
        }

        public string GuessALetter(char letter)
        {
            for (int index = 0; index < SourceWord.Length; index++)
            {
                letter = Char.ToUpper(letter);

                if (SourceWord[index] == letter)
                {
                    alreadyGuessed[index] = letter;
                }
            }
            turnsLeft--;
            return alreadyGuessed.ToString();
        }
    }
}