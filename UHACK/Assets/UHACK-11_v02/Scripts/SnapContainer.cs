using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapContainer : MonoBehaviour {

    BoxCollider Collider;

    public Layer ActiveLayer;

    private LayerManger manager;

    public int ContainerID = -1;

	// Use this for initialization
	void Start () {
        Collider = this.GetComponent<BoxCollider>();
        manager = FindObjectOfType<LayerManger>();
    }

    // Update is called once per frame
    void Update () {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Layer layer = other.GetComponent<Layer>();
        if(layer != null)
        {
            if (!layer.isBeingHeld())
            {
                ActiveLayer = layer;

                layer.rigidbody.isKinematic = true;
                layer.rigidbody.useGravity = false;
                Vector3 otherT = other.gameObject.transform.position;
                other.gameObject.transform.position = this.transform.position;//.SetPositionAndRotation(otherT - transform.position);
                other.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));

                //CheckForCompleteNetwork(); //ADDED - add to trigger stay as well
                //manager.UpdateNodeStructure();

            }
        }
    }

    private void OnTriggerStay(Collider other)
    {

        Layer layer = other.GetComponent<Layer>();
        if (layer != null)
        {
            if (!layer.isBeingHeld())
            {
                ActiveLayer = layer;

                //UpdateText();


                layer.rigidbody.isKinematic = true;
                layer.rigidbody.useGravity = false;
                Vector3 otherT = other.gameObject.transform.position;
                other.gameObject.transform.position = this.transform.position;//.SetPositionAndRotation(otherT - transform.position);
                other.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));

                
                //CheckForCompleteNetwork();//ADDED - add to trigger stay as well
                //manager.UpdateNodeStructure();
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        ActiveLayer = null; //ADDED

        Layer layer = other.GetComponent<Layer>();
        if (layer != null)
        {
            ActiveLayer = null;

            layer.rigidbody.isKinematic = false;
            layer.rigidbody.useGravity = true;
        }
    }

    private void CheckForCompleteNetwork()
    {
        

        Debug.LogError("SNAP");

        if (manager)
        {
            // If all containers are full, execute the network:
            if (manager.AreContainersAllFull())
            {
                manager.ValidateLayers();
                if (manager.hasValidLayers)
                {
                    Debug.LogError("SNAP - Has Valid Layers");

                    // Run machine learning code.
                }
                else Debug.LogError("Invalid Network");
            }
            // If Containers are not full, check this current object is valid:
            else
            {
                Debug.LogError("SNAP - Containers Not full");

                manager.ValidateLayers();
                if (!manager.hasValidLayers)
                {
                    Destroy(ActiveLayer.gameObject); // Destroy the object if not valid
                    ActiveLayer = null;
                }
            }

        }
    }

}
