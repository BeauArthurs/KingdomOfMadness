using UnityEngine;
using System.Collections;

public class Tools : MonoBehaviour {

	public void ToggleActive(GameObject obj)
    {
        obj.SetActive(!obj.activeSelf);
    }

    public void LoadScene(string scene)
    {
        Application.LoadLevel(scene);
    }

    public void Drag(GameObject obj)
    {
        Vector3 startValue = Input.mousePosition;
        obj.transform.position = Input.mousePosition;
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