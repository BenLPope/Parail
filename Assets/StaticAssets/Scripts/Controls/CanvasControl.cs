using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasControl : MonoBehaviour
{
    public static CanvasControl control;
    static Stack<GameObject> windowFocus = new Stack<GameObject>();
    static int selectedItem;
    static GameObject screenOverlay;
    static GameObject screenUnderlay;
    public bool allowControl = false;
    static GameObject parentObject;
    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
        screenUnderlay = Instantiate(Resources.Load("Entities/UI/Windows/UI Screen Underlay"), this.transform) as GameObject;
        screenUnderlay.name = "Screen Underlay";
        screenOverlay = Instantiate(Resources.Load("Entities/UI/Windows/UI Screen Overlay"), this.transform) as GameObject;
        screenOverlay.name = "Screen Overlay";
        screenOverlay.transform.SetSiblingIndex(0);
        parentObject = this.gameObject;
    }
    void LateUpdate()
    {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (windowFocus.Count == 0)
                {
                    OpenWindow("Main Menu Window");
                }
            }
        if (allowControl)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                if (windowFocus.Count == 0)
                {
                    OpenWindow("Player Menu");
                }
            }
        }
    }
    public static void SetSelection(int index)
    {
        selectedItem = index;
    }
    public static void OpenWindow(string windowName)
    {
        if (Resources.Load("Entities/UI/Windows/" + windowName) == null)
        {
            Debug.Log("Window not found! Checking Commands");
            if (windowName == "Back")
            {
                CloseWindowFocus();
                return;
            }
            //if (Resources.Load("Entities/UI/Windows Commands/" + windowName) == null)
            //{
                //Debug.Log("Window Command not found!");
            //}
            return;
        }
        if (windowFocus.Count == 0)
        {
            windowFocus.Push(Instantiate(Resources.Load("Entities/UI/Windows/" + windowName), parentObject.transform ) as GameObject);
            windowFocus.Peek().name = windowName;
            screenUnderlay.transform.SetAsFirstSibling();
            screenOverlay.transform.SetAsLastSibling();
            PlayerManager.RevokeControl();
            return;
        }
        else
        {
            windowFocus.Peek().gameObject.SetActive(false);
            windowFocus.Push(Instantiate(Resources.Load("Entities/UI/Windows/" + windowName),parentObject.transform) as GameObject);
            windowFocus.Peek().name = windowName;
            screenUnderlay.transform.SetAsFirstSibling();
            screenOverlay.transform.SetAsLastSibling();
            PlayerManager.RevokeControl();
        }
    }
    public static void CloseWindowFocus()
    {
        if (windowFocus.Count == 0)
        {
            Debug.Log("No Windows");
            return;
        }
        else
        {
            Destroy(windowFocus.Pop());
            if (windowFocus.Count != 0)
            {
                windowFocus.Peek().gameObject.SetActive(true);
            }
            if (windowFocus.Count == 0)
            {
                PlayerManager.GrantControl();
            }
        }
    }
    void SetAllowControl(bool flag)
    {
        allowControl = flag;
    }
}