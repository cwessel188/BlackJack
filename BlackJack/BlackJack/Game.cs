using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Game
    {
        public List<Card> Deck { get; set; }
        
        public Game()
        {
            Deck = CreateDeckasList();
        }
        
        /// <summary>
        /// Creates a deck
        /// </summary>
        /// <returns>the deck as a list</returns>
        public List<Card> CreateDeckasList()
        {
            var Cards = new List<Card>();

            for (int i = 0; i < 13; i++) // 13 faces
            {
                var card = new Card { Id = i, Face = i, Suite = '♥' };
                Cards.Add(card);
            }
            for (int i = 0; i < 13; i++) // 13 faces
            {
                var card = new Card { Id = i + 13, Face = i, Suite = '♣' };
                Cards.Add(card);
            }
            for (int i = 0; i < 13; i++) // 13 faces
            {
                var card = new Card { Id = i + 26, Face = i, Suite = '♠' };
                Cards.Add(card);
            } for (int i = 0; i < 13; i++) // 13 faces
            {
                var card = new Card { Id = i + 39, Face = i, Suite = '♦' };
                Cards.Add(card);
            }

            return Cards;
        }

        /// <summary>
        /// Uses the deck to get a new hand of two cards
        /// </summary>
        /// <param cardsinHand>the number of cards in the hand</param>
        /// <returns>a hand of two cards</returns>
        public List<Card> DealNewHand(int cardsInHand)
        {
            var rnd = new Random();
            var hand = new List<Card>();
            var temp = new Card();


            for (int i = 0; i < cardsInHand; i++)
            {
                temp = Deck[rnd.Next(Deck.Count)];
                hand.Add(temp);
                Deck.Remove(temp);
            }

            return hand;
        }

        /// <summary>
        /// Calcualtes the value of the cards in the hand, taking into account Aces and face cards
        /// </summary>
        /// <param name="hand">The list of cards objects in the hand</param>
        /// <returns></returns>
        public int GetHandsValue(List<Card> hand)
        {
            var sum = 0;
            var numAces = 0;

            // sums to cards in the hand
            foreach (var card in hand)
            {
                if (card.Face == 0 || card.Face == 11 || card.Face == 12) // king or jack or queen
                    sum += 10;
                else if (card.Face == 1) // Ace
                {
                    sum += 11;
                    numAces++;
                }
                else
                    sum += card.Face;
            }

            // special treatment for Aces
            for (int i = 0; i < numAces; i++)
            {
                if (sum > 21)
                    sum -= 10;
            }

            return sum;
        }

        /// <summary>
        /// Adds a new card from the deck into the hand.
        /// </summary>
        /// <param name="hand">the hand of cards</param>
        /// <returns>the hand with a new card added</returns>
        public List<Card> HitMe(List<Card> hand)
        {
            var rnd = new Random();
            var temp = Deck[rnd.Next(Deck.Count)];

            hand.Add(temp);
            Deck.Remove(temp);


            return hand;
        }

        /// <summary>
        /// The game loop
        /// </summary>
        public void PlayGame()
        {

            var rnd = new Random();
            List<Card> deck = CreateDeckasList();
            var playerBusted = false;
            var dealerBusted = false;

            Console.WriteLine("****** Welcome to BlackJack!! ******\n");

            var playerHand = DealNewHand(2);
            var dealerHand = DealNewHand(2);

            // write the dealer's hand
            Console.Write("The Dealer's hand: ");
            foreach (var card in dealerHand)
            {
                Console.Write(card);
            }

            // loop until you hit no more
            while (true)
            {
                // write the player's hand
                Console.Write("\n\nYour hand: ");
                foreach (var card in playerHand)
                {
                    Console.Write(card);
                }
                if (playerBusted)
                {
                    Console.WriteLine("You bust! :'-(");
                    break;
                }

                Console.WriteLine("\n Would you like to hit? [y/n]");
                var response = Console.ReadLine();

                if (response == "y")
                    playerHand = HitMe(playerHand);

                else if (response == "n")
                    break;

                else
                    Console.WriteLine("\nPlease enter 'y' or 'n'.");

                // bust at 22 points
                if (GetHandsValue(playerHand) >= 22)
                {
                    playerBusted = true;
                }
            } // end while loop

            Console.WriteLine("Your hand is worth {0} points.", GetHandsValue(playerHand));


            // dealer hits until his hand is 17 or more.
            while (!playerBusted)
            {
                // write the player's hand
                Console.Write("\nThe Dealer's hand: ");
                foreach (var card in dealerHand)
                {
                    Console.Write(card);
                }

                if (GetHandsValue(dealerHand) < 17)
                {
                    Console.Write("  The Dealer hits!");
                    dealerHand = HitMe(dealerHand);
                }
                else if (GetHandsValue(dealerHand) > 21)
                {
                    Console.WriteLine("The Dealer busts! You win! :'-(");
                    dealerBusted = true;
                    break;
                }
                else
                {
                    Console.WriteLine("\nThe Dealer stays.");
                    break;
                }
            } // end while loop

            // if no one has busted
            if (!dealerBusted && !playerBusted)
            {

                var endPlayerValue = GetHandsValue(playerHand);
                var endDealerValue = GetHandsValue(dealerHand);

                Console.WriteLine("Your hand is worth {0}, the Dealer's hand is worth {1}.", endPlayerValue, endDealerValue);

                if (endPlayerValue > endDealerValue || dealerBusted)
                    Console.WriteLine("You win! :-D");
                else
                    Console.WriteLine("You lose! :-D");
            }
        }
    }
}
