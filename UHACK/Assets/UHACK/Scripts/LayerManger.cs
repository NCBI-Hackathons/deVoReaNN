using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManger : MonoBehaviour {

    const int NUM_LAYERS = 4;

    SnapContainer[] Containers;

    private void Awake()
    {
        SnapContainer[] tempContainers =  FindObjectsOfType<SnapContainer>();

        if (NUM_LAYERS != tempContainers.Length) {
            Debug.LogError("ERROR: Container ID's not set. Check that NUM_LAYERS is of correct length.");
            return;
        }

        Containers = new SnapContainer[NUM_LAYERS];

        // Order Containers to be in the order of SnapContainers.
        for (int i = 0; i < NUM_LAYERS; i++)
        {
            int ID = tempContainers[i].ContainerID;
            Containers[ID] = tempContainers[i];
        }

    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
