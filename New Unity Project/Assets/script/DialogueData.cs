
using UnityEngine;

namespace Poly
{
    /// <summary>
    /// ��ܸ��
    /// </summary>
    [CreateAssetMenu(menuName ="Poly/Dialogue Data",fileName = "New Dialogue Date")]
    public class DialogueData : ScriptableObject
    {
        [Header("��ܦW��")]
        public string dialogueName;
        [Header("��ܪ̤��e"), TextArea(2, 10)]
        public string[] dialogueContens;
    }

}
