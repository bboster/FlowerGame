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
        playerController.ToggleInteractText(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        isPlayerInHitbox = false;
        playerController.ToggleInteractText(false);
    }

    public void ToggleArrangmentMode()
    {
        if (!isPlayerInHitbox)
            return;

        isPlayerArranging = !isPlayerArranging;

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

        if (CustomerManager.Instance.currentCustomer == null)
            return;

        CustomerManager.Instance.currentCustomer.GetPathing().SubmitBouqet(bouqet);

        Destroy(bouqet.transform.parent.gameObject);
    }

    public void ClearInventory()
    {
        if (!isPlayerInHitbox)
            return;

        Inventory inv = playerController.GetComponent<Inventory>();
        
        inv.ClearInventory();

        playerController.flowers.Clear();
    }
}
