using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController characterController = new CharacterController();

    public void Playing()
    {
        characterController.Init();
        characterController.Move();
    }
}
