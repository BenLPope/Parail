using UnityEngine;
using System.Collections;
public class SpriteBehavior : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void LateUpdate () {
		GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 10f) * -1;
	}
}
