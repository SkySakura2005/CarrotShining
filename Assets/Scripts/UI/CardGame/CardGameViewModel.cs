using UI.CardGame.Contents;

namespace UI.CardGame
{
    public class CardGameViewModel:BaseViewModel
    {
        public CountdownContent countdown;
        protected override void Initialize()
        {
            countdown.StartCountdown();
        }

        protected override void ProcessString()
        {
            
        }

        protected override void UpdateView()
        {
            
        }

        protected override void UpdateModel()
        {
            
        }
    }
}