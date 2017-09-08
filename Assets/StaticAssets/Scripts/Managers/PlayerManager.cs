using UnityEngine;
using System.Collections;
public class PlayerManager : MonoBehaviour {
	public GameObject[] player;
	public GameObject selectedCharacter;
	int selectedCharacterNumber;
	static PlayerControl playerControl;
    public static bool playerPaused;
    public static bool allowPlayerControl;
    public static PlayerManager manager;
	void Awake(){
			if (manager == null) {
				DontDestroyOnLoad (gameObject);
			manager  = this;
		} else if (manager  != this) {
				Destroy (gameObject);
			}
	}
	void Start(){
		selectedCharacter = Instantiate (player [0], new Vector3 (0, 0, 0), Quaternion.identity);
		playerControl = selectedCharacter.GetComponent<PlayerControl> ();
        selectedCharacter.name = player[0].name;
        GameControl.SetCurrentPlayer (selectedCharacter);
        SetPlayer("Nard");
        GrantControl();
    }
	 void LateUpdate(){
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
           SetPlayer("Nard");
            GrantControl();
        }
	}
	public GameObject GetPlayer(){
		return selectedCharacter.gameObject;
	}
	public void SetPlayer(string characterName){
		if (characterName == "Nard") {
			selectedCharacterNumber = 1;
			PlaceCharacter (transform.position);
		} else if (characterName == "Savior") {
			selectedCharacterNumber = 2;
			PlaceCharacter (transform.position);
		} else {
			selectedCharacterNumber = 0;
			PlaceCharacter (transform.position);
		}
			playerControl = selectedCharacter.GetComponent<PlayerControl> ();
    }
	public void PlaceCharacter (Vector3 newPosition){
		Destroy (selectedCharacter,.01f);
		selectedCharacter = Instantiate (player [selectedCharacterNumber], newPosition, Quaternion.identity);
		selectedCharacter.name = player [selectedCharacterNumber].name;
		GameControl.SetCurrentPlayer (selectedCharacter);
		playerControl = selectedCharacter.GetComponent<PlayerControl> ();
    }
	public void PlaceCharacter (){
		Destroy (selectedCharacter, .01f);
		selectedCharacter = Instantiate (player [selectedCharacterNumber], new Vector3(0f, 0f, 0f), Quaternion.identity);
        selectedCharacter.name = player [selectedCharacterNumber].name;
		GameControl.SetCurrentPlayer (selectedCharacter);
		playerControl = selectedCharacter.GetComponent<PlayerControl> ();
    }
	public static void RevokeControl(){
        playerPaused = true;
        allowPlayerControl = false;
        playerControl.PausePlayerAnimation ();
        
    }
	public static void GrantControl(){
        playerPaused = false;
        allowPlayerControl = true;
        playerControl.ResumePlayerAnimation ();
    }
    public static void PlayerShowSprite(bool flag)
    {
        playerControl.ShowSprite(flag);
    }
    public static bool GetPlayerPaused()
    {
        return playerPaused;
    }
    public static bool GetAllowPlayerControl()
    {
        return allowPlayerControl;
    }
}
