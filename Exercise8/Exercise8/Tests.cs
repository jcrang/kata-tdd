using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Exercise8
{
    public class Tests
    {
        [Test]
        public void SortCards_NoCards_IsEmpty()
        {
            var sortedCards = CardSorter.SortCards(Enumerable.Empty<Card>());

            Assert.That(sortedCards, Is.Empty);
        }

        [Test]
        public void SortCards_OneCard_IsSame()
        {
            var unsortedCards = new[] { new Card(), };
            var sortedCards = CardSorter.SortCards(unsortedCards);
            Assert.That(sortedCards, Is.EqualTo(new[] { new Card() }));
        }

        [Test]
        public void SortCards_TwoInOrder_IsSame()
        {
            var unsortedCards = new[] { new Card(1), new Card(2)  };
            var sortedCards = CardSorter.SortCards(unsortedCards);

            Assert.That(sortedCards, Is.EqualTo(new[] { new Card(1), new Card(2) }));
        }

        [Test]
        public void SortCards_TwoInReverseOrder_IsReversed()
        {
            var unsortedCards = new[] { new Card(2), new Card(1) };
            var sortedCards = CardSorter.SortCards(unsortedCards);

            Assert.That(sortedCards, Is.EqualTo(new[] { new Card(1), new Card(2) }));
        }

        [Test]
        public void SortCards_ThreeReverseOrder_AreReversed()
        {
            var unsortedCards = new[] { new Card(3), new Card(2), new Card(1) };
            var sortedCards = CardSorter.SortCards(unsortedCards);

            Assert.That(sortedCards, Is.EqualTo(new[] { new Card(1), new Card(2), new Card(3) }));
        }

        [Test]
        public void SortCards_ThreeNotReverseOrInOrder_AreSorted()
        {
            var unsortedCards = new[] { new Card(3), new Card(1), new Card(2) };
            var sortedCards = CardSorter.SortCards(unsortedCards);

            Assert.That(sortedCards, Is.EqualTo(new[] { new Card(1), new Card(2), new Card(3) }));
        }
    }

    public struct Card
    {
        public int Value;

        public Card(int value)
        {
            Value = value;
        }
    }

    public static class CardSorter
    {
        public static IEnumerable<Card> SortCards(IEnumerable<Card> cards)
        {
            var cardList = cards.ToList();

            if (cardList.Count == 2)
            {
                if (cardList[0].Value > cardList[1].Value)
                {
                    Swap(cardList, 0, 1);
                }
            }
            else if (cardList.Count > 2)
            {
                if (cardList[0].Value > cardList[1].Value)
                {
                    Swap(cardList, 0, 1);
                }

                if (cardList[1].Value > cardList[2].Value)
                {
                    Swap(cardList, 1, 2);
                }

                if (cardList[0].Value > cardList[1].Value)
                {
                    Swap(cardList, 0, 1);
                }
            }

            return cardList;
        }

        private static void Swap(IList<Card> cardList, int from, int to)
        {
            var temporaryCard = cardList[from];
            cardList[from] = cardList[to];
            cardList[to] = temporaryCard;
        }
    }
}