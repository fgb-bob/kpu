using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NGameManager : MonoBehaviour
{
    GameObject uiRoot;
    GameObject player;
    NUIManager nUIManager;
    NCharacterManager nCharacterManager;
    NObstacleManager nObstacleManager;
    int MaxObstacle = 20;

    private void Awake()
    {
        DontDestroyOnLoad(uiRoot = NShare.Util.InstantiatePrefab(NShare.Path.Prefab.Root, null));

        Debug.Log("캐릭터 매니져 만들어!");        
        nCharacterManager = new NCharacterManager();
        Debug.Log("캐릭터 매니져 만들었어~");

        Debug.Log("캐릭터 만들어!");
        nCharacterManager.Init();
        Debug.Log("캐릭터 만들었어~");

        Debug.Log("캐릭터 찾아!");
        player = GameObject.FindGameObjectWithTag("Player");
        if (player)
            Debug.Log("Player 찾았어~");
        else
            Debug.Log("Player 없어~");

        Debug.Log("UI 매니져 만들어!");
        nUIManager = new NUIManager();
        Debug.Log("UI 매니져 만들었어~");

        nUIManager.Invisible(player);

        Debug.Log("타이틀 UI 만들어!");
        nUIManager.MakeTitleUI();
        Debug.Log("타이틀 UI 만들었어~");

        Debug.Log("메인게임 UI 만들어!");
        nUIManager.MakeMaingameUI(nCharacterManager.GetLife(), nCharacterManager.GetMaxLife());
        Debug.Log("메인게임 UI 만들었어~");

        Debug.Log("결과창 UI 만들어!");
        nUIManager.MakeResultUI();
        Debug.Log("결과창 UI 만들었어~");

        nUIManager.state = 0;

        Debug.Log("장애물 매니져 만들어!");
        nObstacleManager = new NObstacleManager();
        Debug.Log("장애물 매니져 만들었어~");
    }

    void FixedUpdate()
    {
        switch (nUIManager.state)
        {
            case 0:
                break;
            case 1:
                if (player.activeSelf == false)
                    nUIManager.Visible(player);
                
                if (nObstacleManager.num == 0)
                {
                    nObstacleManager.num = MaxObstacle;
                    nObstacleManager.Init();
                }

                nCharacterManager.nPlayer.Playing();
                nUIManager.nMaingameUI.SetScoreText();

                for (int i = 0; i < nObstacleManager.num; ++i)
                {
                    nObstacleManager.nObstacle[i].Move();
                    if (nObstacleManager.OutOfRange(nObstacleManager.nObstacle[i].goObstacle))
                        nObstacleManager.nObstacle[i].SetPosDir();

                    if (nCharacterManager.Touching(player.GetComponent<Collider2D>(), nObstacleManager.nObstacle[i].goObstacle.GetComponent<Collider2D>()))
                    {
                        if (nObstacleManager.nObstacle[i].GetBool())
                        {
                            nCharacterManager.IncreaseLife(1);
                        }
                        else
                        {                            
                            nCharacterManager.DecreaseLife(1);
                        }
                        nUIManager.nMaingameUI.SetHeartActive(nCharacterManager.GetLife());
                        nObstacleManager.nObstacle[i].SetPosDir();
                        if (nCharacterManager.GetLife() <= 0)
                        {
                            Debug.Log("으아악!");
                            nUIManager.GamePause();
                            nUIManager.Visible(nUIManager.resultUI);
                            nUIManager.state = 0;
                        }
                    }
                }
                break;
            case 2:
                Debug.Log("재시작!");
                nCharacterManager.Reset();
                nUIManager.nMaingameUI.SetHeartActive(nCharacterManager.GetLife());
                nUIManager.nMaingameUI.ResetScore();                
                for (int i = 0; i < nObstacleManager.num; ++i)
                {
                    nObstacleManager.nObstacle[i].SetPosDir();
                }
                nUIManager.state = 1;
                break;
        }
    }
}
