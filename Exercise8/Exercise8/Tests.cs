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

        [Test]
        public void SortCards_FourReverseOrder_AreSorted()
        {
            var unsortedCards = new[] { new Card(4), new Card(3), new Card(2), new Card(1) };
            var sortedCards = CardSorter.SortCards(unsortedCards);

            Assert.That(sortedCards, Is.EqualTo(new[] { new Card(1), new Card(2), new Card(3), new Card(4) }));
        }

        [Test]
        public void SortCards_FourNotReverseOrInOrder_AreSorted()
        {
            var unsortedCards = new[] { new Card(4), new Card(1), new Card(2), new Card(3) };
            var sortedCards = CardSorter.SortCards(unsortedCards);

            Assert.That(sortedCards, Is.EqualTo(new[] { new Card(1), new Card(2), new Card(3), new Card(4) }));
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

            for (int i = 0; i < cardList.Count - 1; i++)
            {
                SwapPass(cardList);
            }

            return cardList;
        }

        private static void SwapPass(List<Card> cardList)
        {
            for (int i = 0; i < cardList.Count - 1; i++)
            {
                if (cardList[i].Value > cardList[i + 1].Value)
                {
                    Swap(cardList, i, i+1);
                }
            }
        }

        private static void Swap(IList<Card> cardList, int from, int to)
        {
            var temporaryCard = cardList[from];
            cardList[from] = cardList[to];
            cardList[to] = temporaryCard;
        }
    }
}