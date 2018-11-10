using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    public Text progressText;

    public Text[] IDArrays;

    public void UpdateProgressText(string text)
    {
        progressText.text = text;
    }

    public void UpdateContainerText(int ID, string text)
    {
        IDArrays[ID].text = text;
    }

}
