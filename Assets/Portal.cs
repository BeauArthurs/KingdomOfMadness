using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

    public string scene;

	void OnTriggerEnter(Collider other)
    {
        if(other.tag == TagList.Player)
        {
            Application.LoadLevel(scene);
        }
    }
}
