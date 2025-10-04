using System.Linq;
using UnityEngine;

public class draw : MonoBehaviour
{
    public floor_maneger fm;

    public int drawID;
    public GameObject[] SS_floor = new GameObject[3];
    public GameObject[] SS_prefabs = new GameObject[1];
    int currFloor;
    Vector2[] takenSpace0 = new Vector2[45];
    Vector2[] takenSpace1 = new Vector2[45];
    Vector2[] takenSpace2 = new Vector2[45];
    int[] takenIndex = new int[3];

    private void Start()
    {
        drawID = -1;

        takenIndex[0] = 1;
        takenIndex[1] = 1;
        takenIndex[2] = 1;

        takenSpace0[0] = new Vector2(0, 0);
        takenSpace1[0] = new Vector2(0, 0);
        takenSpace2[0] = new Vector2(0, 0);
    }
    // Update is called once per frame
    void Update()
    {
        currFloor = fm.currfloor;

        if (Input.GetKeyDown(KeyCode.Mouse1)) { drawID = -1; }

        if (Input.GetKey(KeyCode.Mouse0) && drawID != -1) { drawSS_mod(); }
    }

    void drawSS_mod()
    {
        Vector2 cursorclickPoss = Input.mousePosition;
        Vector3 cursorPoss_temp = Camera.main.ScreenToWorldPoint(new Vector3(cursorclickPoss.x, cursorclickPoss.y, Camera.main.nearClipPlane));
        Vector2 cursorPoss = new Vector2(cursorPoss_temp.x, cursorPoss_temp.y);

        Vector2 new_pos = new Vector2(Mathf.Round(cursorPoss.x), Mathf.Round(cursorPoss.y));

        if (!(new_pos.x > -4 && new_pos.x < 4))
            return;
        if (!(new_pos.y > -4 && new_pos.y < 4))
            return;
        if (new_pos.y == -3 && (new_pos.x == -3 || new_pos.x == 3))
            return;
        if (new_pos.y == 3 && (new_pos.x == -3 || new_pos.x == 3))
            return;

        if (currFloor == 0) {
            for (int i = 0; i < takenSpace0.Length; i++)
            {
                if (new_pos == takenSpace0[i]) { return; }
            }

            takenSpace0[takenIndex[0]] = new_pos;
            takenIndex[0]++;
        }
        else if (currFloor == 1)
        {
            for (int i = 0; i < takenSpace1.Length; i++)
            {
                if (new_pos == takenSpace1[i]) { return; }
            }

            takenSpace1[takenIndex[1]] = new_pos;
            takenIndex[1]++;
        }
        else if (currFloor == 2)
        {
            for (int i = 0; i < takenSpace2.Length; i++)
            {
                if (new_pos == takenSpace2[i]) { return; }
            }

            takenSpace2[takenIndex[2]] = new_pos;
            takenIndex[2]++;
        }

        GameObject new_mod = GameObject.Instantiate(SS_prefabs[drawID]);
        new_mod.transform.SetParent(SS_floor[currFloor].transform);


        new_mod.transform.position = new Vector3(new_pos.x, new_pos.y, 0);
        
        
    }

    public void SetDrawID(int ID)
    {
        drawID = ID;
    }
}
