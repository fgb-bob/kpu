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
        Debug.Log("���� ���� ��� �̹��� UI ����");
        MaingameImage = NShare.Util.InstantiatePrefab(NShare.Path.Prefab.Maingame, NUIRoot.maingameCanvas);

        Debug.Log("���� �ؽ�Ʈ UI ����");
        ScoreText = NShare.Util.InstantiatePrefab(NShare.Path.Prefab.ScoreText, NUIRoot.maingameCanvas);

        Debug.Log("��Ʈ UI ����");
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
        Debug.Log("��������");
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
