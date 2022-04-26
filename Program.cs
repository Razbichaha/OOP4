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

           List<string> fff= deckOfCards.deckCards;

            Console.ReadKey();
        }
    }


    class DeckOfCards
    {
        private List<string> deckList = new List<string>() { "6 трефа", "7 трефа", "8 трефа", "9 трефа", "10 трефа", "валет трефа",
                                                             "дама трефа", "король трефа", "туз трефа" };
        public List<string> deckCards{ get; }

        public DeckOfCards()
        {
            deckCards = deckList;
        }

    }

    class ShowDeckOfCards
    {



    }
}
