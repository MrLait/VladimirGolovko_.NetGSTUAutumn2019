using System;
using System.Collections.Generic;
using ClientServerLib.ClientModel;

namespace ClientServerLib
{
    public class MessagesFromServer
    {
        private readonly List<string> messages = new List<string>();

        public List<string> Messages { get { return messages; } }

        public MessagesFromServer(Client client)
        {
            client.NewMessage += (sender, e) =>
            {
                Console.WriteLine(Translit(e.Message));
            };
        }

        public string Translit(string message)
        {
            string resultMessage = string.Empty;
            string rusPattern = "абвгдеёжзийк" + "лмнопрстуфхцчшщ" + "ьыъэюя" + "АБВГДЕЁЖЗИЙКЛМНО" + "ПРСТУФХЦЧШЩЬЫЪЭЮЯ";
            string[] latPatternArr = {"a", "b", "v", "g", "d", "e", "yo", "zh", "z", "i", "y", "k",
                "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "kh", "ts", "ch", "sh", "shch",
                "'", "y", "'", "e", "yu", "ya",
                "A", "B", "V", "G", "D", "E", "Yo", "Zh", "Z", "I", "Y", "K", "L", "M", "N", "O",
                "P", "R", "S", "T", "U", "F", "Kh", "Ts", "Ch", "Sh", "Shch", "'", "Y", "'", "E", "Yu", "Ya"};

            for (int i = 0; i < message.Length; i++)
            {
                char messageLetter = message[i];
                string patternLatLetter = string.Empty;
                bool letterIsEquel = false;

                for (int j = 0; j < rusPattern.Length; j++)
                {
                    if (messageLetter == rusPattern[j])
                    { 
                        letterIsEquel = true;
                        patternLatLetter = latPatternArr[j];
                        break;
                    }
                }

                if (letterIsEquel)
                    resultMessage += patternLatLetter;
                else
                    resultMessage += messageLetter;
            }

            return resultMessage;
        }

    }
}
