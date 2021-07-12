using UnityEngine;

public class NGameManager : MonoBehaviour
{
    GameObject emptyObject;
    GameObject uiRoot;    
    NUIManager nUIManager;

    NCharacterManager nCharacterManager;
    NObstacleManager nObstacleManager;
    int MaxObstacle = 20;

    private void Awake()
    {
        DontDestroyOnLoad(uiRoot = NShare.Util.InstantiatePrefab(NShare.Path.Prefab.Root, null));


        Debug.Log("UI 매니져 만들어!");
        nUIManager = new NUIManager();
        Debug.Log("UI 매니져 만들었어~");

        Debug.Log("UI 매니져야 모든 UI Init() 실행해!");
        nUIManager.UISetting();
        Debug.Log("모든 UI Init() 실행완료~");
    }

    void FixedUpdate()
    {
        switch (nUIManager.GetState())
        {
            case NUIManager.State.TITLE:
                if (NUtility.FindVisibleGameobjectWithName(emptyObject, "MaingameCanvas") != null)
                    nUIManager.SetState(NUIManager.State.MAINGAME);
                break;
            case NUIManager.State.MAINGAME:
                nUIManager.GetNMaingameUI().SetScoreText();
                break;
            case NUIManager.State.RESULT:
                break;                
        }


        //switch (nUIManager.state)
        //{
        //    case 0:
        //        break;
        //    case 1:
        //        if (player.activeSelf == false)
        //            nUIManager.Visible(player);
        //        
        //        if (nObstacleManager.num == 0)
        //        {
        //            nObstacleManager.num = MaxObstacle;
        //            nObstacleManager.Init();
        //        }
        //
        //        nCharacterManager.nPlayer.Playing();
        //        nUIManager.nMaingameUI.SetScoreText();
        //
        //        for (int i = 0; i < nObstacleManager.num; ++i)
        //        {
        //            nObstacleManager.nObstacle[i].Move();
        //            if (nObstacleManager.OutOfRange(nObstacleManager.nObstacle[i].goObstacle))
        //                nObstacleManager.nObstacle[i].SetPosDir();
        //
        //            if (nCharacterManager.Touching(player.GetComponent<Collider2D>(), nObstacleManager.nObstacle[i].goObstacle.GetComponent<Collider2D>()))
        //            {
        //                if (nObstacleManager.nObstacle[i].GetBool())
        //                {
        //                    nCharacterManager.IncreaseLife(1);
        //                }
        //                else
        //                {                            
        //                    nCharacterManager.DecreaseLife(1);
        //                }
        //                nUIManager.nMaingameUI.SetHeartActive(nCharacterManager.GetLife());
        //                nObstacleManager.nObstacle[i].SetPosDir();
        //                if (nCharacterManager.GetLife() <= 0)
        //                {
        //                    Debug.Log("으아악!");
        //                    nUIManager.GamePause();
        //                    nUIManager.Visible(nUIManager.resultUI);
        //                    nUIManager.state = 0;
        //                }
        //            }
        //        }
        //        break;
        //    case 2:
        //        Debug.Log("재시작!");
        //        nCharacterManager.Reset();
        //        nUIManager.nMaingameUI.SetHeartActive(nCharacterManager.GetLife());
        //        nUIManager.nMaingameUI.ResetScore();                
        //        for (int i = 0; i < nObstacleManager.num; ++i)
        //        {
        //            nObstacleManager.nObstacle[i].SetPosDir();
        //        }
        //        nUIManager.state = 1;
        //        break;
        //}
    }
}
