using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TextMaker : MonoBehaviour
{
	public GameObject textObject;
	Text text;
	Canvas canvas;

	// Start is called before the first frame update
	void Start()
    {
		// 이벤트 시스템 확인 후 없으면 생성
		if (FindObjectOfType<EventSystem>() == null)
		{
			var es = new GameObject("EventSystem", typeof(EventSystem));
			es.AddComponent<StandaloneInputModule>();
		}

		// 캔버스 확인 후 없으면 생성
		if (FindObjectOfType<Canvas>() == null)
		{
			var canvasObject = new GameObject("Canvas", typeof(Canvas));
			canvas = canvasObject.GetComponent<Canvas>();
			var mode = canvasObject.AddComponent<CanvasScaler>();
			canvasObject.AddComponent<GraphicRaycaster>();
			canvasObject.layer = 5;
			canvas.renderMode = RenderMode.ScreenSpaceOverlay;
			mode.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
			mode.referenceResolution = new Vector2(800, 600);
		}
	}

	public void Init(GameObject gameObject)	
	{
		textObject = new GameObject("Text");
		text = textObject.AddComponent<Text>();
		text.transform.SetParent(gameObject.transform);
		text.rectTransform.sizeDelta = new Vector2(200, 50);
		text.rectTransform.anchoredPosition = new Vector2(0, 0);
		text.rectTransform.pivot = new Vector2(0, 1);
		text.rectTransform.anchorMin = new Vector2(0, 1);
		text.rectTransform.anchorMax = new Vector2(0, 1);
		text.horizontalOverflow = HorizontalWrapMode.Overflow;
		text.verticalOverflow = VerticalWrapMode.Overflow;
		text.text = "글자 생성";
		text.alignment = TextAnchor.MiddleCenter;
	}

	// 글자 설정
	public void SetText(GameObject gameObject, string str)
	{
		text = gameObject.GetComponent<Text>();
		text.text = str;
	}

	// 글자 크기 설정
	public void SetFontSize(GameObject gameObject, int size)
	{
		text = gameObject.GetComponent<Text>();
		text.font = Resources.FindObjectsOfTypeAll<Font>()[0];
		text.fontSize = size;
	}

	public void SetSize(GameObject gameObject, float weight, float height) 
	{
		text = gameObject.GetComponent<Text>();
		text.rectTransform.sizeDelta = new Vector2(weight, height);
	}

	// 글 색상 설정
	public void SetColor(GameObject gameObject, Vector4 color)
	{
		text = gameObject.GetComponent<Text>();
		text.color = color;
	}

	// 글 위치 설정
	public void SetPosition(GameObject gameObject, Vector3 position)
	{
		var temp = gameObject.GetComponent<RectTransform>().position;
		temp = position;
	}
}
