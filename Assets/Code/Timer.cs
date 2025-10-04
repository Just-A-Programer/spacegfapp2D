using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public GameObject ENDSCREEN;
    public Animator ENDSCREENANIM;
    public TextMeshProUGUI timertext;
    public SpaceStationModuleStats SSMS;
    float timer;
    public float debug;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = SSMS.TotalBuildTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0) { timer -= Time.deltaTime; }
        if (timer < 0) { timer = 0; }

        if (timer == 0) { WorldsEnd(); }

        if (Mathf.Floor(timer / 60) != 0)
            timertext.text = Mathf.Floor(timer / 60) + "m. " + Mathf.Ceil(timer % 60) + "s.";
        else
            timertext.text = Mathf.Ceil(timer % 60) + "s.";

        if (timer <= SSMS.TotalBuildTime && timer > 0.5 * SSMS.TotalBuildTime) { timertext.color = new Color(0, 1, 0); }
        else if (timer <= 0.5 * SSMS.TotalBuildTime && timer >= 0.1 * SSMS.TotalBuildTime) { timertext.color = new Color(1, 1, 0); }
        else { timertext.color = new Color(1, 0, 0); }
    }

    public void WorldsEnd()
    {
        //game stats
        float budget    = SSMS.TotalCost;
        float maxbudget = SSMS.TotalBudget;
        float mass      = SSMS.TotalMass;
        float maxmass   = SSMS.TotalMaxMass;
        float morale    = SSMS.TotalMorale;
        
        float score = morale * (budget / maxbudget) * Mathf.Pow(mass / maxmass, -1);

        score = debug;

        ENDSCREEN.SetActive(true);

        if (score >= 0.85) { ENDSCREENANIM.Play("win", 0); }
        else if (score >= 0.50 && score < 0.85) { ENDSCREENANIM.Play("lose_long", 0); }
        else if (score >= 0.25 && score < 0.50) { ENDSCREENANIM.Play("lose_medium", 0); }
        else if (score < 0.25) { ENDSCREENANIM.Play("lose_short", 0); }
    }
}
