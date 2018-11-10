using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVRTouchSample;

public enum LayerType{
    Conv,
    Pool,
    Dense,
    Full,
    Dropout
}

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(OVRGrabbable))]
public class Layer : MonoBehaviour {
    //public bool isBeingHeld = true;
    
    public new Rigidbody rigidbody;
    public OVRGrabbable grabbable;

    public LayerType layerType;

    private LayerManger manager;

    private Material material;

    public bool isBeingHeld()
    {
        return grabbable.isGrabbed;
    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        grabbable = GetComponent<OVRGrabbable>();
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnPickup()
    {
        rigidbody.isKinematic = false;
        rigidbody.useGravity = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        // For intial behvaiour after taking from spwan volume:
        OVRGrabber grabber = other.GetComponent<OVRGrabber>();
        if (grabber != null)
        {
            //OnPickup();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.LogError("hfi");
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (!isBeingHeld())
        {
            SnapContainer container = collision.collider.GetComponent<SnapContainer>();
            if(container == null)
            {
                Destroy(gameObject);
            }
        }
    }*/
}
