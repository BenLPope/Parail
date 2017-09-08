using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CursorBehaviorDWide : MonoBehaviour {
    public List<RectTransform> menuItem;
	public bool loopCursor;
    public int selectedItem;
    Transform windowText;
	RectTransform selCursor;
    CanvasControl canvasControl;
    float menuInputTimer = 0.0f;
    void Awake()
    {
        selCursor = this.GetComponent(typeof(RectTransform)) as RectTransform;
        windowText = transform.parent.GetChild(0).GetChild(0);
        foreach (RectTransform child in windowText)
        {
            menuItem.Add(child);
        }
        canvasControl = transform.root.GetComponent<CanvasControl>();
        SelectUp(1);
    }
	void LateUpdate (){
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CanvasControl.CloseWindowFocus();
            Debug.Log("Closing Window");
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
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
        if (Input.GetKeyDown(KeyCode.D))
        {
            selectedItem = SelectRight(selectedItem);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            selectedItem = SelectLeft(selectedItem);
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
        if (currentSelection < menuItem.Count -1)
        {
            if (currentSelection == 3)
            {
                return currentSelection;
            }
            tempTransform = menuItem[currentSelection +1];
            selCursor.position = new Vector3(tempTransform.position.x - 16, tempTransform.position.y, 0f);
            return currentSelection + 1;
        }
        else
        {
            return currentSelection;
        }
    }
    public int SelectUp (int currentSelection){
		RectTransform tempTransform;
		if (currentSelection > 0) {
            if (currentSelection == 4)
            {
                return currentSelection;
            }
            tempTransform = menuItem[currentSelection - 1];
			selCursor.position = new Vector3 (tempTransform.position.x - 16, tempTransform.position.y, 0f);
			return currentSelection - 1;
		}
        else
        {
            return currentSelection;
        }
	}
    public int SelectRight(int currentSelection)
    {
        RectTransform tempTransform;
            if (currentSelection + menuItem.Count/2 + menuItem.Count%2 >= menuItem.Count )
            {
                return currentSelection;
            }
            else
            {
                currentSelection = currentSelection  + (menuItem.Count/2) + (menuItem.Count%2);
            }
            tempTransform = menuItem[currentSelection];
            selCursor.position = new Vector3(tempTransform.position.x - 16, tempTransform.position.y, 0f);
            return currentSelection;
    }
    public int SelectLeft(int currentSelection)
    {
        RectTransform tempTransform;
        if (currentSelection - menuItem.Count/2 - menuItem.Count%2  < 0)
        {
            return currentSelection;
        }
        else
        {
            currentSelection = currentSelection - (menuItem.Count / 2) - (menuItem.Count % 2);
        }
        tempTransform = menuItem[currentSelection];
        selCursor.position = new Vector3(tempTransform.position.x - 16, tempTransform.position.y, 0f);
        return currentSelection;
    }
}
