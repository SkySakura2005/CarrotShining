using System.Collections.Generic;
using System.Linq;
using cfg.dialog;
using Statics;

namespace System
{
    
    public class DialogSystem
    {
        private string currentID;
        private int currentIndex;
        private List<DialogDB> dialogs = new List<DialogDB>();
        public DialogSystem(string tag)
        {
            dialogs=(from dialogData in DialogStatics.DialogData.DataList
                    where dialogData.DialogTag == tag
                    select dialogData).ToList();
            currentID=dialogs[0].ID;
            currentIndex=0;
        }

        public int ExecuteDialog(ref string name, ref string text)
        {
            if (currentID == "-1")
            {
                name = null;
                text = null;
                return -1;
            }
            
            name=dialogs[currentIndex].Name;
            text=dialogs[currentIndex].Text;
            name = name.Replace("#name#", CharacterStatics.PlayerName);
            text=text.Replace("#name#", CharacterStatics.PlayerName);
            if (dialogs[currentIndex].Choice.Count==0)
            {
                currentID=dialogs[currentIndex].NextID;
                currentIndex=dialogs.FindIndex(dialog => dialog.ID == currentID);
                return 0;
            }
            return 1;
        }

        public void MakeChoice()
        {
            
        }
    }
}