using UnityEngine;

public class MyCamera
{
    Camera camera;
    GameObject player;

    public void Init()
    {
        //camera = GameObject.Find("Main Camera");
        camera = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        //camera.transform.position = new Vector3(player.transform.position.x, 0, -2);
        camera.transform.position = new Vector3(0, 0, -2);

    }
}
