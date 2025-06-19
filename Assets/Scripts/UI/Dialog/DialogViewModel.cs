using System;
using System.Collections;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Dialog
{
    public class DialogViewModel:BaseViewModel
    {
        public Text wordText;
        public Text nameText;
        public GameObject dialogBox;
        
        private DialogSystem _dialogSystem;
        private DialogCommand _dialogCommand;

        private bool isTypeWriterEnd;
        protected override void Initialize()
        {
            if (args.Length != 1)
            {
                Debug.LogError("DialogViewModel: args must contain one argument");
            }
            _dialogSystem=new DialogSystem(args[0]);
            _dialogCommand = GetComponent<DialogCommand>();
            StartCoroutine(DialogProcessCoroutine());
        }

        private IEnumerator DialogProcessCoroutine()
        {
            string person="";
            string text="";
            dialogBox.gameObject.SetActive(false);
            while (_dialogSystem.ExecuteDialog(ref person,ref text)!=-1)
            {
                nameText.text = person;
                wordText.text = "";
                dialogBox.gameObject.SetActive(person!=string.Empty&&text!=string.Empty);
                yield return new WaitForSeconds(0.2f);
                isTypeWriterEnd=false;
                Coroutine writingCorotine = StartCoroutine(WritingCoroutine(text));
                while (!isTypeWriterEnd)
                {
                    if(_dialogCommand.anykeyIsDown)
                    {
                        StopCoroutine(writingCorotine);
                        wordText.text = text;
                        yield return new WaitForSeconds(0.6f);
                        break;
                    }
                    yield return null;
                }

                while (true)
                {
                    if (_dialogCommand.anykeyIsDown) break;
                    yield return null;
                }
            }
            ContentManager.Instance.Pop();
        }

        private IEnumerator WritingCoroutine(string text)
        {
            foreach (char c in text)
            {
                wordText.text += c;
                yield return new WaitForSeconds(0.1f);
            }
            isTypeWriterEnd=true;
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