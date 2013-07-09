using IyeTek.BlackJack.Core.Domain.Base;

namespace IyeTek.BlackJack.Core.Domain.Enumerations.Statuses
{
    /// <summary>
    /// This is the initial status of player when the game starts
    /// </summary>
    public class Playing : Status
    {
        public Playing() : base(string.Empty) { }

        /// <summary>
        /// Calculare the player's hand score and if goes bust then changes his status to loose
        /// </summary>
        /// <param name="player">state context</param>
        /// <returns>player's hand score</returns>
        public override int CalculateScore(Player player)
        {
            var score = base.CalculateScore(player);
            if (score > 21)
            {
                player.Status = new Lost(string.Format("{0} went bust",player.Name));
            }

            return score;
        }
    }
}