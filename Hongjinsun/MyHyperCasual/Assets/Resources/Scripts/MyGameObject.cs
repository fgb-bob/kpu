using UnityEngine;

public class MyGameObject
{
    private InputComponent input_;

    public MyGameObject(InputComponent input)
    {
        input_ = input;
    }

    public void Update()
    {
        input_.Update(this);
    }
}
