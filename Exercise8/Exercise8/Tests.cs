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
            if (cards.Count() == 2)
            {
                if (cards.First().Value > cards.Last().Value)
                {
                    return cards.Reverse();
                }
            }

            return cards;
        }
    }
}