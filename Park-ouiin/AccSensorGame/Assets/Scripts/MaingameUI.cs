using UnityEngine;

public class MaingameUI
{
    GameObject MaingameImage;
    GameObject ScoreText;
    GameObject[] Heart;
    GameObject gameObject;
    TextMaker textMaker = new TextMaker();
    float score;

    // ���ΰ��� UI ����
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

    // ���� ���� ����
    public void SetScoreText()
    {
        score += Time.deltaTime;
        textMaker.SetText(ScoreText, "SCORE : " + Mathf.Round(score).ToString());
    }

    // ���� ��ȯ
    public float GetScore()
    {
        return Mathf.Round(score);
    }

    // ����� ǥ�� �̹��� �Լ�
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

    // ���� ����
    public void ResetScore()
    {
        score = 0;
    }
}
