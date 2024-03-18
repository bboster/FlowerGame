using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Customer : MonoBehaviour
{
    [SerializeField]
    Pathing pathing;

    [SerializeField]
    List<FlowerStatContainer> desiredStats;

    [SerializeField]
    float maxStatCapacity = 1.25f;

    [SerializeField]
    float dollarsPerStatMult = 1;

    [Space]

    [Header("UI")]
    [SerializeField] TMP_Text OrderText;
    [SerializeField] TMP_Text MoneyText;
    [SerializeField] SymbolHolder symbols;
    [Space]
    [SerializeField] TMP_Text registerText;
    [SerializeField] GameObject UIBox;

    [SerializeField] AudioClip Pop;
    [SerializeField] AudioSource source;

    Dictionary<FlowerStat, float> desiredStatsDict = new();

    private void Awake()
    {
        //Used to make sure the UI is properly reset
        UIBox.SetActive(false);
        OrderText.text = "";
/*
        foreach(FlowerStatContainer statContainer in desiredStats)
        {
            desiredStatsDict[statContainer.stat.stat] = statContainer.statAmount;
        }
  */
    }

    public float CompareBouqetToDesired(Bouqet bouqet)
    {
        float score = 0;

        Dictionary<FlowerStat, float> bouqetStats = bouqet.GetBouqetStats();
        foreach (FlowerStat stat in desiredStatsDict.Keys)
        {
            if (!bouqetStats.ContainsKey(stat))
            {
                score -= 1;
                continue;
            }

            Debug.Log("Sending " + stat + " for " + desiredStatsDict[stat] * dollarsPerStatMult + " dollars.");
            score += Mathf.Clamp(bouqetStats[stat] / desiredStatsDict[stat], 0, maxStatCapacity) * desiredStatsDict[stat] * dollarsPerStatMult;
        }

        Debug.Log("----------------------------------------------------------------------------------------");

        SetMoodText(score);
        StartCoroutine(RemoveCanvas());

        CustomerManager.Instance.AddToRegister(score);
        return score;
    }

    private IEnumerator RemoveCanvas()
    {
        yield return new WaitForSeconds(2);
        UIBox.SetActive(false);
    }

    private float GetPredictedIncome()
    {
        float score = 0;

        foreach (FlowerStat stat in desiredStatsDict.Keys)
        {
            Debug.Log("Requesting " + stat + " for " + desiredStatsDict[stat] * dollarsPerStatMult + " dollars.");
            score += desiredStatsDict[stat] * dollarsPerStatMult;
        }

        return score;
    }

    public Pathing GetPathing()
    {
        return pathing;
    }

    //Displays the order for the player to see
    public void DisplayOrder()
    {
        source.PlayOneShot(Pop);
        OrderText.text = "";
        UIBox.SetActive(true);
        foreach(FlowerStatContainer flower in desiredStats)
        {
            string output = "";
            output += flower.stat.stat + ": ";

            output += flower.statAmount;

            OrderText.text += output;
            OrderText.text += "\n";

            //Debug.Log(output);
        }
        OrderText.text += "\n";

        var scoreVar = System.Math.Round(GetPredictedIncome(), 3);

        MoneyText.text = "$" + scoreVar.ToString("F2");
    }

    public void SetRegisterText(string text)
    {
        registerText.text = "$" + text;
    }

    public void SetMoodText(float score)
    {
        float predicted = GetPredictedIncome();
        string moodText = "";

        Debug.Log("Score: " + score);
        Debug.Log("Predicted: " + predicted);

        switch(score - predicted)
        {
            case float n when (n > 0):
                moodText = ":D";
                break;
            case float n when (n == 0):
                moodText = ":)";
                break;
            case float n when (n < 0):
                moodText = ":|";
                break;
            case float n when (n < -10):
                moodText = ":(";
                break;
            case float n when (n > -50):
                moodText = "D:<";
                break;
        }

        OrderText.text = moodText;
    }

    public void SetRequest(CustomerRequest request)
    {
        desiredStats = request.GetFlowerStatContainers();
        Debug.Log("Setting customer Request");
        foreach (FlowerStatContainer container in desiredStats)
        {
            Debug.Log("Stat: " + container.stat + " | Stat Amount: " + container.statAmount);
            desiredStatsDict[container.stat.stat] = container.statAmount;
        }
            

        symbols.GenerateSymbols(desiredStats);
    }
}
