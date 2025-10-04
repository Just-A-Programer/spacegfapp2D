using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timertext;
    public SpaceStationModuleStats SSMS;
    float timer;
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

        if (Mathf.Floor(timer / 60) != 0)
            timertext.text = Mathf.Floor(timer / 60) + "m. " + Mathf.Ceil(timer % 60) + "s.";
        else
            timertext.text = Mathf.Ceil(timer % 60) + "s.";

        if (timer <= SSMS.TotalBuildTime && timer > 0.5 * SSMS.TotalBuildTime) { timertext.color = new Color(0, 1, 0); }
        else if (timer <= 0.5 * SSMS.TotalBuildTime && timer >= 0.1 * SSMS.TotalBuildTime) { timertext.color = new Color(1, 1, 0); }
        else { timertext.color = new Color(1, 0, 0); }
    }
}
