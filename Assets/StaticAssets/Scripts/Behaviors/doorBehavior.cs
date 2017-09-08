using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class doorBehavior : MonoBehaviour {
	public int nextMap;
	public string toDoor;
	GameObject _SM, _PM;
	void Start(){
		_SM = GameObject.FindGameObjectWithTag ("_SM");
		_PM = GameObject.FindGameObjectWithTag ("_PM");
	}
	void OnTriggerEnter2D (Collider2D Colider)
	{
		//Change the map
		//_PM.GetComponent<PlayerManager> ().PausePlayerAnimation();
		//_SM.GetComponent<SceneManager> ().ChangeMap (nextMap,toDoor);
	}
}
