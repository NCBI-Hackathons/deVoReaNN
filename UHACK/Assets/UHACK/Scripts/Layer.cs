using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LayerType{
    Conv,
    Pool,
    Full,
    Dense,
    Flatten,
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

    public Color color;

    public bool isBeingHeld()
    {
        return true;
        //return grabbable.isGrabbed;
    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
