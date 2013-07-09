using System;
using Humanizer;
using IyeTek.BlackJack.Core.Domain;
using IyeTek.BlackJack.Core.Domain.Base;
using IyeTek.BlackJack.Core.Domain.Enumerations;
using IyeTek.BlackJack.Core.Domain.Services;
using IyeTek.BlackJack.Core.Interfaces.Services;
using IyeTek.BlackJack.TestLibrary.Fakes;

namespace IyeTek.BlackJack.TestLibrary.Specification
{
    public abstract class ScenarioFor<TStory> : Specification
    {

        protected abstract Card[] CardsInShoe { get; }

        protected IShoeService ShoeService;
       protected Player HumanPlayer;
       protected Player ComputerDealer;

       protected BlackJackGameService SUT;
        
        public override Type Story
        {
            get { return typeof(TStory); }
        }

        public override void EstablishContext()
        {
            ShoeService = new OrderedShoeService(CardsInShoe);
            ComputerDealer = new ComputerDealer(ShoeService);
            HumanPlayer = new HumanPlayer(ShoeService);
            SUT = new BlackJackGameService(ComputerDealer, new[] {HumanPlayer});
        }

        protected override string BuildTitle()
        {

            var className = GetType().Name;
            var scenarioNumber = className.Substring(0, 3).Replace("_", "").Trim();
            var title = className.Substring(3);
            return string.Format("Scenario {0} - {1}", scenarioNumber, title.Humanize(LetterCasing.Sentence));
        }
    }
}