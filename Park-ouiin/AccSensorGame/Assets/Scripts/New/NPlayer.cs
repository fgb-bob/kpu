using UnityEngine;

public class NPlayer
{
    NCharacterController nCharacterController = new NCharacterController();

    public void Playing()
    {
        nCharacterController.Init();
        nCharacterController.Move();
    }
}
