using IyeTek.BlackJack.Core.Domain.Base;

namespace IyeTek.BlackJack.Core.Domain.Enumerations.Statuses
{
    
    /// <summary>
    /// Status of each player at the beginning, during end of any card game.
    /// Base class of the state pattern where each state manage its own behavior and the next state
    /// Using the state pattern allows many other statuses to be introduced depending on the cards game
    /// to reach depending on conditions
    /// <see cref="http://www.colourcoding.net/blog/archive/2009/07/25/enums-are-evil-the-state-pattern.aspx"/>
    /// </summary>
    public abstract class Status
    {
        public static Status Playing = new Playing();

        public string Reason { get; set; }

        protected Status(string reason)
        {
            Reason = reason;
        }

        public bool Is<TStatus>() where TStatus : Status
        {
            return this is TStatus;
        }

        public virtual int CalculateScore(Player player)
        {
            return player.Score;
        }

        public bool IsNot<TStatus>() where TStatus : Status
        {
            return !Is<TStatus>();
        }
    }
}