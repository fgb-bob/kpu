using UnityEngine;

public class MyEnermy 
{
    public GameObject obj;
    public Rigidbody2D rigid;
    public CapsuleCollider2D capsule;
    public bool isMove;
    public float speed;

    public void Init()
    {
        obj = MyShare.Util.InstantiatePrefab(MyShare.Path.Prefab.Enermy, null);
        Debug.Log("Àû »ý¼º");
        SetPhysics();
        isMove = false;

        speed = Random.Range(3.0f, 10.0f);
    }

    public void SetPhysics()
    {
        obj.AddComponent<Rigidbody2D>();
        rigid = obj.GetComponent<Rigidbody2D>();
        rigid.freezeRotation = true;
        rigid.bodyType = RigidbodyType2D.Kinematic;

        obj.AddComponent<CapsuleCollider2D>();
        capsule = obj.GetComponent<CapsuleCollider2D>();
        capsule.offset = new Vector2(0, 0.2f);
        capsule.size = new Vector2(0.8f, 2.8f);
        capsule.isTrigger = true;
    }
}
