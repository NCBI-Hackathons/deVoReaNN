using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class VRButton : MonoBehaviour {

    Collider collider;
    private LayerManger manager;

    private void Awake()
    {
        collider = GetComponent<Collider>();
        manager = (LayerManger)FindObjectOfType(typeof(LayerManger));
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        manager.OnStartCompute();
        Debug.LogError("EHEHEEEY");
    }
}
