using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            UserGuess();
        }

        static char DifficultySelect()
        {
            //Prompts for difficulty selection (used as input parameter on other methods), which it returns as a char (char for space and ReadKey)
            //While loop to ensure correct user input
            
            Console.WriteLine("Welcome to hangman!");
            Console.WriteLine(@"Please select a difficulty: (Enter the number only)
                1. Easy: 3-5 letter words from the Scrabble dictionary, game ends after 9 wrong guesses
                2. Medium: 3-6 letter words from the Scrabble dictionary, game ends after 6 wrong guesses
                3. Hard: Any length words from the Scrabble dictionary, game ends after 6 wrong guesses
                4. Expert: Any length word is game, game ends after only 5 wrong guesses");

            char userInput = Console.ReadKey().KeyChar;

            char [] options = { '1', '2', '3', '4' };
        
            while (!options.Contains(userInput))
            {
                Console.WriteLine("\n");
                Console.WriteLine("Invalid entry. Let's try this again...");
                Console.WriteLine(@"Please select a difficulty: (Enter the number only)
                1. Easy: 3-5 letter words from the Scrabble dictionary, game ends after 9 wrong guesses
                2. Medium: 3-6 letter words from the Scrabble dictionary, game ends after 6 wrong guesses
                3. Hard: Any length words from the Scrabble dictionary, game ends after 6 wrong guesses
                4. Expert: Any length word is game, game ends after only 5 wrong guesses");
                Console.WriteLine("\n");
                userInput = Console.ReadKey().KeyChar;
            }
            Console.WriteLine("\n");
            return userInput;
        }

        static string WordGenerator(char difficulty)
        {
            //Generates a random word from a wordlist text file (Collins Scrabble Words (2019), saved in bin\debug\netcoreapp3.1)

            //First, the wordlist is read into a list in order to allow random access and exclusion of words
            //Next, a random integer between 1 and lastline of list element is generated, which is used as the index of the word from the Wordlist list
            //Input parameter of difficulty (separate method returns this) is then evaluated - this determines length of word to be used
            //Selected word is then parsed and an array is created with the length of the word
            //a char array is created with "_" in place of each character in word, string of word is returned

            List<string> Wordlist = new List<string>();
            using (StreamReader sr = new StreamReader("Wordlist.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Wordlist.Add(line);
                }
            }
            Random r = new Random();
            int rInt = r.Next(1, Wordlist.Count);

            String wordToGuess = (Wordlist[rInt]);
            char[] wordToGuessArray;

            if (difficulty == '1')
            {
                while (wordToGuess.Length <= 2 || wordToGuess.Length >= 6)
                {
                    rInt = r.Next(1, Wordlist.Count);
                    wordToGuess = (Wordlist[rInt]);
                }

                wordToGuessArray = wordToGuess.ToCharArray();
                for (int i = 0 ; i < wordToGuess.Length ; i++)
                {
                    wordToGuessArray[i] = '_';
                }
                Console.WriteLine(wordToGuessArray);
            }

            else if (difficulty == '2')
            {
                while (wordToGuess.Length <= 2 || wordToGuess.Length >= 7)
                {
                    rInt = r.Next(1, Wordlist.Count);
                    wordToGuess = (Wordlist[rInt]);
                }

                wordToGuessArray = wordToGuess.ToCharArray();
                for (int i = 0 ; i < wordToGuess.Length ; i++)
                {
                    wordToGuessArray[i] = '_';
                }
                Console.WriteLine(wordToGuessArray);
            }

            else if (difficulty == '3')
            {
                while (wordToGuess.Length <= 2)
                {
                    rInt = r.Next(1, Wordlist.Count);
                    wordToGuess = (Wordlist[rInt]);
                }

                wordToGuessArray = wordToGuess.ToCharArray();
                for (int i = 0 ; i < wordToGuess.Length ; i++)
                {
                    wordToGuessArray[i] = '_';
                }
                Console.WriteLine(wordToGuessArray);
            }

            else if (difficulty == '4')
            {
                while (wordToGuess.Length <= 2)
                {
                    rInt = r.Next(1, Wordlist.Count);
                    wordToGuess = (Wordlist[rInt]);
                }

                wordToGuessArray = wordToGuess.ToCharArray();
                for (int i = 0 ; i < wordToGuess.Length ; i++)
                {
                    wordToGuessArray[i] = '_';
                }
                Console.WriteLine(wordToGuessArray);
            }

            return wordToGuess;
        }

        static void UserGuess()
        {
            //Word is brought in to the method as a string
            //Difficulty determines number of guesses player has before game over
            //While player has guesses remaining, player input is received (as char) and checked if in string
            //If yes, player maintains current amount of guesses available and word is displayed with correctly guessed letters replacing underscores
            //This is done by using a second array of type char and converting all letters with underscores. That array then has the underscore at index of the guessed letter replaced with guessed letter
            //If no, user adds a wrongGuess count, current word array configuration is displayed, and player is prompted to continue
            //String array of previously guessed, incorrect letters, is also displayed
            //If all letters are guessed, congratulatory message displayed
            //Player can play again or exit
            //If player loses all available guesses, game over message displayed showing the word
            //Player can play again or exit

            char difficulty = DifficultySelect();
            string wordToGuess = WordGenerator(difficulty);
            char[] wordToGuessArray = wordToGuess.ToCharArray();
            char[] wordToGuessRedact = wordToGuessArray;
            char[] wrongLetter;
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                wordToGuessRedact[i] = '_';
            }
            char userGuess = ' ';
            int deathCount = 1;
            int wrongGuess = 0;
            
            if (difficulty == '1')
            {
                deathCount = 9;
            }

            else if (difficulty == '2')
            {
                deathCount = 6;
            }

            else if (difficulty == '3')
            {
                deathCount = 6;
            }

            else if (difficulty == '4')
            {
                deathCount = 5;
            }

            wrongLetter = new char[deathCount];
            Console.WriteLine("Please guess a letter: \n");

            while (wrongGuess < deathCount)
            {
                userGuess = Console.ReadKey().KeyChar;
                char userGuessUp = char.ToUpper(userGuess);

                if (!(wordToGuess.Contains(userGuessUp)))
                {
                    wrongGuess += 1;
                    wrongLetter[wrongGuess - 1] = userGuessUp;
                    Console.WriteLine($"\n\nSorry, \"{userGuessUp}\" is not in the word!\n");
                    Console.WriteLine($"You have {deathCount - wrongGuess} guesses remaining. Please guess again:\n\n");
                    Console.WriteLine(wordToGuessRedact);
                    Console.WriteLine("Wrong guesses:");
                    Console.WriteLine(wrongLetter);
                }


                else if (wordToGuess.Contains(userGuessUp))
                {
                    for (int i = 0; i < wordToGuess.Length; i++)
                    {
                        if (wordToGuess[i] == userGuessUp)
                        {
                            wordToGuessRedact[i] = userGuessUp;
                        }
                    }

                    if (!(wordToGuessRedact.Contains('_')))
                    {
                        Console.WriteLine($"\n{wordToGuess}");
                        Console.WriteLine($"\nCongratulations!! You are so special. You guessed the word {wordToGuess}");
                        Console.WriteLine("Would you like to play again? Y/N");
                        char userInput = Console.ReadKey().KeyChar;
                        char userInputUp = char.ToUpper(userInput);
                        if (userInputUp == 'Y')
                        {
                            Console.WriteLine("\nStarting a new game...\n");
                            Main(null);
                        }

                        else if (userInputUp == 'N')
                        {
                            Console.WriteLine("\nThanks anyways, see you next time!");
                            Environment.Exit(0);                            
                        }
                        else
                        {
                            Console.WriteLine($"\n\"{userInput}\" is not a valid entry. For your failure to follow directions, \n" +
                                $"you must now play again");
                            Console.WriteLine("\nStarting a new game...\n");
                            Main(null);
                        }
                    }

                    else
                    {
                        Console.WriteLine($"\n\nGreat job! \"{userGuessUp}\" is in the word!");
                        Console.WriteLine($"You have {deathCount - wrongGuess} guesses remaining. Please guess again:\n\n");
                        Console.WriteLine(wordToGuessRedact); 
                        Console.WriteLine("Wrong guesses:");
                        Console.WriteLine(wrongLetter);
                    }
                }
            }

            if (wrongGuess == deathCount)
            {
                Console.WriteLine("Sorry, you lost!");
                Console.WriteLine($"The word was {wordToGuess}");
                Console.WriteLine("Would you like to play again? Y/N");
                char userInput = Console.ReadKey().KeyChar;
                char userInputUp = char.ToUpper(userInput);
                if (userInputUp == 'Y')
                {
                    Console.WriteLine("\nStarting a new game...\n");
                    Main(null);
                }

                else if (userInputUp == 'N')
                {
                    Console.WriteLine("\nThanks anyways, see you next time!");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine($"\n\"{userInput}\" is not a valid entry. For your failure to follow directions, \n" +
                        $"you must now play again");
                    Console.WriteLine("\nStarting a new game...\n");
                    Main(null);
                }
            }
        }
    }
}
