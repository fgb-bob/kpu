using UnityEngine;

public class NMaingameUI
{
    GameObject MaingameImage;
    GameObject ScoreText;
    GameObject[] Heart;
    GameObject gameObject;
    NTextMaker nTextMaker = new NTextMaker();
    float score;

    public void Init(int life, int maxLife)
    {
        Debug.Log("메인 게임 배경 이미지 UI 생성");
        MaingameImage = NShare.Util.InstantiatePrefab(NShare.Path.Prefab.Maingame, NUIRoot.maingameCanvas);

        Debug.Log("점수 텍스트 UI 생성");
        ScoreText = NShare.Util.InstantiatePrefab(NShare.Path.Prefab.ScoreText, NUIRoot.maingameCanvas);

        Debug.Log("하트 UI 생성");
        Heart = new GameObject[maxLife];
        for (int i = 0; i < life; ++i)
        {
            Heart[i] = Share.Util.InstantiatePrefab(NShare.Path.Prefab.Heart, NUIRoot.maingameCanvas);
            Vector2 heartPos = Heart[i].GetComponent<RectTransform>().anchoredPosition;
            heartPos.x -= 40f * i;
            Heart[i].GetComponent<RectTransform>().anchoredPosition = heartPos;
        }
        
        gameObject = NUtility.FindVisibleGameobjectWithName(gameObject, "MaingameCanvas");        
        NUtility.Invisible(gameObject);
    }

    public void SetScoreText()
    {
        Debug.Log("점수측정");
        score += Time.deltaTime;
        nTextMaker.SetText(ScoreText, "SCORE : " + Mathf.Round(score).ToString());
    }

    public void SetHeartActive(int life)
    {
        for (int i = 0; i < 3; ++i)
        {
            if (i < life)
                Heart[i].SetActive(true);
            else
                Heart[i].SetActive(false);
        }
    }

    public void ResetScore()
    {
        score = 0;
    }
}
