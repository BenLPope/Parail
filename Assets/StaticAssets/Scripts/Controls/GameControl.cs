using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class GameControl : MonoBehaviour {
	public Vector3 playerPosition;
	public static GameObject currentPlayer;
	GameObject map;
	public static GameControl control;
	void Awake () {
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		} else if (control != this) {
			Destroy (gameObject);
			}
		}
    public static void SetCurrentPlayer(GameObject player){
		currentPlayer = player;
		}
	public static GameObject GetCurrentPlayer(){
		return currentPlayer;
		}
	}

