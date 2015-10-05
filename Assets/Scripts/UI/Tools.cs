using UnityEngine;
using System.Collections;

// Boy Voesten

// TODO:
//  Save what panels were open when you toggle the UI mode
//  Get a better way to save all the panels in the Array

public class Tools : MonoBehaviour
{

    private const string ITEM_PANEL = "ItemPanel";

    [SerializeField]
    private GameObject[] _UIPanels;
    private bool _UIActive = true;
    private int _activePanels = 0;

    // Detect the inputs
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            ToggleUIMode();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleActive(_UIPanels[0]);
        }
    }

    // Toggle between 'UI modes'
    public void ToggleUIMode()
    {
        if (_UIActive)
        {
            LockCursor(true);

            foreach (GameObject panel in _UIPanels)
            {
                panel.SetActive(false);
            }

            ClearPanel(_UIPanels[1].transform.FindChild(ITEM_PANEL));
            _activePanels = 0;
            _UIActive = false;
        }
        else
        {
            LockCursor(false);
            _UIActive = true;
        }

        Debug.Log("UI is now " + _UIActive);
    }

    // Toggle UI panels between active and inactive
    public void ToggleActive(GameObject obj)
    {
        Debug.Log("ToggleActive: " + obj.name);
        if (!obj.activeSelf)
        {
            obj.SetActive(true);
            _activePanels++;
            if (!_UIActive)
            {
                ToggleUIMode();
            }
        }
        else if (obj.activeSelf)
        {
            if (obj == _UIPanels[1])
            {
                ClearPanel(_UIPanels[1].transform.FindChild(ITEM_PANEL));
            }
            obj.SetActive(false);
            _activePanels--;
            if (_UIActive && _activePanels <= 0)
            {
                ToggleUIMode();
            }
        }
    }

    // Unlock/lock the mouse cursor
    void LockCursor(bool setLocked)
    {
        if (setLocked)
        {
            Debug.Log("Lock Cursor");
            Screen.lockCursor = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Debug.Log("Unlock Cursor");
            Screen.lockCursor = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    // Clear everything from given Transform, useful for re-using certain panels
    void ClearPanel(Transform panel)
    {
        foreach (Transform item in panel)
        {
            Destroy(item.gameObject);
        }
    }

    public void LoadScene(string scene)
    {
        Application.LoadLevel(scene);
    }

    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
		    Application.Quit();
        #endif
    }
}