using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSpawner : MonoBehaviour {

    public GameObject LayerObj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit(Collider other)
    {
        Layer layer = other.GetComponent<Layer>();
        if (layer != null)
        {
            if (LayerObj)
            {
                Instantiate(LayerObj, this.transform.position, this.transform.rotation);
            }
        }
    }
}
