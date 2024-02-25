using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouqetDetector : MonoBehaviour
{
    
    ArrangementTable arrangementTable;

    Player player;

    private void Start()
    {
        arrangementTable = ArrangementTable.Instance;
        player = PlayerManager.Instance.GetPlayer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Bouqet"))
            return;

        player.PlayerPicker.SetBouqet(arrangementTable.GetBouqet());

        arrangementTable.ResetBouqet();
        arrangementTable.ToggleArrangementView();
    }
}
