using UnityEngine;

public abstract class InputComponent 
{
    virtual public void Update(MyGameObject obj)
    {
        Debug.Log("InputComponent�� ������Ʈ");
    }


}
