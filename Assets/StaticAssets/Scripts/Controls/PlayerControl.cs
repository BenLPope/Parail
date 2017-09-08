using UnityEngine;
using System.Collections;
public class PlayerControl : MonoBehaviour {
	public float speed = 1f; 
    public GameObject[] player;
    public Vector3 position;
    float movementTimer = 0;
    GameObject selectedCharacter;
	float 	moveX, 
	moveY, 
	lastInputX = 0f, 
	lastInputY = 0f;
	Animator playerAnimator;
    SpriteRenderer spriteRenderer;
    void Awake()
    {
        selectedCharacter = gameObject;
        playerAnimator = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine(ForceMovePlayer(0, 0, -1, 0));
        spriteRenderer.enabled = true;
        PausePlayerAnimation();
    }
	void FixedUpdate () {
		if (PlayerManager.GetAllowPlayerControl()) {
			lastInputX = Input.GetAxisRaw ("Horizontal");
			lastInputY = Input.GetAxisRaw ("Vertical");
			moveX = Input.GetAxis ("Horizontal");
			moveY = Input.GetAxis ("Vertical");
			playerAnimator.SetFloat ("moveX", moveX);
			playerAnimator.SetFloat ("moveY", moveY);
			if (lastInputX == 0 && lastInputY == 0) {
				playerAnimator.Play ("Idle");
				playerAnimator.SetBool ("isWalking", false);
			} else {
				playerAnimator.Play ("Move");
				playerAnimator.SetBool ("isWalking", true);
				if (lastInputX > 0) {
					playerAnimator.SetFloat ("lastX", 1f);
				} else if (lastInputX < 0) {
					playerAnimator.SetFloat ("lastX", -1f);
				} else {
					playerAnimator.SetFloat ("lastX", 0f);
				}
				if (lastInputY > 0) {
					playerAnimator.SetFloat ("lastY", 1f);
				} else if (lastInputY < 0) {
					playerAnimator.SetFloat ("lastY", -1f);
				} else {
					playerAnimator.SetFloat ("lastY", 0f);
				}	
			}
			if (selectedCharacter.name != "noCharacter") {
				selectedCharacter.transform.position += new  Vector3 (moveX * speed * Time.deltaTime, moveY * speed * Time.deltaTime, 0);
				position = selectedCharacter.transform.position;
			}
		}
	}
    public void PausePlayerAnimation(){
        if (!playerAnimator)
        {
            playerAnimator = gameObject.GetComponent<Animator>();
            playerAnimator.speed = 1;
        }
		playerAnimator.speed = 0;
	}
	public void ResumePlayerAnimation(){
		playerAnimator.speed = 1;
	}
    IEnumerator ForceMovePlayer(float timeToMove, int directionX, int directionY, int moveSpeed) {
        movementTimer = 0;
        while (movementTimer <= timeToMove)
        {
            lastInputX = directionX;
            lastInputY = directionY;
            moveX = directionX;
            moveY = directionY;
            playerAnimator.SetFloat("moveX", moveX);
            playerAnimator.SetFloat("moveY", moveY);
            if (lastInputX == 0 && lastInputY == 0)
            {
                playerAnimator.Play("Idle");
                playerAnimator.SetBool("isWalking", false);
            }
            else
            {
                playerAnimator.Play("Move");
                playerAnimator.SetBool("isWalking", true);
                if (lastInputX > 0)
                {
                    playerAnimator.SetFloat("lastX", 1f);
                }
                else if (lastInputX < 0)
                {
                    playerAnimator.SetFloat("lastX", -1f);
                }
                else
                {
                    playerAnimator.SetFloat("lastX", 0f);
                }
                if (lastInputY > 0)
                {
                    playerAnimator.SetFloat("lastY", 1f);
                }
                else if (lastInputY < 0)
                {
                    playerAnimator.SetFloat("lastY", -1f);
                }
                else
                {
                    playerAnimator.SetFloat("lastY", 0f);
                }
            }
            if (selectedCharacter.name != "noCharacter")
            {
                selectedCharacter.transform.position += new Vector3(moveX * moveSpeed * Time.deltaTime, moveY * moveSpeed * Time.deltaTime, 0);
                position = selectedCharacter.transform.position;
            }
            movementTimer += Time.deltaTime;
            yield return null;
        }
    }
    public void ShowSprite(bool flag)
    {
        spriteRenderer.enabled = flag;
    }
}
