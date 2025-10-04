using UnityEngine;

public class draw : MonoBehaviour
{
    public int drawID;
    public int currFloor;
    public GameObject[] SS_floor = new GameObject[3];
    public GameObject[] SS_prefabs = new GameObject[1];

    private void Start()
    {
        drawID = -1;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1)) { drawID = -1; }

        if (Input.GetKeyDown(KeyCode.Mouse0) && drawID != -1) { drawSS_mod(); }
    }

    void drawSS_mod()
    {
        Vector2 cursorclickPoss = Input.mousePosition;
        Vector3 cursorPoss_temp = Camera.main.ScreenToWorldPoint(new Vector3(cursorclickPoss.x, cursorclickPoss.y, Camera.main.nearClipPlane));
        Vector2 cursorPoss = new Vector2(cursorPoss_temp.x, cursorPoss_temp.y);

        GameObject new_mod = GameObject.Instantiate(SS_prefabs[drawID]);
        new_mod.transform.SetParent(SS_floor[currFloor].transform);
        new_mod.transform.position = new Vector3(Mathf.Floor(cursorPoss.x), Mathf.Floor(cursorPoss.y), 0);
        
    }

    public void SetDrawID(int ID)
    {
        drawID = ID;
    }
}
