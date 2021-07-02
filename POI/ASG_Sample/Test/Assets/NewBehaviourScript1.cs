using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NewBehaviourScript1 : MonoBehaviour
{
    public float time;
	public int weight, height;	
	public float pos_x, pos_y;	
	Text text;

	// Start is called before the first frame update
	void Start()
    {
		if (FindObjectOfType<EventSystem>() == null)
		{
			var es = new GameObject("EventSystem", typeof(EventSystem));
			es.AddComponent<StandaloneInputModule>();
		}

		var canvasObject = new GameObject("Canvas");
		var canvas = canvasObject.AddComponent<Canvas>();
		canvasObject.AddComponent<GraphicRaycaster>();
		canvas.renderMode = RenderMode.ScreenSpaceOverlay;

		var buttonObject = new GameObject("Button");		
		var image = buttonObject.AddComponent<Image>();
		image.transform.SetParent(canvas.transform);
		image.rectTransform.sizeDelta = new Vector2(weight, height);
		image.rectTransform.anchoredPosition = new Vector2(pos_x, pos_y);//Vector3.zero;
		image.rectTransform.pivot = new Vector2(0, 1);
		image.rectTransform.anchorMin = new Vector2(0, 1);
		image.rectTransform.anchorMax = new Vector2(0, 1);
		image.color = new Color(1f, .3f, .3f, .5f);

		var button = buttonObject.AddComponent<Button>();
		button.targetGraphic = image;
		button.onClick.AddListener(() => Debug.Log(Time.time));

		var textObject = new GameObject("Text");
		textObject.transform.parent = buttonObject.transform;
		text = textObject.AddComponent<Text>();
		text.rectTransform.sizeDelta = Vector2.zero;
		text.rectTransform.anchorMin = Vector2.zero;
		text.rectTransform.anchorMax = Vector2.one;
		text.rectTransform.anchoredPosition = new Vector2(.5f, .5f);
		text.text = "Button Test!";
		text.font = Resources.FindObjectsOfTypeAll<Font>()[0];
		text.fontSize = 20;
		text.color = Color.yellow;
		text.alignment = TextAnchor.MiddleCenter;
	}

    // Update is called once per frame
    void Update()
    {
		//time += Time.deltaTime;
		//timeText.text = "진행 시간 : " + Mathf.Round(time) + "초";
		time += Time.deltaTime;
		text.text = "진행 시간 : " + Mathf.Round(time) + "초";
	}
}
