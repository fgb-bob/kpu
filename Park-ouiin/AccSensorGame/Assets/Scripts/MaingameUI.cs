using UnityEngine;

public class MaingameUI
{
    GameObject MaingameImage;
    GameObject ScoreText;
    GameObject[] Heart;
    GameObject gameObject;
    TextMaker textMaker = new TextMaker();
    float score;

    // 메인게임 UI 생성
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
        gameObject = Utility.FindVisibleGameobjectWithName(gameObject, "MaingameCanvas");
        Utility.Invisible(gameObject);
        Utility.Invisible(MaingameImage);
    }

    // 점수 글자 변경
    public void SetScoreText()
    {
        score += Time.deltaTime;
        textMaker.SetText(ScoreText, "SCORE : " + Mathf.Round(score).ToString());
    }

    // 점수 반환
    public float GetScore()
    {
        return Mathf.Round(score);
    }

    // 생명력 표시 이미지 함수
    public void SetHeartActive(int life, int maxLife)
    {
        for (int i = 0; i < maxLife; ++i)
        {
            if (i < life)
                Heart[i].SetActive(true);
            else
                Heart[i].SetActive(false);
        }
    }

    // 점수 리셋
    public void ResetScore()
    {
        score = 0;
    }
}
