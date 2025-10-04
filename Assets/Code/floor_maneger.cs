using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class floor_maneger : MonoBehaviour
{
    public int currfloor;
    public TextMeshProUGUI text;
    public Sprite emptyGH;
    public Sprite fullGH;
    public Image[] gloryholes; 
    GameObject[] floors = new GameObject[3];


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        floors[0] = GameObject.FindGameObjectWithTag("SS0");
        floors[1] = GameObject.FindGameObjectWithTag("SS1");
        floors[2] = GameObject.FindGameObjectWithTag("SS2");

        gloryholes[0].sprite = emptyGH;
        gloryholes[1].sprite = emptyGH;
        gloryholes[2].sprite = emptyGH;
        gloryholes[currfloor].sprite = fullGH;
    }

    public void increaseFloorHeight()
    {
        if (currfloor < 2) { currfloor++; }

        text.text = "Floor: " + (currfloor + 1);

        floors[0].SetActive(false);
        floors[1].SetActive(false);
        floors[2].SetActive(false);
        floors[currfloor].SetActive(true);

        gloryholes[0].sprite = emptyGH;
        gloryholes[1].sprite = emptyGH;
        gloryholes[2].sprite = emptyGH;
        gloryholes[currfloor].sprite = fullGH;
    }

    public void decreaseFloorHeight()
    {
        if (currfloor > 0) { currfloor--; }

        text.text = "Floor: " + (currfloor + 1);

        floors[0].SetActive(false);
        floors[1].SetActive(false);
        floors[2].SetActive(false);
        floors[currfloor].SetActive(true);

        gloryholes[0].sprite = emptyGH;
        gloryholes[1].sprite = emptyGH;
        gloryholes[2].sprite = emptyGH;
        gloryholes[currfloor].sprite = fullGH;
    }
}
