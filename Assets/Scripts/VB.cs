using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VB_anim : MonoBehaviour,IVirtualButtonEventHandler {
    public GameObject vbBtnObj;

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        throw new System.NotImplementedException();
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        throw new System.NotImplementedException();
    }

    // Use this for initialization
    void Start () {
        vbBtnObj = GameObject.Find("VirtualButtonNext");
        vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

	}
	



	// Update is called once per frame
	void Update () {
		
	}
}
