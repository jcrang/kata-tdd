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
    }

    public struct Card
    {
    }

    public static class CardSorter
    {
        public static IEnumerable<Card> SortCards(IEnumerable<Card> cards)
        {
            return cards;
        }
    }
}