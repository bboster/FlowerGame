using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField]
    PlayerController playerController;

    [SerializeField]
    ArrangementTable arrangementTable;

    bool isPlayerInHitbox = false;

    bool isPlayerArranging = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        isPlayerInHitbox = true;
        playerController.ToggleToPickText(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        isPlayerInHitbox = false;
        playerController.ToggleToPickText(false);
    }

    public void ToggleArrangmentMode()
    {
        if (!isPlayerInHitbox)
            return;

        isPlayerArranging = !isPlayerArranging;

        PlayerState newState = isPlayerArranging ? PlayerState.ARRANGING : PlayerState.MOVING;
        playerController.currentState = newState;

        arrangementTable.ToggleArrangementView();
        playerController.ToggleToPickText(!isPlayerArranging);
    }

    public void SubmitBouqet()
    {
        if (!isPlayerInHitbox)
            return;

        Bouqet bouqet = PlayerManager.Instance.GetPlayer().PlayerPicker.GetBouqet();
        if (bouqet == null)
            return;


    }
}
