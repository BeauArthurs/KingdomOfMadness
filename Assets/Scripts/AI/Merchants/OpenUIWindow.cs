using UnityEngine;
using System.Collections;

// Boy Voesten

public class OpenUIWindow : Interactible {

    [SerializeField] 
    private GameObject _window;
    private Tools _UIManager;

    void Start() {
        _UIManager = GameObject.FindGameObjectWithTag(TagList.UIManager).GetComponent<Tools>();
    }

    public override void Interact()
    {
        _UIManager.ToggleActive(_window);
    }
}
