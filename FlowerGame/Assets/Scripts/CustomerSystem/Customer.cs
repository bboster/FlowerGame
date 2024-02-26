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

    [SerializeField] TMP_Text OrderText;
    [SerializeField] TMP_Text registerText;
    [SerializeField] GameObject UIBox;

    Dictionary<FlowerStat, float> desiredStatsDict = new();

    private void Awake()
    {
        //Used to make sure the UI is properly reset
        UIBox.SetActive(false);
        OrderText.text = "";

        foreach(FlowerStatContainer statContainer in desiredStats)
        {
            desiredStatsDict[statContainer.stat] = statContainer.statAmount;
        }
    }

    private void Start()
    {
        CustomerManager.Instance.SetCustomer(this);
    }

    public float CompareBouqetToDesired(Bouqet bouqet)
    {
        float score = 0;

        Dictionary<FlowerStat, float> bouqetStats = bouqet.GetBouqetStats();
        foreach (FlowerStat stat in desiredStatsDict.Keys)
        {
            if (!bouqetStats.ContainsKey(stat))
            {
                //score -= 1;
                continue;
            }

            score += Mathf.Clamp(bouqetStats[stat] / desiredStatsDict[stat], 0, maxStatCapacity) * desiredStatsDict[stat] * dollarsPerStatMult;
        }

        var scoreVar = System.Math.Round(score, 3);
        
        SetRegisterText(scoreVar.ToString("F2"));
        return score;
    }

    private float GetPredictedIncome()
    {
        float score = 0;

        foreach (FlowerStat stat in desiredStatsDict.Keys)
        {
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
        OrderText.text = "";
        UIBox.SetActive(true);
        foreach(FlowerStatContainer flower in desiredStats)
        {
            string output = "";

            switch(flower.stat)
            {
                case FlowerStat.LOVE:
                    output += "Love: ";
                    break;
                case FlowerStat.HEALTH:
                    output += "Health: ";
                    break;
                case FlowerStat.GREETING:
                    output += "Greeting: ";
                    break;
                case FlowerStat.FORTUNE:
                    output += "Fortune: ";
                    break;
                case FlowerStat.REMEMBRANCE:
                    output += "Remembrance: ";
                    break;
                case FlowerStat.SORROW:
                    output += "Sorrow: ";
                    break;
                case FlowerStat.FILLER:
                    output += "Filler: ";
                    break;
                default:
                    output += "error";
                    break;
            }

            output += flower.statAmount;

            OrderText.text += output;
            OrderText.text += "\n";

            //Debug.Log(output);
        }
        OrderText.text += "\n";

        var scoreVar = System.Math.Round(GetPredictedIncome(), 3);

        OrderText.text += "$" + scoreVar.ToString("F2");
    }

    public void SetRegisterText(string text)
    {
        registerText.text = "$" + text;
    }
}
