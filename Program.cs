using System;
using System.Collections.Generic;

namespace OOP4
{
    //    Есть колода с картами.Игрок достает карты,
    //    пока не решит, что ему хватит карт (может быть как выбор пользователя,
    //    так и количество сколько карт надо взять). После выводиться вся информация о вытянутых картах.

    //Возможные классы: Карта, Колода, Игрок.

    class Program
    {
        static void Main(string[] args)
        {

            DeckOfCards deckOfCards = new DeckOfCards();

            Queue<string> queueCards = new Queue<string>( deckOfCards.GetSufledDeckOfCards());



            Console.ReadKey();
        }
    }


    class DeckOfCards
    {
        private List<string> deckList = new List<string>() { "6 трефа", "7 трефа", "8 трефа", "9 трефа", "10 трефа", "валет трефа",
                                                             "дама трефа", "король трефа", "туз трефа" };

        private Dictionary<string, int> CardWeight = new Dictionary<string, int>
        {
            ["6 трефа"] = 6,
            ["7 трефа"] = 7,
            ["8 трефа"] = 8,
            ["9 трефа"] = 9,
            ["10 трефа"] = 10,
            ["валет трефа"] = 2,
            ["дама трефа"] = 3,
            ["король трефа"] = 4,
            ["туз трефа"] = 11
        };

        public List<string> _deckCards{ get; }

        public DeckOfCards()
        {
            _deckCards = deckList;
        }

        public List<string> GetSufledDeckOfCards()
        {
            string[] array = new string[deckList.Count];

            deckList.CopyTo(array);

            Random random = new Random();

            for (int i = array.Length - 1; i >= 1; i--)
            {
                int randomValue = random.Next(i + 1);
                string tempValue = array[randomValue];
                array[randomValue] = array[i];
                array[i] = tempValue;
            }

            List<string> tempList = new List<string>();
            tempList.AddRange(array);

            return tempList;
        }


    }

    class ShowDeckOfCards
    {
       private Queue<string> queueCards = new Queue<string>();

       public ShowDeckOfCards(Queue<string> cards)
        {
            queueCards = cards;
        }

        public string GiveACard()
        {
            string temp = "";



            return temp;
        }

    }
}
