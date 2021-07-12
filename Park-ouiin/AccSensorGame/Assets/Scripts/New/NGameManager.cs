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

        Debug.Log("ĳ���� �Ŵ��� �����!");        
        nCharacterManager = new NCharacterManager();
        Debug.Log("ĳ���� �Ŵ��� �������~");

        Debug.Log("ĳ���� �����!");
        nCharacterManager.Init();
        Debug.Log("ĳ���� �������~");

        Debug.Log("ĳ���� ã��!");
        player = GameObject.FindGameObjectWithTag("Player");
        if (player)
            Debug.Log("Player ã�Ҿ�~");
        else
            Debug.Log("Player ����~");

        Debug.Log("UI �Ŵ��� �����!");
        nUIManager = new NUIManager();
        Debug.Log("UI �Ŵ��� �������~");

        nUIManager.Invisible(player);

        Debug.Log("Ÿ��Ʋ UI �����!");
        nUIManager.MakeTitleUI();
        Debug.Log("Ÿ��Ʋ UI �������~");

        Debug.Log("���ΰ��� UI �����!");
        nUIManager.MakeMaingameUI(nCharacterManager.GetLife(), nCharacterManager.GetMaxLife());
        Debug.Log("���ΰ��� UI �������~");

        Debug.Log("���â UI �����!");
        nUIManager.MakeResultUI();
        Debug.Log("���â UI �������~");

        nUIManager.state = 0;

        Debug.Log("��ֹ� �Ŵ��� �����!");
        nObstacleManager = new NObstacleManager();
        Debug.Log("��ֹ� �Ŵ��� �������~");
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
                            Debug.Log("���ƾ�!");
                            nUIManager.GamePause();
                            nUIManager.Visible(nUIManager.resultUI);
                            nUIManager.state = 0;
                        }
                    }
                }
                break;
            case 2:
                Debug.Log("�����!");
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
