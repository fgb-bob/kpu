using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour
{
	ButtonMaker buttonMaker;
	TextMaker textMaker;
	ImageMaker imageMaker;
	GameObject canvasObject;

    private void Awake()
    {
		buttonMaker = gameObject.AddComponent<ButtonMaker>();
		textMaker = gameObject.AddComponent<TextMaker>();
		imageMaker = gameObject.AddComponent<ImageMaker>();
	}

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
			canvasObject = new GameObject("Canvas", typeof(Canvas));
			var canvas = canvasObject.GetComponent<Canvas>();
			var mode = canvasObject.AddComponent<CanvasScaler>();
			canvasObject.AddComponent<GraphicRaycaster>();
			canvasObject.layer = 5;			
			canvas.renderMode = RenderMode.ScreenSpaceOverlay;
			mode.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
			mode.referenceResolution = new Vector2(800, 600);
		}

		MakeTitle();
	}

	void MakeTitle()
	{		
		buttonMaker.Init(canvasObject);		
		var pos = new Vector3(0, 0, 0);
		buttonMaker.SetPosition(buttonMaker.buttonObject, pos);
		buttonMaker.SetSize(buttonMaker.buttonObject, 180, 40);
		
		imageMaker.Init(buttonMaker.buttonObject);
		imageMaker.SetImage(buttonMaker.buttonObject, true, new Vector4(1f, .3f, .3f, .5f), null);
		imageMaker.SetPosition(buttonMaker.buttonObject, new Vector3(0, 0, 0));
		imageMaker.SetSize(buttonMaker.buttonObject, 180, 40);
		
		textMaker.Init(buttonMaker.buttonObject);
		textMaker.SetColor(textMaker.textObject, Color.yellow);
		textMaker.SetFontSize(textMaker.textObject, 20);
		textMaker.SetSize(textMaker.textObject, 180, 40);
		textMaker.SetPosition(textMaker.textObject, new Vector3(0, 0, 0));
		textMaker.SetText(textMaker.textObject, "시작");
		
		buttonMaker.SetImage(buttonMaker.buttonObject, imageMaker.image);
		buttonMaker.SetSprite(buttonMaker.buttonObject, UnityEditor.AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd"));
		buttonMaker.OnClick(buttonMaker.buttonObject, "SampleScene");
	}

}
