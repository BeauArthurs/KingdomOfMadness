using UnityEngine;
using System.Collections;

// Boy Voesten

public class Interaction : MonoBehaviour {

    private float _maxDistance = 5f;
    private int _layerMask = 1 << 8;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Ray ray = new Ray(transform.position, forward);
            RaycastHit hit;

            Physics.Raycast(ray, out hit, _maxDistance, _layerMask);
            Debug.DrawRay(transform.position, forward);

            if (hit.collider != null)
            {
                Debug.Log("Interact with: " + hit.collider.name);
                hit.collider.gameObject.GetComponent<Interactible>().Interact();
            }
        }
    }


}
