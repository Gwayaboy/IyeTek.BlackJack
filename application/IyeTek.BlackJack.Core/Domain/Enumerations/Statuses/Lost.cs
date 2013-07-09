namespace IyeTek.BlackJack.Core.Domain.Enumerations.Statuses
{
    /// <summary>
    /// Status of a player that has lost
    /// </summary>
    public class Lost : Status
    {
        /// <summary>
        /// Accepts the reason why the player has lost:
        /// Depending of the card game there could be many reason for loosing
        /// </summary>
        public Lost(string reason) : base(reason) { }
    }
}