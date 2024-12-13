using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "New dialog", menuName = "YellowLib/Dialog/Dialog")]
public class DialogSO : ScriptableObject
{
    [System.Serializable]
    public struct Dialog
    {
        public LocalizedString dialog;
        public LocalizedString name;
        public Sprite icon;
    }

    public Dialog[] dialogs;
}
