using Kata_Hangman_ClassLib;

namespace Kata_Hangman_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow ("HELLOWORLD", "----------")]
        [DataRow ("JASMIN", "------")]
        [DataRow ("", "")]
        public void Should_Hide_All_Letters_At_Beginning_Of_Game(string sourceWord, string expected)
        {
            string actual;

            Game game = new Game(sourceWord);
            actual = new string(game.alreadyGuessed);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Should_Ignore_Case_And_Set_Sourceword_With_Upper()
        {
            string expected = "JANEWAY";
            string actual;

            Game game = new Game("jaNeWaY");
            game.GuessALetter('J');
            game.GuessALetter('a');
            game.GuessALetter('n');
            game.GuessALetter('e');
            game.GuessALetter('w');
            game.GuessALetter('A');
            game.GuessALetter('y');

            actual = new string(game.SourceWord);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        [DataRow("KATA", "-A-A", 'A')]
        [DataRow("THINK", "----K", 'k')]
        [DataRow("PIzZA", "--ZZ-", 'z')]
        [DataRow("aSTROnauT", "--T-----T", 't')]
        public void Should_Reveal_Letters_If_Guessed_Correctly(string sourceWord, string expected, char guessedLetter)
        {
            string  actual;

            Game    game = new Game(sourceWord);
            game.GuessALetter(guessedLetter);

            actual = new string(game.alreadyGuessed);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Should_Reveal_Correct_Amount_Of_Turns_Left()
        {
            int     expected    = 4;
            int     actual;
            string  sourceWord  = "BUFFALOBILL";

            Game    game        = new Game(sourceWord);
            game.GuessALetter('A');
            game.GuessALetter('b');
            game.GuessALetter('C');
            game.GuessALetter('d');

            actual = game.turnsLeft;

            Assert.AreEqual(actual, expected);
        }
    }
}