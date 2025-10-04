using System.ComponentModel;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class StationSim : MonoBehaviour
{
    public SpaceStationModuleStats SSMS;
    public TextMeshProUGUI[] stats;
    int budget;
    int cost;
    private void Start()
    {
        budget = SSMS.TotalBudget;
        cost = SSMS.TotalCost;
    }

    // Update is called once per frame
    void Update()
    {
        stats[0].text = "Budget: " + budget + " / " + cost;
        if (budget > cost)  { stats[0].color = new Color(0,1,0); }
        if (budget == cost) { stats[0].color = new Color(1,1,0); }
        if (budget < cost)  { stats[0].color = new Color(1,0,0); }


    }
}
