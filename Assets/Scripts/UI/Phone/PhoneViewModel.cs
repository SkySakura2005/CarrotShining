using UnityEngine;

namespace UI.Phone
{
    public struct PhonePages
    {
        public PhonePages(int father, GameObject pageGameObject)
        {
            Father = father;
            PageGameObject = pageGameObject;
        }
        public int Father;
        public GameObject PageGameObject;
    }
    public class PhoneViewModel:BaseViewModel
    {
        public PhonePages[] pages = new PhonePages[3];
        protected override void Initialize()
        {
            
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