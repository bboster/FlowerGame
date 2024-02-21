using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;

public class Bouqet : MonoBehaviour
{

    [Header("Assignments")]
    [SerializeField]
    LayerMask flowers;

    [SerializeField]
    LayerMask nothing;

    [SerializeField]
    TMP_Text tmpText;

    List<Flower> flowerBundle = new();

    Dictionary<FlowerStat, float> bouqetStats = new();

    private void Awake()
    {
        // Reset Text
        tmpText.text = "";

        // Assign default FlowerStat values
        List<FlowerStat> flowerStatValues = Enum.GetValues(typeof(FlowerStat)).Cast<FlowerStat>().ToList();
        foreach (FlowerStat value in flowerStatValues)
            bouqetStats[value] = 0;
    }

    // Registering Flowers
    private void OnTriggerEnter(Collider other)
    {
        AddFlower(other);
    }

    private void OnTriggerExit(Collider other)
    {
        RemoveFlower(other);
    }

    private void AddFlower(Collider other)
    {
        if (!other.CompareTag("Flower"))
            return;

        Dragable flowerDragable = other.GetComponent<Dragable>();
        Flower flower = other.GetComponent<Flower>();

        if (flowerDragable != ArrangementTable.Instance.GetSelectedObject())
            return;

        other.attachedRigidbody.includeLayers = nothing;

        flowerDragable.SetParent(transform);

        flowerBundle.Add(flower);

        ModifyBouqetStats(flower);
        UpdateUI();
    }

    private void RemoveFlower(Collider other)
    {
        if (!other.CompareTag("Flower"))
            return;

        other.attachedRigidbody.includeLayers = flowers;

        Dragable flowerDragable = other.GetComponent<Dragable>();
        Flower flower = other.GetComponent<Flower>();

        flowerDragable.SetParent(null);

        if (!flowerDragable.IsBeingDragged)
            flowerDragable.EnablePhysics();

        flowerBundle.Remove(flower);

        ModifyBouqetStats(flower, true);
        UpdateUI();
    }

    // Stat Tracking
    private void ModifyBouqetStats(Flower flower, bool doSubtract = false)
    {
        int subtractionModifier = doSubtract ? -1 : 1;

        foreach(FlowerStatContainer statContainer in flower.GetFlowerStatsContainer())
            bouqetStats[statContainer.stat] += subtractionModifier * statContainer.statAmount;
    }

    // UI
    private void UpdateUI()
    {
        if (tmpText == null)
            return;
        string outputString = "";
        foreach(FlowerStat flowerStat in bouqetStats.Keys)
        {
            if (bouqetStats[flowerStat] == 0)
                continue;

            outputString += "" + flowerStat + ": " + bouqetStats[flowerStat] + "\n";
        }

        tmpText.text = outputString;
    }
}
