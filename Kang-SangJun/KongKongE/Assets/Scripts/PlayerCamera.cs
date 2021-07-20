using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera
{
    private Camera cam;
    private Player player;

    public void init()
    {
        cam = Camera.main;
        
    }

    public void onPlayer(GameObject player)
    {
        cam.transform.position = player.transform.position + new Vector3(0, 5.5f, -8);
        cam.transform.LookAt(player.transform.position);
    }
}  
