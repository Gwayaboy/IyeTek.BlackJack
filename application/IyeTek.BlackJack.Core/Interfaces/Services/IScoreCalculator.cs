using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Domain.Base;

namespace IyeTek.BlackJack.Core.Interfaces.Services
{
    public interface IScoreCalculator
    {
        int Calculate(Hand hand);
    }
}