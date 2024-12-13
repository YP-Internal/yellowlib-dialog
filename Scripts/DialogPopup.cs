using Febucci.UI;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using PopupWindow = YellowPanda.Popup.PopupWindow;

namespace YellowPanda.Dialog
{
    public class DialogPopup : PopupWindow, IPointerClickHandler
    {
        [SerializeField] GameObject namePanelContainer;
        [SerializeField] TextMeshProUGUI nameText;
        [SerializeField] TextMeshProUGUI dialogText;
        [SerializeField] TypewriterByCharacter textAnimator;
        [SerializeField] Image imageIcon;

        DialogSO _dialog;
        int _currentDialogIndex;
        Coroutine _typewriterRoutine;

        public void OpenDialog(DialogSO dialog)
        {
            this._dialog = dialog;
            _currentDialogIndex = 0;
            dialogText.text = "";
            BeginDialog(dialog.dialogs[_currentDialogIndex]);
        }

        void BeginDialog(DialogSO.Dialog dialog)
        {
            if (_typewriterRoutine != null)
                StopCoroutine(_typewriterRoutine);

            if (!dialog.name.IsEmpty)
            {
                namePanelContainer.SetActive(true);
                nameText.text = dialog.name.GetLocalizedString();
            }
            else
            {
                namePanelContainer.SetActive(false);
            }

            imageIcon.sprite = dialog.icon;
            dialogText.text = dialog.dialog.GetLocalizedString();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (textAnimator.isShowingText)
            {
                textAnimator.SkipTypewriter();
            }
            else
            {
                _currentDialogIndex++;

                if (_currentDialogIndex >= _dialog.dialogs.Length)
                {
                    ClosePopup();
                }
                else
                {
                    BeginDialog(_dialog.dialogs[_currentDialogIndex]);
                }
            }
        }
    }
}