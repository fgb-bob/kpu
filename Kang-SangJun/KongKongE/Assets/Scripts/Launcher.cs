using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    //런처에서 객체들 관리하는 매니저 초기화 및 업데이트 해주구요
    //모노 상속 안받아도 프리팹 생성해서 gameObject 처리 가능합니다
    //결국 런처에서 객체관리자를 통해 객체가 관리되고.모노 없이 런처를 통해서 필요한 핸들링 하시면 됩니다
    //대부분은 런천 통하지 않고 유니티 스크립트 사용 가능하구요.


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
