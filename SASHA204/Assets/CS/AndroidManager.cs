using UnityEngine;
using System.Collections;
public class AndroidManager : MonoBehaviour {
	/*
	private static AndroidManager _instance;
	public AndroidJavaObject activity;
	void Awake() {
		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		activity = jc.GetStatic<AndroidJavaObject>("currentActivity");
	}
	void OnReceiveUser(string response, string user) {
		// response에 따라 이벤트를 처리합니다.
		// user는 JSON형태로 받을 수 있습니다.
	}
	public static AndroidManager Instance {
		get {
			if (null == _instance) {
				_instance = FindObjectOfType(typeof(AndroidManager)) as AndroidManager;
				if (null == _instance) {
					_instance = new GameObject("AndroidManager").AddComponent<AndroidManager>();
				}
			}
			return _instance;
		}
	}

	// Update is called once per frame
	void Update() {
	}

	public void SetUserKeyAndNickName(string userKeyAndNickName)
	{
		string[] strs = userKeyAndNickName.Split (',');

		manage_static.cn = strs [0];
		manage_static.nick = strs [1];

	}
	*/
}