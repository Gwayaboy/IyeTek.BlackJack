namespace IyeTek.BlackJack.Core.Domain.Enumerations.Statuses
{
    /// <summary>
    /// Status of a player in a draw
    /// </summary>
    public class Tied : Status
    {
        
        /// <param name="reason">reason of the draw</param>
        public Tied(string reason) : base(reason)
        {
        }
    }
}