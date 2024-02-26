using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ArrangementCanvas : MonoBehaviour
{
    [Header("External Assignments")]
    [SerializeField]
    ArrangementTable arrangementTable;

    [Header("Canvas Assignments")]
    [SerializeField]
    TMP_Text statsText;

    [Space]

    [SerializeField]
    Button confirmButton;

    [SerializeField]
    TMP_Text confirmButtonText;

    Dictionary<ConfirmButtonState, string> confirmButtonLabels = new();

    private void Awake()
    {
        confirmButtonLabels[ConfirmButtonState.CONFIRM] = "Lock Bouqet";
        confirmButtonLabels[ConfirmButtonState.RESET] = "Unlock Bouqet";

        SetButtonAsConfirm();
    }

    public void SetStatsText(string newText)
    {
        statsText.text = newText;
    }

    public void SetConfirmButtonState(ConfirmButtonState state)
    {
        switch (state){
            case (ConfirmButtonState.CONFIRM):
                SetButtonAsConfirm();
                return;
            case (ConfirmButtonState.RESET):
                SetButtonAsReset();
                return;
        }
    }

    private void SetButtonAsConfirm()
    {
        confirmButtonText.text = confirmButtonLabels[ConfirmButtonState.CONFIRM];

        confirmButton.onClick.AddListener(ConfirmBouqet);
        confirmButton.onClick.RemoveListener(ResetBouqet);
    }

    private void ConfirmBouqet()
    {
        arrangementTable.LockBouqet();

        SetConfirmButtonState(ConfirmButtonState.RESET);
    }

    private void SetButtonAsReset()
    {
        confirmButtonText.text = confirmButtonLabels[ConfirmButtonState.RESET];

        confirmButton.onClick.AddListener(ResetBouqet);
        confirmButton.onClick.RemoveListener(ConfirmBouqet);
    }

    private void ResetBouqet()
    {
        arrangementTable.UnlockBouqet();

        SetConfirmButtonState(ConfirmButtonState.CONFIRM);
    }
}

public enum ConfirmButtonState
{
    CONFIRM,
    RESET
}
