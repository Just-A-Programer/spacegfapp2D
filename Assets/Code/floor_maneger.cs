using UnityEngine;

public class floor_maneger : MonoBehaviour
{
    public int currfloor;
    GameObject[] floors = new GameObject[3];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        floors[0] = GameObject.FindGameObjectWithTag("SS0");
        floors[1] = GameObject.FindGameObjectWithTag("SS1");
        floors[2] = GameObject.FindGameObjectWithTag("SS2");
    }

    public void increaseFloorHeight()
    {
        if (currfloor < 2) { currfloor++; }


        floors[0].SetActive(false);
        floors[1].SetActive(false);
        floors[2].SetActive(false);
        floors[currfloor].SetActive(true);
    }

    public void decreaseFloorHeight()
    {
        if (currfloor > 0) { currfloor--; }

        floors[0].SetActive(false);
        floors[1].SetActive(false);
        floors[2].SetActive(false);
        floors[currfloor].SetActive(true);
    }
}
