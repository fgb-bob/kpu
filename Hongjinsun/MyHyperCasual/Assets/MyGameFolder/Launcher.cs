using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Launcher : MonoBehaviour, IButton
{
    GameObject uiRoot;
    GameObject background;
    GameObject collisionObject;
    GameObject player;
    GameObject titleUI;
    GameObject deadUI;
    GameObject clearUI;
    Player myPlayer = new Player();
    PlayerController myPlayerController = new PlayerController();
    List<Enermy> enermy;
    EnermyController enermyController = new EnermyController();
    CapsuleCollider2D playerCollider;
    BoxCollider2D playerAttackRange;
    BoxCollider2D[] sideCollider = new BoxCollider2D[3];
    Button rightButton;
    Button leftButton;
    Button playButton;
    Button resumeButton;
    GameObject[] quitButton;
    Button nextButton;

    Text scoreText;
    List<int> aa = new List<int>();
    int score;
    float spawntime = 1.5f;
    int maxEnermy;
    int cntEnermy = 0;
    float delta = 0f;
    float spawnSpeed = 0;
    int state;

    private void Start()
    {
        cntEnermy = 0;
        maxEnermy = Random.Range(20, 40);
        enermy = new List<Enermy>();

        DontDestroyOnLoad(uiRoot = Share.Util.InstantiatePrefab(Share.Path.Prefab.Root, UIRoot.canvas));
        titleUI = Share.Util.InstantiatePrefab(Share.Path.Prefab.Title, UIRoot.canvas);
        deadUI = Share.Util.InstantiatePrefab(Share.Path.Prefab.Dead, UIRoot.canvas);
        clearUI = Share.Util.InstantiatePrefab(Share.Path.Prefab.Clear, UIRoot.canvas);

        state = 0;

        rightButton = GameObject.Find("RightButton").GetComponent<Button>();
        leftButton = GameObject.Find("LeftButton").GetComponent<Button>();

        playButton = GameObject.Find("PlayButton").GetComponent<Button>();
        quitButton = new GameObject[3];
        quitButton = GameObject.FindGameObjectsWithTag("QuitButton");
        for (int i = 0; i < quitButton.Length; ++i)
        {
            quitButton[i].GetComponent<Button>().onClick.AddListener(() => OnClick(3));
        }

        resumeButton = GameObject.Find("ResumeButton").GetComponent<Button>();
        nextButton = GameObject.Find("NextStageButton").GetComponent<Button>();

        deadUI.SetActive(false);
        clearUI.SetActive(false);

        rightButton.onClick.AddListener(() => OnClick(0));
        leftButton.onClick.AddListener(() => OnClick(1));
        playButton.onClick.AddListener(() => OnClick(2));
        
        resumeButton.onClick.AddListener(() => OnClick(4));
        nextButton.onClick.AddListener(() => OnClick(4));

        scoreText = GameObject.Find("Score").GetComponent<Text>();

        background = Resources.Load<GameObject>("Prefabs/Background");
        player = Resources.Load<GameObject>("Prefabs/Player");
        Resources.Load<GameObject>("Prefabs/Enermy");

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
    private void SpawnMonster()
    {
        spawntime = Random.Range(0.1f, 3.0f);
        delta += Time.deltaTime;

        if (delta > spawntime - spawnSpeed && cntEnermy < maxEnermy)
        {
            //  Debug.Log(cntEnermy + "번째 생성 - " + enermy[cntEnermy]);

            Enermy LE = new Enermy();
            LE.Init();
            enermy.Add(LE);

            //enermy[cntEnermy].Init();

            cntEnermy++;

            delta = 0f;
        }
    }

    private void Update()
    {

        switch (state)
        {
            case 1:
                playerIsTouchingSideCollider();
                myPlayerController.init(player);
                myPlayerController.move(player);
                if (spawntime - spawnSpeed > 0)
                    spawnSpeed += 0.00005f;

                scoreText.text = "Score : " + score;
                break;
        }

        if ( score == maxEnermy)
        {
            Debug.Log("스테이지 클리어!");
            player.SetActive(false);
            clearUI.SetActive(true);
            for (int i = 0; i < enermy.Count; ++i)
                Destroy(enermy[i].getEnermy());

            Time.timeScale = 0;
            Time.fixedDeltaTime = 0;
        }
    }

    private void FixedUpdate()
    {
        switch (state)
        {

            case 1:
                SpawnMonster();
                for (int i = 0; i < cntEnermy; ++i)
                {
                    if (enermy[i].getEnermy() != null)
                    {
                        enermyController.move(enermy[i].getEnermy());
                        if (playerAttackRange.IsTouching(enermy[i].getEnermy().GetComponent<CapsuleCollider2D>()))
                        {
                            myPlayerController.OnTriggerEnter2DToSide(enermy[i].getEnermy().GetComponent<CapsuleCollider2D>());
                            Debug.Log("적 죽였어");
                            ++score;
                            Destroy(enermy[i].getEnermy());

                            myPlayer.setMoveState(4);
                        }
                        if (playerCollider.IsTouching(enermy[i].getEnermy().GetComponent<CapsuleCollider2D>()))
                        {
                            Debug.Log("악 내가 죽었따!");
                            player.SetActive(false);

                            for (int j = 0; j < enermy.Count; ++j)
                                Destroy(enermy[j].getEnermy());
                            cntEnermy--;

                            Time.timeScale = 0;
                            Time.fixedDeltaTime = 0;
                            deadUI.SetActive(true);
                            titleUI.SetActive(false);
                            break;
                        }
                    }
                }
                break;
        }

    }

    public void OnClick(int fn)
    {
        switch (fn)
        {
            case 0:
                if (player.GetComponent<Rigidbody2D>().velocity == new Vector2(0, 0))
                {
                    player.GetComponent<BoxCollider2D>().enabled = true;
                    Debug.Log("오른쪽!");
                    player.transform.localScale = new Vector2(1, 1);
                    player.GetComponent<Rigidbody2D>().AddForce(myPlayerController.myVelocity * 1, ForceMode2D.Impulse);
                    player.GetComponent<Rigidbody2D>().velocity = myPlayerController.myVelocity * 2;
                }
                break;
            case 1:
                if (player.GetComponent<Rigidbody2D>().velocity == new Vector2(0, 0))
                {
                    player.GetComponent<BoxCollider2D>().enabled = true;
                    Debug.Log("왼쪽!");
                    player.transform.localScale = new Vector2(-1, 1);
                    player.GetComponent<Rigidbody2D>().AddForce(myPlayerController.myVelocity * -1, ForceMode2D.Impulse);
                    player.GetComponent<Rigidbody2D>().velocity = myPlayerController.myVelocity * -2;
                }
                break;
            case 2: // PlayButton
                PlayGame();
                break;
            case 3: // QuitButton
                //state = 0;
                Debug.Log("종료버튼 클릭!");  
                Application.Quit();
                break;
            case 4: // ResumeButton
                ResumeGame();
                break;

        }
    }

    private void PlayGame()
    {
        titleUI.SetActive(false);
        //uiRoot.SetActive(true);
        state = 1;
        //maxEnermy = Random.Range(20, 100);
        Debug.Log(maxEnermy);
    }

    private void ResumeGame()
    {
        state = 1;

        enermy.Clear();
        cntEnermy = 0;
        delta = 0;
        spawnSpeed = 0;

        GameObject[] temp = GameObject.FindGameObjectsWithTag("enermy");
        for (int i = 0; i < temp.Length; ++i) Destroy(temp[i]);
        maxEnermy = Random.Range(20, 40);
        Debug.Log(maxEnermy);

        player.SetActive(true);
        player.transform.position = new Vector2(0, -2.89f);
        deadUI.SetActive(false);
        clearUI.SetActive(false);

        score = 0;
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;

        Debug.Log("게임 재 시작");
    }

}