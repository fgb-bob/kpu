using UnityEngine;

public class MaingameUI
{
    public static GameObject MaingameImage;
    public static GameObject ScoreText;
    public static GameObject[] Heart;
    public static float score;

    public static void MakeMaingame()
    {
        MaingameImage = Share.Util.InstantiatePrefab(Share.Path.Prefab.Mainaame, null);
        ScoreText = Share.Util.InstantiatePrefab(Share.Path.Prefab.ScoreText, UIRoot.maingameCanvas);
        Heart = new GameObject[CharacterManager.life];        
        for (int i = 0; i < CharacterManager.life; ++i)
        {
            Heart[i] = Share.Util.InstantiatePrefab(Share.Path.Prefab.Heart, UIRoot.maingameCanvas);
            Vector2 temp = Heart[i].GetComponent<RectTransform>().anchoredPosition;
            temp.x -= 40f * i;
            Heart[i].GetComponent<RectTransform>().anchoredPosition = temp;
        }
    }

    public static void SetScoreText()
    {
        score += Time.deltaTime;
        TextMaker.SetText(ScoreText, "SCORE : " + Mathf.Round(score).ToString());
    }

    public static void SetHeartActive(int life)
    {
        for (int i = 0; i < CharacterManager.maxLife; ++i)
        {
            if (i < life)
                Heart[i].SetActive(true);
            else
                Heart[i].SetActive(false);            
        }
    }
}
