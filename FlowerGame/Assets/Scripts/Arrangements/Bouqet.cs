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

    [HideInInspector]
    public event EventHandler BouqetStatChangeEvent;

    Dictionary<FlowerStat, float> bouqetStats = new();

    Collider triggerHitbox;

    private void Awake()
    {
        triggerHitbox = GetComponent<Collider>();

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
    }

    // Stat Tracking
    private void ModifyBouqetStats(Flower flower, bool doSubtract = false)
    {
        int subtractionModifier = doSubtract ? -1 : 1;

        foreach(FlowerStatContainer statContainer in flower.GetFlowerStatsContainer())
        {
            bouqetStats[statContainer.stat] += subtractionModifier * statContainer.statAmount;
        }

        BouqetStatChangeEvent.Invoke(this, new EventArgs());
    }

    public Dictionary<FlowerStat, float> GetBouqetStats()
    {
        return bouqetStats;
    }

    // Locking / Unlocking Flowers
    public void LockFlowers()
    {
        triggerHitbox.enabled = false;

        foreach (Flower flower in flowerBundle)
            flower.Dragable.SetDraggingEnabled(false);
    }

    public void UnlockFlowers()
    {
        triggerHitbox.enabled = true;

        foreach (Flower flower in flowerBundle)
            flower.Dragable.SetDraggingEnabled(true);
    }
}
