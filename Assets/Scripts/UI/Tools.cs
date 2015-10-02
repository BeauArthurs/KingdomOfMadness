using UnityEngine;
using System.Collections;

// Boy Voesten

    // TODO:
    //  Fix the ToggleActive to work with the UIActive correctly
    //  Save what panels were open when you toggle the UI mode

public class Tools : MonoBehaviour {

    [SerializeField] private GameObject[] _UIPanels;
    private bool _UIActive = true;
    private int _activePanels = 0;

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

    public void ToggleUIMode()
    {
        if (_UIActive)
        {
            Debug.Log("Lock cursor");
            Screen.lockCursor = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            foreach (GameObject panel in _UIPanels)
            {
                panel.SetActive(false);
            }
            _activePanels = 0;
            _UIActive = false;
        }
        else
        {
            Debug.Log("Unlock cursor");
            Screen.lockCursor = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            _UIActive = true;
        }
        Debug.Log("UI is now " + _UIActive);
    }

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
            obj.SetActive(false);
            _activePanels--;
            if (_UIActive && _activePanels <= 0) 
            {
                ToggleUIMode();
            }
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