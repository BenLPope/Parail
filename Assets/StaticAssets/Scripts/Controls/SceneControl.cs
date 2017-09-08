using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
public class SceneControl : MonoBehaviour {
	public Object[] maps;
	public List<Transform> entryPoints;
	public List<string> pointNames;
	public string 	movingToDoor,
					currentMap;
	public string mapLocation;
	GameObject loadedMap;
	public static SceneControl control;
	void Awake () {
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		} else if (control != this) {
			Destroy (gameObject);
		}
		maps = Resources.LoadAll(mapLocation);
	}
	void Start(){
	}
	public void ChangeMap(int mapNum, string doorName){
		}
}
