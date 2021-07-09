using UnityEngine;

public class NMaingameUI
{
    GameObject MaingameImage;
    GameObject ScoreText;
    GameObject[] Heart;
    NTextMaker nTextMaker;
    int life, maxLife;
    float score;

    public void MakeMaingame(int life, int maxLife)
    {
        nTextMaker = new NTextMaker();

        this.life = life;
        this.maxLife = maxLife;
        Debug.Log("메인 게임 배경 이미지 UI 생성");
        MaingameImage = NShare.Util.InstantiatePrefab(NShare.Path.Prefab.Maingame, null);
        Debug.Log("점수 텍스트 UI 생성");
        ScoreText = NShare.Util.InstantiatePrefab(NShare.Path.Prefab.ScoreText, NUIRoot.maingameCanvas);

        Debug.Log("하트 UI 생성");
        Heart = new GameObject[this.maxLife];
        for (int i = 0; i < this.life; ++i)
        {
            Heart[i] = Share.Util.InstantiatePrefab(NShare.Path.Prefab.Heart, NUIRoot.maingameCanvas);
            Vector2 temp = Heart[i].GetComponent<RectTransform>().anchoredPosition;
            temp.x -= 40f * i;
            Heart[i].GetComponent<RectTransform>().anchoredPosition = temp;
        }
    }

    public void SetScoreText()
    {
        Debug.Log("점수갱신");
        score += Time.deltaTime;
        nTextMaker.SetText(ScoreText, "SCORE : " + Mathf.Round(score).ToString());
    }

    public void SetHeartActive(int life)
    {
        for (int i = 0; i < maxLife; ++i)
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
