using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    public GameObject ENDMASTERTEXT;
    public TextMeshProUGUI BIG_TEXT;
    public GameObject[] Resontext = new GameObject[4];
    public GameObject ENDSCREEN;
    public Image ENDSCREENIMG;
    public Animator ENDSCREENANIM;
    public TextMeshProUGUI timertext;
    public SpaceStationModuleStats SSMS;
    public Sprite[] endscreenimg;
    float timer;
    public float debug_Scenerio;

    public bool end;
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

        if (timer == 0 && !end) { WorldsEnd(); }
        if (Input.GetKeyDown(KeyCode.Mouse0) && end)
            restart();

        if (Mathf.Floor(timer / 60) != 0)
            timertext.text = Mathf.Floor(timer / 60) + "m. " + Mathf.Ceil(timer % 60) + "s.";
        else
            timertext.text = Mathf.Ceil(timer % 60) + "s.";

        if (timer <= SSMS.TotalBuildTime && timer > 0.5 * SSMS.TotalBuildTime) { timertext.color = new Color(0, 1, 0); }
        else if (timer <= 0.5 * SSMS.TotalBuildTime && timer >= 0.1 * SSMS.TotalBuildTime) { timertext.color = new Color(1, 1, 0); }
        else { timertext.color = new Color(1, 0, 0); }
    }
    public void restart()
    {
        end = false;

        StopAllCoroutines();
        ENDSCREEN.SetActive(false);
        ENDMASTERTEXT.SetActive(false);

        timer = SSMS.TotalBuildTime;

        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;

        Resontext[0].SetActive(false);
        Resontext[1].SetActive(false);
        Resontext[2].SetActive(false);
        Resontext[3].SetActive(false);
    }


    public void WorldsEnd()
    {
        
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;

        //game stats
        float budget    = SSMS.TotalCost;
        float maxbudget = SSMS.TotalBudget;
        float mass      = SSMS.TotalMass;
        float maxmass   = SSMS.TotalMaxMass;
        float morale    = SSMS.TotalMorale;
        
        float score = morale * (budget / maxbudget) * Mathf.Pow(mass / maxmass, -1);

        score = debug_Scenerio;

        ENDSCREEN.SetActive(true);

        

        if (debug_Scenerio == 4) { ENDSCREENIMG.sprite = endscreenimg[0]; ENDSCREENANIM.Play("win", 0); }
        else if (debug_Scenerio == 3) { ENDSCREENIMG.sprite = endscreenimg[3]; ENDSCREENANIM.Play("lose_long", 0); }
        else if (debug_Scenerio == 2) { ENDSCREENIMG.sprite = endscreenimg[2]; ENDSCREENANIM.Play("lose_medium", 0); }
        else if (debug_Scenerio == 1) { ENDSCREENIMG.sprite = endscreenimg[1]; ENDSCREENANIM.Play("lose_short", 0); }

        end = true;
        StartCoroutine(endcount(score));
    }

    IEnumerator endcount(float score)
    {
        if (score >= 0.85)
            yield return new WaitForSeconds(14.5f);
        else if (score >= 0.50 && score < 0.85)
            yield return new WaitForSeconds(13);
        else if (score >= 0.25 && score < 0.50)
            yield return new WaitForSeconds(10);
        else if (score < 0.25)
            yield return new WaitForSeconds(7);

        yield return new WaitForSeconds(1);
        end2();
    }

    public void end2()
    {
        ENDMASTERTEXT.SetActive(true);
        if (debug_Scenerio == 4) BIG_TEXT.text = "YOU HAVE WON";
        else BIG_TEXT.text = "YOU BLEW UP";

        if (debug_Scenerio == 1)
        {
            Resontext[0].SetActive(true);
            Resontext[1].SetActive(false);
            Resontext[2].SetActive(false);
            Resontext[3].SetActive(false);

        }
        else if (debug_Scenerio == 2)
        {
            Resontext[0].SetActive(false);
            Resontext[1].SetActive(true);
            Resontext[2].SetActive(false);
            Resontext[3].SetActive(false);
        }
        else if (debug_Scenerio == 3)
        {
            Resontext[0].SetActive(false);
            Resontext[1].SetActive(false);
            Resontext[2].SetActive(true);
            Resontext[3].SetActive(false);
        }
        else if (debug_Scenerio == 4)
        {
            Resontext[0].SetActive(false);
            Resontext[1].SetActive(false);
            Resontext[2].SetActive(false);
            Resontext[3].SetActive(true);
        }
    }
}
