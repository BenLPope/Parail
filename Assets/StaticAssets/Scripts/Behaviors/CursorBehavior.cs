using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CursorBehavior : MonoBehaviour {
    public List<RectTransform> menuItem;
	public bool loopCursor;
    public int selectedItem;
    Transform windowText;
	RectTransform selCursor;
    float menuInputTimer = 0.0f;
    void Awake()
    {
        selCursor = this.GetComponent(typeof(RectTransform)) as RectTransform;
        windowText = transform.parent.GetChild(0).GetChild(0);
        foreach (RectTransform child in windowText)
        {
            menuItem.Add(child);
        }
        SelectUp(1);
    }
	void LateUpdate (){
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CanvasControl.CloseWindowFocus();
            Debug.Log("Closing Window");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Selecting item " + selectedItem);
            CanvasControl.OpenWindow(menuItem[selectedItem].name);
        }
		if (Input.GetKeyDown (KeyCode.W)) {
			selectedItem = SelectUp (selectedItem);
			CanvasControl.SetSelection(selectedItem);
		} else if (Input.GetKeyDown (KeyCode.S)) {
			selectedItem = SelectDown (selectedItem);
			CanvasControl.SetSelection(selectedItem);
		}
		if (Input.GetKey (KeyCode.W)) {
			menuInputTimer += Time.deltaTime;
			if (menuInputTimer >= 1 && menuInputTimer == 1) {
				selectedItem = SelectUp (selectedItem);
				CanvasControl.SetSelection(selectedItem);
			}
			else if (menuInputTimer > 1.2){
				selectedItem = SelectUp (selectedItem);
				CanvasControl.SetSelection(selectedItem);
				menuInputTimer = 1;
			}
		}
		if (Input.GetKey (KeyCode.S)) {
			menuInputTimer += Time.deltaTime;
			if (menuInputTimer >= 1 && menuInputTimer == 1) {
				selectedItem = SelectDown (selectedItem);
				CanvasControl.SetSelection(selectedItem);
			}
			else if (menuInputTimer > 1.2){
				selectedItem = SelectDown (selectedItem);
				CanvasControl.SetSelection(selectedItem);
				menuInputTimer = 1;
			}
		}
		if (Input.GetKeyUp (KeyCode.W))
			menuInputTimer = 0;
		if (Input.GetKeyUp (KeyCode.S))
			menuInputTimer = 0;
	}
	public int SelectDown (int currentSelection)
	{
		RectTransform tempTransform;
		if (currentSelection < menuItem.Count-1) {
			tempTransform = menuItem [currentSelection + 1];
			selCursor.position = new Vector3 (tempTransform.position.x - 16, tempTransform.position.y, 0f);
			return currentSelection + 1;
		} else if (loopCursor) {
			tempTransform = menuItem[0];
			selCursor.position = new Vector3 (tempTransform.position.x - 16, tempTransform.position.y, 0f);
			currentSelection = 0;
			return currentSelection;
		} else {
			return currentSelection;
		}
	}
	public int SelectUp (int currentSelection){
		RectTransform tempTransform;
		if (currentSelection > 0) {
			tempTransform = menuItem[currentSelection - 1];
			selCursor.position = new Vector3 (tempTransform.position.x - 16, tempTransform.position.y, 0f);
			return currentSelection - 1;
		} else if (loopCursor) {
			tempTransform = menuItem[menuItem.Count-1];
			selCursor.position = new Vector3 (tempTransform.position.x - 16, tempTransform.position.y, 0f);
			currentSelection = menuItem.Count -1;
			return currentSelection;
		} else {
			return currentSelection;
		}
	}
	}
