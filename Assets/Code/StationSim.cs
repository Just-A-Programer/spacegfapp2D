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

    private void Start()
    {
        for (int i = 0; i < SSMS.NumberOfModules; i++)
        {
            SSMS.ModuleAmount[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //modulesum
        SSMS.TotalModuleSum = 0;
        for (int i = 0; i < SSMS.NumberOfModules; i++)
        {
            SSMS.TotalModuleSum += SSMS.ModuleAmount[i];
        }

        budget = SSMS.TotalBudget;
        cost = SSMS.TotalCost;
        mass = SSMS.TotalMass;
        morale = SSMS.TotalMorale;


        //=== Sighs ===
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
        stats[2].text = (morale * 100) + "%";
        stats[2].color = new Color(1 - Mathf.Lerp(0, 1, ((float)morale)), Mathf.Lerp(0, 1, ((float)morale)), 0);

        //=== STATS ===

        //mass
        SSMS.TotalMass = 0;
        for (int i = 0; i < SSMS.NumberOfModules; i++)
        {
            SSMS.TotalMass += SSMS.ModuleMass[i] * SSMS.ModuleAmount[i];
        }

        //budget
        SSMS.TotalCost = 0;
        for (int i = 0; i < SSMS.NumberOfModules; i++)
        {
            SSMS.TotalCost += SSMS.ModulePrice[i] * SSMS.ModuleAmount[i];
        }

        //morale
        SSMS.TotalMorale = 0;
        float moralesum = 0;
        for (int i = 0; i < SSMS.NumberOfModules; i++)
        {
            if (SSMS.ModuleAmount[i] != 0)
                moralesum += 1 - 1 / ((float)SSMS.ModuleMorale[i] * (float)SSMS.ModuleAmount[i]);
        }
        Debug.Log(moralesum);
        if (SSMS.TotalModuleSum != 0)
            SSMS.TotalMorale = moralesum;
        else
            SSMS.TotalMorale = 0;
    }
}
