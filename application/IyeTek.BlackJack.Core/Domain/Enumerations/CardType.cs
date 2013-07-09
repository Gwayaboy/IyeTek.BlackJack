using System;
using System.Linq;
using System.Reflection;

namespace IyeTek.BlackJack.Core.Domain.Enumerations
{
    /// <summary>
    /// This mimic enumeration as classes with property and behaviour as in Java
    /// Base enumeration class of all the 13 card types in the regular pack or deck
    /// each item come with its own gameValue and a displayed face gameValue
    /// </summary>
    public class CardType
    {
        private static readonly Lazy<CardType[]> Enumerations = new Lazy<CardType[]>(GetEnumerations);


        public static CardType[] All { get { return Enumerations.Value; } }
        
        public static CardType Ace = new CardType(1, "Ace");
        public static CardType Two = new CardType(2, "Two");
        public static CardType Three = new CardType(3, "Three");
        public static CardType Four = new CardType(4, "Four");
        public static CardType Five = new CardType(5, "Five");
        public static CardType Six = new CardType(6, "Six");
        public static CardType Seven = new CardType(7, "Seven");
        public static CardType Eight = new CardType(8, "Eight");
        public static CardType Nine = new CardType(9, "Nine");
        public static CardType Ten = new CardType(10, "Ten");
        public static CardType Jack = new CardType(11, "Jack");
        public static CardType Queen = new CardType(12, "Queen");
        public static CardType King = new CardType(13, "King");
        
        public int GameValue { get; protected set; }
        public string DisplayName { get; private set; }

        internal CardType(int gameValue, string displayName)
        {
            GameValue = gameValue;
            DisplayName = displayName;
        }
       
        public override string ToString()
        {
            return DisplayName;
        }

        private static CardType[] GetEnumerations()
        {
            var enumerationType = typeof(CardType);
            return enumerationType
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Where(info => enumerationType.IsAssignableFrom(info.FieldType))
                .Select(info => info.GetValue(null))
                .Cast<CardType>()
                .ToArray();
        }
    }
}