using Managers;

namespace Objects
{
    public class Desk:BaseObject
    {
        protected override void OnEvent()
        {
            ContentManager.Instance.Push("Calendar");
        }
    }
}