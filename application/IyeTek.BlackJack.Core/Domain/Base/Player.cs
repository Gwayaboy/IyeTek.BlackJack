using System;
using IyeTek.BlackJack.Core.Interfaces.Domain;
using IyeTek.BlackJack.Core.Interfaces.Services;
using IyeTek.BlackJack.Core.Domain.Enumerations.Statuses;

namespace IyeTek.BlackJack.Core.Domain.Base
{
    /// <summary>
    /// Represents the base card Player that holds a <see cref="IHand"/> a <seealso cref="Status"/> and
    /// the score of the Hand
    /// depends on the <see cref="IShoeService"/> to get his initial hands and to be dealt a <see cref="Card"/> during the game
    /// Any type of concrete player - automated or human - can inherit from this class (<see cref="ComputerDealer"/>, <seealso cref="HumanPlayer"/>)
    /// </summary>
    public abstract class Player
    {

        private readonly Lazy<IHand> _hand;
        
        /// <summary>
        /// Each player can have a name to identify him
        /// </summary>
        public string Name { get; protected set; }

        protected IShoeService ShoeService { get; private set; }
        
        public IHand Hand { get { return _hand.Value; } }
        public Status Status { get; internal set; }
        public int Score { get { return Hand.Score; } }

        /// <summary>
        /// When created the initial status and score of the player are determined
        /// </summary>
        /// <param name="shoeService">depending on the implementation (strategy pattern) of the shoe the hand may differ</param>
        /// <param name="name"></param>
        protected Player(IShoeService shoeService, string name = "")
        {
            ShoeService = shoeService;
            _hand = new Lazy<IHand>(MakeInitialHand);
            Name = name;
            
            Status = Status.Playing;
            Status.CalculateScore(this);
        }

        protected virtual IHand MakeInitialHand()
        {
            return ShoeService.MakeInitialHand();
        }
        
        /// <summary>
        /// Take a new card from the shoe and redetermine the status and hand score
        /// </summary>
        /// <returns>hand score</returns>
        protected int HitCard()
        {
            Hand.Add(ShoeService.DealCard());
            //The status calculate the hand score and depending of it determines the appropriate status
            //(State pattern)
            return Status.CalculateScore(this);
        }

        /// <summary>
        /// To be implemented by concrete implementation, can have different strategy
        /// depending the type of player
        /// </summary>
        public abstract void TakeTurn();
    }
}