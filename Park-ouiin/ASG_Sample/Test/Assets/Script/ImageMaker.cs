using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImageMaker : MonoBehaviour
{
	public Image image;
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
		image = gameObject.AddComponent<Image>();				
		image.rectTransform.sizeDelta = new Vector2(200, 50);
		image.rectTransform.anchoredPosition = new Vector2(0, 0);
		image.rectTransform.pivot = new Vector2(0, 1);
		image.rectTransform.anchorMin = new Vector2(0, 1);
		image.rectTransform.anchorMax = new Vector2(0, 1);		
	}

	// 이미지 색상 및 스프라이트 설정
	public void SetImage(GameObject gameObject, bool type, Vector4 color, Sprite sprite)
	{
		image = gameObject.GetComponent<Image>();
		if (type)
			image.color = color;
		else
			image.sprite = sprite;
	}

	// 이미지 사이즈 설정
	public void SetSize(GameObject gameObject, float weight, float height)
	{
		image = gameObject.GetComponent<Image>();
		image.rectTransform.sizeDelta = new Vector2(weight, height);
	}

	// 이미지 위치 조정
	public void SetPosition(GameObject gameObject, Vector3 position)
	{
		var temp = gameObject.GetComponent<RectTransform>().anchoredPosition;
		temp = position;
	}
}
