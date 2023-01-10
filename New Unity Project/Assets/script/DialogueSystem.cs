using UnityEngine;
using TMPro;
using System.Collections;


namespace Poly
{
  public class DialogueSystem : MonoBehaviour
  {
        #region ��ưϰ�
        [SerializeField, Header("��ܶ��j"), Range(0, 0.5f)]
        private float dialogueIntervaTime = 0.1f;
        [SerializeField, Header("�}�Y���")]
        private DialogueData dialogueOpening;
        [SerializeField, Header("��ܫ���")]
        private KeyCode dialogueKey = KeyCode.Space;
        private WaitForSeconds dialogueInterval => new WaitForSeconds(dialogueIntervaTime);

        private CanvasGroup groupDialogue;
        private TextMeshProUGUI textName;
        private TextMeshProUGUI textContent;
        private GameObject goTriangle;
        #endregion

        #region �ƥ�
        private void Awake()
        {
            groupDialogue = GameObject.Find("�e����ܨt��").GetComponent<CanvasGroup>();
            textName = GameObject.Find("��ܪ̦W��").GetComponent<TextMeshProUGUI>();
            textContent = GameObject.Find("��ܤ��e").GetComponent<TextMeshProUGUI>();
            goTriangle = GameObject.Find("��ܧ����ϥ�");
            goTriangle.SetActive(false);

           StartDialogue(dialogueOpening);
            
        }
        #endregion

     
        public void StartDialogue(DialogueData data)
        {
            StartCoroutine(FadeGroup());
            StartCoroutine(TypeEffect(data));
        }
        

        private IEnumerator FadeGroup(bool fadeIn = true)
        {

            float increase = fadeIn ? +0.1f : -0.1f;

            for (int i = 0; i < 10;i++)
            {
                groupDialogue.alpha += increase;
                yield return new WaitForSeconds(0.04f);
            }

        }

        private IEnumerator TypeEffect(DialogueData data)
        {
            textName.text = data.dialogueName;

            for (int j = 0; j < data.dialogueContens.Length; j++)
            {
                textContent.text = "";
                goTriangle.SetActive(false);
                string dialogue = data.dialogueContens[j];

                for (int i = 0; i < dialogue.Length; i++)
                {
                    textContent.text += dialogue[i];
                    yield return dialogueInterval;
                }
                goTriangle.SetActive(true);


                while (!Input.GetKeyDown(dialogueKey))
                {
                    yield return null;
                }
                print("<color=#993300>���a���U����!</color>");
            }

            StartCoroutine(FadeGroup(false));
        }
    }
}

