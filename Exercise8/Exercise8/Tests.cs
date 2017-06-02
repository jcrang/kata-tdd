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
    }

    public class Card
    {
    }

    public static class CardSorter
    {
        public static IEnumerable<Card> SortCards(IEnumerable<Card> empty)
        {
            return Enumerable.Empty<Card>();
        }
    }
}