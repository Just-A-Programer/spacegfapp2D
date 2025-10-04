using UnityEngine;

public class SScursor : MonoBehaviour
{
    public draw d;
    public Sprite[] SSmodSprites;
    public Transform cursorGB;
    public SpriteRenderer curserSprite;
    public Vector2 offset;
    int drawID;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        cursorGB.position = new Vector3(pos.x + offset.x, pos.y + offset.y, 0);

        drawID = d.drawID;
        if (drawID == -1)
        {
            curserSprite.sprite = null;
        }
        else
        {
            curserSprite.sprite = SSmodSprites[drawID];
        }
    }
}
