using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FGB_Camera
{
    private Camera cam;
    private FGB_Player player;

    public void Init()
    {
        cam = Camera.main;
        
    }

    public void onPlayer(GameObject player)
    {
        cam.transform.position = player.transform.position + new Vector3(0, 5.5f, -8);
        cam.transform.LookAt(player.transform.position);
    }
}  
