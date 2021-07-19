using UnityEngine;

public class PlayerInputComponent : InputComponent
{
    override public void Update(MyGameObject obj)
    {
        Debug.Log("PlayerInputComponent의 업데이트");
    }

}
