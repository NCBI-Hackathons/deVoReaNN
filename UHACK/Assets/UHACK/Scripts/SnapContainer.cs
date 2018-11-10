using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapContainer : MonoBehaviour {

    BoxCollider Collider;

    Layer ActiveLayer;

    public int ContainerID = -1;

	// Use this for initialization
	void Start () {
        Collider = this.GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Layer layer = other.GetComponent<Layer>();
        if(layer != null)
        {
            if (layer.isBeingHeld())
            {
                ActiveLayer = layer;

                layer.rigidbody.isKinematic = true;
                layer.rigidbody.useGravity = false;
                Vector3 otherT = other.gameObject.transform.position;
                other.gameObject.transform.position = this.transform.position;//.SetPositionAndRotation(otherT - transform.position);
            }
        }
    }

}
