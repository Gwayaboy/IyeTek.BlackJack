namespace IyeTek.BlackJack.Core.Domain.Enumerations.Statuses
{
    /// <summary>
    /// Status of a player that has won
    /// </summary>
    public class Won : Status
    {
        /// <summary>
        /// There's different reason the player can win depending on the card game
        /// </summary>
        /// <param name="reason"></param>
        public Won(string reason) : base(reason) { }
    }
}