using System;
using System.Collections.Generic;

namespace OOP4
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            menu.OutputHeader();

            DeckOfCards deckOfCards = new DeckOfCards();
            ShowDeckOfCards showDeckOfCards = new ShowDeckOfCards(deckOfCards.GetSufledDeckOfCards());
            Queue<string> deckUser = new Queue<string>();

            bool isContinueCycle = true;

            while (isContinueCycle)
            {
                string card = showDeckOfCards.GiveACard();
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "еще":
                        if (card == "_")
                        {
                            Console.Write("Колода выдана полностью ");
                            isContinueCycle = false;
                        }else
                        {
                            deckUser.Enqueue(card);
                            Console.WriteLine(card);
                        }
                        break;
                    case "все":

                        Game game = new Game(deckUser);
                        game.ShowCards();

                        break;
                    default:

                        menu.OutputAWarning();

                        break;
                }
            }
        }
    }

    class Game
    {
        private Queue<string> deckUser = new Queue<string>();

       public Game(Queue<string> deck)
        {
            deckUser = deck;
        }

        public void ShowCards()
        {
            Menu menu = new Menu();
            menu.OutputCardsPlayer(deckUser);

            DeckOfCards deckOfCards = new DeckOfCards();

            menu.OutputCardsPlayer(deckOfCards.EarndPoints(deckUser));
        }

    }

    class Menu
    {
        public void OutputHeader()
        {
            Console.WriteLine("Далее в игре присутствую следующие команды");
            Console.WriteLine("Получить карту - еще");
            Console.WriteLine("Остановить получение карт - все");
        }

        public void OutputAWarning()
        {
            Console.WriteLine("Введена не верная команда");
        }

        public void OutputCardsPlayer(Queue<string> cardsPlaer)
        {

            Console.WriteLine("Вы выбрали карты");
            foreach(string card in cardsPlaer) 
            {
                Console.WriteLine(card);
            }
        }

        public void OutputCardsPlayer(int sumCards)
        {
            Console.WriteLine("Ваши очки = "+sumCards);
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

        public List<string> _deckCards { get; }

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

        public int EarndPoints (Queue<string> cards)
        {
            int sumCards = 0;

            for(int i=0;i<=cards.Count;i++)
            {
                int temp;

                    CardWeight.TryGetValue(cards.Dequeue(), out temp);
                
                sumCards += temp;
            }
            return sumCards;
        }
    }

    class ShowDeckOfCards
    {
        private Queue<string> queueCards = new Queue<string>();

        public ShowDeckOfCards(List<string> cards)
        {
            Queue<string> temp = new Queue<string>(cards);
            queueCards = temp;
        }

        public string GiveACard()
        {
            string temp = "_";
            if (queueCards.Count > 0)
            {
                temp = queueCards.Dequeue();
            }

            return temp;
        }
    }
}
