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
    int mass;
    float morale;
    float COS;

    // Update is called once per frame
    void Update()
    {
        budget = SSMS.TotalBudget;
        cost = SSMS.TotalCost;
        mass = SSMS.TotalMass;
        morale = SSMS.TotalMorale;
        //COS = SSMS.TotalChanceOFSucsess;

        //budget
        stats[0].text = budget + " / " + cost;
        if (budget > cost)  { stats[0].color = new Color(0,1,0); }
        if (budget == cost) { stats[0].color = new Color(1,1,0); }
        if (budget < cost)  { stats[0].color = new Color(1,0,0); }

        //mass
        stats[1].text = SSMS.TotalMaxMass + " kg / " + mass + " kg";
        stats[1].color = new Color(Mathf.Lerp(0, 1, ((float)mass / (float)SSMS.TotalMaxMass)), 1 - Mathf.Lerp(0, 1, ((float)mass / (float)SSMS.TotalMaxMass)), 0); 
        if (mass >= SSMS.TotalMaxMass) { stats[1].color = new Color(0.5f, 0, 0); }

        //Morale
        stats[2].text = morale + "%";
        stats[2].color = new Color(1 - Mathf.Lerp(0, 1, ((float)morale / (float)100f)), Mathf.Lerp(0, 1, ((float)morale / (float)100f)), 0);

        /*//COS
        stats[3].text = COS + "%";
        stats[3].color = new Color(1 - Mathf.Lerp(0, 1, ((float)COS / (float)100f)), Mathf.Lerp(0, 1, ((float)COS / (float)100f)), 0);*/

        
    }
}
