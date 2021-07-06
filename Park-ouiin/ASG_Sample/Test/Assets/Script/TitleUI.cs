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

	GameObject uiRoot;

    private void Awake()
    {
		buttonMaker = gameObject.AddComponent<ButtonMaker>();
		textMaker = gameObject.AddComponent<TextMaker>();
		imageMaker = gameObject.AddComponent<ImageMaker>();

		DontDestroyOnLoad(uiRoot = Share.Util.InstantiatePrefab(Share.Path.Prefab.Root, null));

		Share.Util.InstantiatePrefab(Share.Path.Prefab.Title, UIRoot.canvas);
	}

    // Start is called before the first frame update
    void Start()
    {
		//// 이벤트 시스템 확인 후 없으면 생성
		//if (FindObjectOfType<EventSystem>() == null)
		//{
		//	var es = new GameObject("EventSystem", typeof(EventSystem));
		//	es.AddComponent<StandaloneInputModule>();
		//}

		//// 캔버스 확인 후 없으면 생성
		//if (FindObjectOfType<Canvas>() == null)
		//{
		//	canvasObject = new GameObject("Canvas", typeof(Canvas));
		//	var canvas = canvasObject.GetComponent<Canvas>();
		//	var mode = canvasObject.AddComponent<CanvasScaler>();
		//	canvasObject.AddComponent<GraphicRaycaster>();
		//	canvasObject.layer = 5;			
		//	canvas.renderMode = RenderMode.ScreenSpaceOverlay;
		//	mode.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
		//	mode.referenceResolution = new Vector2(800, 600);
		//}

		MakeTitle();
	}

	void MakeTitle()
	{		
		buttonMaker.Init(UIRoot.canvas.gameObject);		
		buttonMaker.SetSize(buttonMaker.buttonObject, 180, 40);
		var pos = new Vector3(310f, -230f, 0f);
		buttonMaker.SetPosition(buttonMaker.buttonObject, pos);

		Sprite tempsprite = Resources.Load<Sprite>("cloudbtn") as Sprite;
		
		imageMaker.Init(buttonMaker.buttonObject);
		imageMaker.SetImage(buttonMaker.buttonObject, false, new Vector4(), tempsprite);
		imageMaker.SetPosition(buttonMaker.buttonObject, pos);
		imageMaker.SetSize(buttonMaker.buttonObject, 180, 40);
		
		textMaker.Init(buttonMaker.buttonObject);
		textMaker.SetColor(textMaker.textObject, Color.red);
		textMaker.SetFontSize(textMaker.textObject, 20);
		textMaker.SetSize(textMaker.textObject, 180, 40);
		textMaker.SetPosition(textMaker.textObject, pos);
		textMaker.SetText(textMaker.textObject, "START");
		
		buttonMaker.OnClick(buttonMaker.buttonObject, "SampleScene");
	}

}
