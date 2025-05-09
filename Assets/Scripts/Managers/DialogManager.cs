using System;
using System.Collections;
using System.IO;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class DialogManager:MonoBehaviour
    {
        private XmlReader _reader=XmlReader.Create(Application.dataPath + "/Resources/Dialogs/SampleDialog.xml");
        public Text personNameText;
        public Text dialogText;
        public Image backgroundImage;
        public GameObject dialogPanel;
        
        

        private void Start()
        {
            personNameText.text = string.Empty;
            dialogText.text = string.Empty;
            dialogPanel.SetActive(false);
            StartCoroutine(mainCoroutine());
        }

        private IEnumerator mainCoroutine()
        {
            while (_reader.Read())
            {
                if (_reader.NodeType == XmlNodeType.Element)
                {
                    switch (_reader.Name)
                    {
                        case "box":
                            Coroutine _dialogCoroutine = StartCoroutine(dialogCoroutine(_reader.ReadSubtree()));
                            yield return new WaitUntil(()=>_dialogCoroutine==null);
                            _reader.Skip();
                            break;
                    }
                }
            }
        }
        private IEnumerator dialogCoroutine(XmlReader subReader)
        {
            dialogPanel.SetActive(true);
            while (subReader.Read())
            {
                if (subReader.NodeType == XmlNodeType.Element)
                {
                    switch (subReader.Name)
                    {
                        case "name":
                            personNameText.text = subReader.ReadElementContentAsString();
                            break;
                        case "text":
                            string text = subReader.ReadElementContentAsString();
                            Coroutine _writingCoroutine=StartCoroutine(writingCoroutine(text));
                            while (true)
                            {
                                yield return null;
                                if (Input.GetMouseButtonDown(0))
                                {
                                    StopCoroutine(_writingCoroutine);
                                    dialogText.text = text;
                                    break;
                                }
                            }
                            while (true)
                            {
                                yield return null;
                                if(Input.anyKeyDown) break;
                            }
                            break;
                    }
                }
            }
            dialogPanel.SetActive(false);
        }

        private IEnumerator writingCoroutine(string text)
        {
            dialogText.text = string.Empty;
            for (int i = 0; i < text.Length; i++)
            {
                dialogText.text += text[i];
                yield return new WaitForSeconds(0.1f);
            }
            
        }

        public void DialogInvoke(string textname)
        {
            _reader=XmlReader.Create(Application.dataPath + "/Resources/Dialogs/"+textname+".xml");
            StartCoroutine(mainCoroutine());
        }
    }
}