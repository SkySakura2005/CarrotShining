using UnityEngine.UI;

namespace UI.Calendar
{
    public class CalendarCommand:BaseCommand
    {
        public Button[] SelectButtons=new Button[4];

        public CalendarViewModel _viewModel;
        public override void AddListeners()
        {
            for (int i = 0; i < 4; i++)
            {
                int index = i;
                SelectButtons[i].onClick.AddListener(()=>
                {
                    OnIconButtonClick(index);
                });
            }
        }

        public override void RemoveListeners()
        {
            for (int i = 0; i < 4; i++)
            {
                int index = i;
                SelectButtons[i].onClick.RemoveAllListeners();
            }
        }

        private void OnIconButtonClick(int index)
        {
            _viewModel.mActiveSelection = index;
        }
    }
}