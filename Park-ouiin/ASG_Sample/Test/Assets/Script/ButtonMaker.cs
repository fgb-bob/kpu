using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonMaker : MonoBehaviour
{
	public GameObject buttonObject;
	Button button;
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
		buttonObject = new GameObject("Button");
		button = buttonObject.AddComponent<Button>();
		button.transform.SetParent(gameObject.transform);
		buttonObject.AddComponent<RectTransform>();
		button.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 50);
		button.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
		button.GetComponent<RectTransform>().pivot = new Vector2(0, 1);
		button.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
		button.GetComponent<RectTransform>().anchorMax = new Vector2(0, 1);
	}

	public void SetImage(GameObject gameObject, Image image)
	{
		button = gameObject.GetComponent<Button>();
		button.targetGraphic = image;
	}

	public void SetSprite(GameObject gameObject, Sprite sprite)
	{
		button = gameObject.GetComponent<Button>();
		button.GetComponent<Image>().sprite = sprite;
	}

	public void SetSize(GameObject gameObject, float weight, float height)
	{
		button = gameObject.GetComponent<Button>();
		button.GetComponent<RectTransform>().sizeDelta = new Vector2(weight, height);
	}

	public void SetPosition(GameObject gameObject, Vector3 position)
	{
		var temp = gameObject.GetComponent<RectTransform>().anchoredPosition;
		temp = position;
	}

	public void OnClick(GameObject gameObject, string sceneName)
	{
		button = gameObject.GetComponent<Button>();
		button.onClick.AddListener(() => SceneManager.LoadScene(sceneName));
	}

}
