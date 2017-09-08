using UnityEngine;
using System.Collections;
public class CameraManager : MonoBehaviour {
	public GameObject cameraFocus;
	int selectedResolutionWidth, selectedResolutionHeight, selectedResolutionRefresh;
	bool isfullScreen;
	public float cameraZoom = 3.65f;
	Vector4[] resolutionSet;
	static CameraManager manager;
	void Awake () {
		if (manager == null) {
			DontDestroyOnLoad (gameObject);
			manager = this;
		} else if (manager != this) {
			Destroy (gameObject);
		}
        QualitySettings.antiAliasing = 0;
        QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
    }
	void LateUpdate () {
		if (cameraFocus == null){	 
			cameraFocus = GameControl.GetCurrentPlayer();
			}
		else {
			transform.position = new Vector3 (cameraFocus.transform.position.x, cameraFocus.transform.position.y, -10);
			this.transform.GetChild(0).GetComponentInChildren<Camera> ().orthographicSize = cameraZoom;
		}
	}
	public void SetFocus(GameObject focus){
		cameraFocus = focus;
	}	
	public void ChangeResolution(int resolutionWidth, int resolutionHeight, bool fullScreen, int resolutionRefresh){
		selectedResolutionWidth = Screen.currentResolution.width;
		selectedResolutionHeight = Screen.currentResolution.height;
		selectedResolutionRefresh = Screen.currentResolution.refreshRate;
		isfullScreen = fullScreen;
		Screen.SetResolution (resolutionWidth, resolutionHeight, fullScreen, resolutionRefresh);
	}
	public GameObject GetFocus(){
		return (cameraFocus);
	}
}

