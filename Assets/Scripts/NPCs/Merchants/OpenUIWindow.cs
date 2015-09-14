using UnityEngine;
using System.Collections;

public class OpenUIWindow : Interactible {

    [SerializeField] private GameObject _window;

    public override void Interact()
    {
        _window.SetActive(!_window.activeSelf);
    }
}
