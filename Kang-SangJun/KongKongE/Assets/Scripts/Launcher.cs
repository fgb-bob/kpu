using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    //��ó���� ��ü�� �����ϴ� �Ŵ��� �ʱ�ȭ �� ������Ʈ ���ֱ���
    //��� ��� �ȹ޾Ƶ� ������ �����ؼ� gameObject ó�� �����մϴ�
    //�ᱹ ��ó���� ��ü�����ڸ� ���� ��ü�� �����ǰ�.��� ���� ��ó�� ���ؼ� �ʿ��� �ڵ鸵 �Ͻø� �˴ϴ�
    //��κ��� ��õ ������ �ʰ� ����Ƽ ��ũ��Ʈ ��� �����ϱ���.


    private Scene GameScene;

    // Start is called before the first frame update
    void Start()
    {
        GameScene = new Scene();
        GameScene.init();
    }

    // Update is called once per frame
    void Update()
    {
        GameScene.Update();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            Debug.Log("Sibal");
    }
}
