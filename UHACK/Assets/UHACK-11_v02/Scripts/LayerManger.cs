using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManger : MonoBehaviour {

    const int NUM_LAYERS = 8;

    public bool hasValidLayers = false;

    SnapContainer[] Containers;

    DataStream dataStream;

    EvaluateSimple evalSimple;


    UI UIManager;

    bool hasComputed = false;

    //ON FINISH - NOW CAN START COMPUTE again
    public void SetAcurracyText(float acc)
    {
        UIManager.UpdateProgressText("Accuracy: " + (acc*100).ToString("0.00") + "%");
        hasComputed = false;
        dataStream.gameObject.SetActive(false);
    }

    public void OnStartCompute()
    {
        // only run once
        if (hasComputed) return;
        hasComputed = true;


        //On Second Run:
        UIManager.UpdateProgressText("Processing...");


        if (dataStream)
        {
            dataStream.gameObject.SetActive(true);
        }


        if (evalSimple)
        {
            List<int> temp_Containers = new List<int>(); // Stores ID's of containers in Containers.
            for(int e = 0; e< Containers.Length; e++)
            {
                if (Containers[e].ActiveLayer != null)
                {
                    temp_Containers.Add(e);
                }
            }

            LayerType[] layers = new LayerType[temp_Containers.Count];
            for(int i = 0; i < temp_Containers.Count; i++)
            {
                layers[i] = Containers[temp_Containers[i]].ActiveLayer.layerType;

                //Debug.LogError(" : " + Containers[i].ActiveLayer.layerType);
            }
            StartCoroutine(evalSimple.Evaluate(layers));

        }
    }

    private void Awake()
    {
        SnapContainer[] tempContainers = FindObjectsOfType<SnapContainer>();

        if (NUM_LAYERS != tempContainers.Length)
        {
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

        hasValidLayers = ValidateLayers();

        for(int e = 0; e<Containers.Length; e++)
        {
            Debug.Log("Container " +e+" is Valid: " + Containers[e].ActiveLayer);
        }

    }

    private void Start()
    {
        dataStream = FindObjectOfType<DataStream>();
        dataStream.gameObject.SetActive(false);

        UIManager = FindObjectOfType<UI>();

        evalSimple = FindObjectOfType<EvaluateSimple>();
    }

    public bool ValidateLayers()
    {
        bool valid = true;
        if (Containers.Length != NUM_LAYERS) return false;

        // Check if first is convlotional layer:
        if(Containers[0].ActiveLayer != null)
        {
            valid &= Containers[0].ActiveLayer.layerType == LayerType.Conv;
            Debug.LogWarning("First is Conv");
        }
        if (Containers[NUM_LAYERS-1].ActiveLayer != null)
        {
            // Check if the last is Dense
            valid &= Containers[NUM_LAYERS-1].ActiveLayer.layerType == LayerType.Dense;
            Debug.LogWarning("Last is Dense");

        }

        bool bHasOtherTypeOfLayer = false;
        // Dense layers have to come after Pulling:
        for (int i = 1; i < NUM_LAYERS-2; i++)
        {
            if (Containers[i].ActiveLayer == null) continue;

            if (Containers[i].ActiveLayer.layerType != LayerType.Dense)
            {
                bHasOtherTypeOfLayer = true;
            }
            else if(Containers[i].ActiveLayer.layerType == LayerType.Dense)
            {
                if (!bHasOtherTypeOfLayer) valid &= true;
                else valid = false;
            }
        }

        Debug.LogWarning("IS IT VALID: " + valid);

        return valid;
    }

    public void UpdateNodeStructure()
    {
        if (AreContainersAllFull())
        {
            dataStream.gameObject.SetActive(true);
            //OnStartCompute();
        }
        else
        {
            dataStream.gameObject.SetActive(false);
        }
    }


    public bool AreContainersAllFull()
    {
        for(int i=0; i < Containers.Length; i++)
        {
            if (Containers[i].ActiveLayer == null)
                return false;
        }
        return true;
    }
	
	// Update is called once per frame
	void Update () {
        //ValidateLayers(); // TODO: take out of tick and activate only on trigger enter
	}
}
