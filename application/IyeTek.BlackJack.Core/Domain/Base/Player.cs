﻿using System;
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
        private readonly IScoreCalculator _scoreCalculator;

        public abstract bool CanTakeDecision { get; }

        /// <summary>
        /// Each player can have a name to identify him
        /// </summary>
        public string Name { get; protected set; }

        protected IShoeService ShoeService { get; private set; }

        public Hand Hand { get; protected set; }
        public Status Status { get; internal set; }
        public int Score { get { return _scoreCalculator.Calculate(Hand); } }

        /// <summary>
        /// When created the initial status and score of the player are determined
        /// </summary>
        /// <param name="shoeService">depending on the implementation (strategy pattern) of the shoe the hand may differ</param>
        /// <param name="scoreCalculator"></param>
        /// <param name="name"></param>
        protected Player(IShoeService shoeService, IScoreCalculator scoreCalculator, string name = "")
        {
            _scoreCalculator = scoreCalculator;
            ShoeService = shoeService;
            Name = name;
            Reset();
        }

        public void Reset()
        {
            MakeInitialHand();
            Status = Status.Playing;
            Status.CalculateScore(this);
        }

        protected virtual void MakeInitialHand()
        {
            Hand = ShoeService.MakeInitialHand();
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