using cfg.dialog;
using Managers;

namespace Statics
{
    public static class DialogStatics
    {
        public static DialogReaderDB DialogData = new DialogReaderDB(StaticManager.LoadJson("dialog_dialogreaderdb"));
    }
}