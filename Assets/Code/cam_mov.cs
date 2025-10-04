using Unity.Mathematics;
using UnityEngine;

public class cam_mov : MonoBehaviour
{
    Camera cam;
    Vector3 mov_vec;
    public float speed;
    public float sprint_mult;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        mov_vec = new Vector3();
        float multiplayer = 1;

        if (Input.GetKey(KeyCode.W))
        {
            mov_vec.y++;
        }
        if (Input.GetKey(KeyCode.S))
        {
            mov_vec.y--;
        }
        if (Input.GetKey(KeyCode.D))
        {
            mov_vec.x++;
        }
        if (Input.GetKey(KeyCode.A))
        {
            mov_vec.x--;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            multiplayer = sprint_mult;
        }

        mov_vec.Normalize();

        mov_vec *= speed * Time.deltaTime * multiplayer;
        cam.transform.position = cam.transform.position + mov_vec;
    }
}
