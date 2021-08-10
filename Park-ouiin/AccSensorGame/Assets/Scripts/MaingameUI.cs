using UnityEngine;

public class MaingameUI
{
    GameObject MaingameImage;
    GameObject ScoreText;
    GameObject[] Heart;
    GameObject gameObject;
    TextMaker textMaker = new TextMaker();
    float score;

    public void Init(int maxLife)
    {
        MaingameImage = Share.Util.InstantiatePrefab(Share.Path.Prefab.Maingame, UIRoot.noneUIGameObject);
        ScoreText = Share.Util.InstantiatePrefab(Share.Path.Prefab.ScoreText, UIRoot.maingameCanvas);
        Heart = new GameObject[maxLife];
        for (int i = 0; i < maxLife; ++i)
        {
            Heart[i] = Share.Util.InstantiatePrefab(Share.Path.Prefab.Heart, UIRoot.maingameCanvas);
            Vector2 heartPos = Heart[i].GetComponent<RectTransform>().anchoredPosition;
            heartPos.x -= 40f * i;
            Heart[i].GetComponent<RectTransform>().anchoredPosition = heartPos;
        }
        gameObject = Utility.Object.FindVisibleGameobjectWithName(gameObject, "MaingameCanvas");
        Utility.Object.Invisible(gameObject);
        Utility.Object.Invisible(MaingameImage);
    }

    public void SetScoreText()
    {
        score += Time.deltaTime;
        textMaker.SetText(ScoreText, "SCORE : " + Mathf.Round(score).ToString());
    }

    public float GetScore()
    {
        return Mathf.Round(score);
    }

    public void SetHeartActive(int life, int maxLife)
    {
        for (int i = 0; i < maxLife; ++i)
        {
            if (i < life)
                Utility.Object.Visible(Heart[i]);
            else
                Utility.Object.Invisible(Heart[i]);
        }
    }

    public void ResetScore()
    {
        score = 0;
    }
}
