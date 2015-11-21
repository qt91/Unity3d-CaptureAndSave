using UnityEngine;
using System.Collections;

public class Example : MonoBehaviour {
	
	string x = "0";
	string y = "0";
	string width = "0";
	string height = "0";

	public Texture2D tex;

	CaptureAndSave snapShot ;

	void Start()
	{
		snapShot = GameObject.FindObjectOfType<CaptureAndSave>();
		Debug.Log (System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures));
	}

	void OnEnable()
	{
		CaptureAndSaveEventListener.onError += OnError;
		CaptureAndSaveEventListener.onSuccess += OnSuccess;
	}

	void OnDisable()
	{
		CaptureAndSaveEventListener.onError += OnError;
		CaptureAndSaveEventListener.onSuccess += OnSuccess;
	}

	void OnError(string error)
	{
		Debug.Log ("Error : "+error);
	}

	void OnSuccess(string msg)
	{
		Debug.Log ("Success : "+msg);
	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(20,20,150,50),"Save Full Screen"))
		{
			snapShot.CaptureAndSaveToAlbum();
		}

		if(GUI.Button(new Rect(200,20,150,50),"Upload Full Screen"))
		{
			snapShot.CaptureAndUploadToServer();
		}

		GUI.Label(new Rect(20,70,500,20),"------------------------------------------------------------------------------------------------------------------------------");

		GUI.Label(new Rect(20,100,50,20),"X : ");
		x = GUI.TextField(new Rect(80,100,50,20),x);

		GUI.Label(new Rect(160,100,50,20),"Y : ");
		y = GUI.TextField(new Rect(200,100,50,20),y);

		GUI.Label(new Rect(20,130,50,20),"Width : ");
		width = GUI.TextField(new Rect(80,130,50,20),width);

		GUI.Label(new Rect(150,130,50,20),"Height : ");
		height = GUI.TextField(new Rect(200,130,50,20),height);

		if(GUI.Button(new Rect(20,160,150,50),"Save Selected Screen") && int.Parse(width) > 0 && int.Parse(height) > 0)
		{
			snapShot.CaptureAndSaveToAlbum(int.Parse(x),int.Parse(y),int.Parse(width),int.Parse(height));
		}

		if(GUI.Button(new Rect(200,160,150,50),"Upload Selected Screen") && int.Parse(width) > 0 && int.Parse(height) > 0)
		{
			snapShot.CaptureAndUploadToServer(int.Parse(x),int.Parse(y),int.Parse(width),int.Parse(height));
		}
		GUI.Label(new Rect(20,230,500,20),"------------------------------------------------------------------------------------------------------------------------------");
		GUI.Label(new Rect(70,250,200,50),"Click This Texture to Save");
		if(GUI.Button(new Rect(50,270,200,200),tex) && tex != null)
		{
			snapShot.SaveTextureToGallery(tex);
		}

		GUI.Label(new Rect(320,250,200,50),"Click This Texture to Upload");
		if(GUI.Button(new Rect(300,270,200,200),tex) && tex != null)
		{
			snapShot.UploadTextureToServer(tex);
		}

	}
}
