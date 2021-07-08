using UnityEngine;
using UnityEngine.UI;

public class ResultUI : IButtonMaker
{
    public static GameObject restartbtn;
    public static GameObject quitbtn;

    public static void MakeResult()
    {
        restartbtn = Share.Util.InstantiatePrefab(Share.Path.Prefab.Restartbtn, UIRoot.resultCanvas);
        quitbtn = Share.Util.InstantiatePrefab(Share.Path.Prefab.Quitbtn, UIRoot.resultCanvas);
        ResultUI temp = new ResultUI();
        restartbtn.GetComponent<Button>().onClick.AddListener(() => temp.OnClick(0));
        quitbtn.GetComponent<Button>().onClick.AddListener(() => temp.OnClick(1));
    }

    public void OnClick(int num)
    {
        switch (num)
        {
            case 0:                
                GameManager.GameResume();
                UIManager.Invisible(GameManager.resultUI);
                CharacterManager.Reset();
                MaingameUI.SetHeartActive(CharacterManager.life);
                MaingameUI.ResetScore();
                UIManager.Visible(GameManager.maingameUI);                
                for (int i = 0; i < ObstacleManager.Obstacles.Length; ++i)
                {
                    ObstacleManager.ReSetPosition(ObstacleManager.Obstacles[i], i);
                }
                GameManager.state = 1;
                break;
            case 1:
                Application.Quit();
                break;
        }
    }
}
