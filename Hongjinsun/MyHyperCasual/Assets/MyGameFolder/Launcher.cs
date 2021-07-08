using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Launcher : MonoBehaviour, IButton
{
    GameObject uiRoot;
    GameObject background;
    GameObject collisionObject;
    GameObject player;
    GameObject[] enermy;
    Player myPlayer = new Player();
    PlayerController myPlayerController = new PlayerController();
    Enermy myEnermy = new Enermy();
    EnermyController myEnermyController = new EnermyController();
    CapsuleCollider2D playerCollider;
    BoxCollider2D playerAttackRange;
    BoxCollider2D[] sideCollider = new BoxCollider2D[3];
    Button rightButton;
    Button leftButton;

    Text scoreText;

    int score;
    float spawntime = 1.5f;
    int maxEnermy = 5;
    float delta = 0f;
    int spawnInt;
    float spawnSpeed = 0;


    private void Start()
    {
        DontDestroyOnLoad(uiRoot = Share.Util.InstantiatePrefab(Share.Path.Prefab.Root, UIRoot.canvas));
        //Share.Util.InstantiatePrefab(Share.Path.Prefab.Character, UIRoot.canvas);

        rightButton = GameObject.Find("RightButton").GetComponent<Button>();
        leftButton = GameObject.Find("LeftButton").GetComponent<Button>();
        rightButton.onClick.AddListener(() => OnClick(0));
        leftButton.onClick.AddListener(() => OnClick(1));

        scoreText = GameObject.Find("Score").GetComponent<Text>();
        
        background = Resources.Load<GameObject>("Prefabs/Background");
        player = Resources.Load<GameObject>("Prefabs/Player");
        enermy = new GameObject[maxEnermy];

        //for (int i = 0; i < maxEnermy; ++i)
        //{
        //    enermy[i] = Resources.Load<GameObject>("Prefabs/Enermy");
        //    enermy[i].transform.position = new Vector2(7, -2.89f);
        //    enermy[i] = Instantiate(enermy[i]);
        //    myEnermy.setPhysics(enermy[i]);
        //    myEnermy.setEC(myEnermyController);
        //    enermy[i].SetActive(false); 
        //}
        collisionObject = Resources.Load<GameObject>("Prefabs/CollisionObject");

        Instantiate(background);
        collisionObject = Instantiate(collisionObject);
        player = Instantiate(player);

        myPlayer.setPC(myPlayerController);
        myPlayer.setPhysics(player);


        
        Debug.Log("시작!");

        playerCollider = player.GetComponent<CapsuleCollider2D>();
        playerAttackRange = player.GetComponent<BoxCollider2D>();

        sideCollider[0] = GameObject.FindGameObjectWithTag("centerside").GetComponent<BoxCollider2D>();
        sideCollider[1] = GameObject.FindGameObjectWithTag("rightside").GetComponent<BoxCollider2D>();
        sideCollider[2] = GameObject.FindGameObjectWithTag("leftside").GetComponent<BoxCollider2D>();
        myPlayer.setMoveState(0);
    }

    // 캐릭터가 좌우로 움직이다가 SideCollider에 부딪히면 가운데로 돌아와야 한다.
    private void playerIsTouchingSideCollider()
    {
        if (player)
        {
            if (playerCollider.IsTouching(sideCollider[1]) && myPlayer.getMoveState() != 1)
            {
                myPlayerController.OnTriggerEnter2DToSide(sideCollider[1]);
                myPlayer.setMoveState(1);
            }

            else if (playerCollider.IsTouching(sideCollider[2]) && myPlayer.getMoveState() != 2)
            {
                myPlayerController.OnTriggerEnter2DToSide(sideCollider[2]);
                myPlayer.setMoveState(2);
            }

            else if (playerCollider.IsTouching(sideCollider[0]) && myPlayer.getMoveState() != 0)
            {
                myPlayerController.OnTriggerEnter2DToSide(sideCollider[0]);
                myPlayer.setMoveState(0);
            }
        }
    }

    private void Update()
    {
        spawnInt = Random.Range(0, 20);
        Debug.Log(spawnInt);
        playerIsTouchingSideCollider();
        myPlayerController.init(player);
        myPlayerController.move(player);
        if (spawntime - spawnSpeed > 0)
            spawnSpeed += 0.00005f;

        scoreText.text = "Score : " + score;
    }

    private void FixedUpdate()
    {
        if (delta < spawntime - spawnSpeed)
            delta += Time.deltaTime;
        else
        {
            delta = 0f;
            spawntime = Random.Range(0.1f, 3.0f);
            GameObject obj = Resources.Load<GameObject>("Prefabs/Enermy");
            if (spawnInt % 2 == 0)
                obj.transform.position = new Vector2(-10, -2.89f);
            else
                obj.transform.position = new Vector2(10, -2.89f);
            obj = Instantiate(obj);
            myEnermy.setPhysics(obj);
            myEnermy.setEC(myEnermyController);
        }

        enermy = GameObject.FindGameObjectsWithTag("enermy");

        for (int i = 0; i < enermy.Length; ++i)
        {
            myEnermyController.move(enermy[i]);
            if (playerAttackRange.IsTouching(enermy[i].GetComponent<CapsuleCollider2D>()))
            {
                myPlayerController.OnTriggerEnter2DToSide(enermy[i].GetComponent<CapsuleCollider2D>());
                Debug.Log("적 죽였어");
                ++score;
                Destroy(enermy[i]);
                myPlayer.setMoveState(4);
            }
            if (playerCollider.IsTouching(enermy[i].GetComponent<CapsuleCollider2D>()))
            {
                Debug.Log("악 내가 죽었따!");
                player.SetActive(false);
                Time.timeScale = 0;
                Time.fixedDeltaTime = 0;
                break;
            }
        }
    } 

    public void OnClick(int fn)
    {
        switch(fn)
        {
            case 0:
                player.GetComponent<BoxCollider2D>().enabled = true;
                Debug.Log("오른쪽!");
                player.transform.localScale = new Vector2(1, 1);
                player.GetComponent<Rigidbody2D>().AddForce(myPlayerController.myVelocity * 1, ForceMode2D.Impulse);
                player.GetComponent<Rigidbody2D>().velocity = myPlayerController.myVelocity * 2;
                break;
            case 1:
                player.GetComponent<BoxCollider2D>().enabled = true;
                Debug.Log("왼쪽!");
                player.transform.localScale = new Vector2(-1, 1);
                player.GetComponent<Rigidbody2D>().AddForce(myPlayerController.myVelocity * -1, ForceMode2D.Impulse);
                player.GetComponent<Rigidbody2D>().velocity = myPlayerController.myVelocity * -2;
                break;

        }
    }
    ~Launcher() { 
        Debug.Log("런처 소멸");
    }
}

/*
 ResultUI temp = new ResultUI();         
restartbtn.GetComponent<Button>().onClick.AddListener(() => temp.OnClick(0));         
quitbtn.GetComponent<Button>().onClick.AddListener(() => temp.OnClick(1));
public interface IButtonMaker
{
    public void OnClick(int num);
}
 */