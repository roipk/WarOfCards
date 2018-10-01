using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class vb_anim : MonoBehaviour , IVirtualButtonEventHandler {
    GameObject vbBtnObj;
    GameObject btn;
    public Material[] materials;
    Renderer rend;
    public Animator cubeAni;
    public GameObject g;
    // Use this for initialization
    Vector3 scale;
    float counter;
    bool increas;

    void Start () {
#pragma warning disable CS0618 // Type or member is obsolete
        g.active = true;
#pragma warning restore CS0618 // Type or member is obsolete
        vbBtnObj = GameObject.Find("TestBtn");
        vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        btn = GameObject.Find("Test2Btn");
        btn.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        cubeAni.GetComponent<Animator>();
        counter = 0;
        scale = new Vector3(0.05f, 0.05f, 0.05f);
        rend = g.GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = materials[0];
        increas = true;
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if (vb.gameObject.name == "TestBtn")
        {
            cubeAni.Play("CubeAnimation");
#pragma warning disable CS0618 // Type or member is obsolete
            vbBtnObj.active = false;
#pragma warning restore CS0618 // Type or member is obsolete
        }
        if (vb.gameObject.name == "Test2Btn")
        {
            if (g.transform.localScale.x + scale.x >= 0.0452 && g.transform.localScale.x + scale.x <= 0.552)
                g.transform.localScale += scale;
#pragma warning disable CS0618 // Type or member is obsolete
            btn.active = false;
#pragma warning restore CS0618 // Type or member is obsolete

        }
    }
	  public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        if (vb.gameObject.name == "TestBtn")
        {
            cubeAni.Play("none");
    #pragma warning disable CS0618 // Type or member is obsolete
            vbBtnObj.active = true;
    #pragma warning restore CS0618 // Type or member is obsolete
        }
        if (vb.gameObject.name == "Test2Btn")
        {
#pragma warning disable CS0618 // Type or member is obsolete
            btn.active = true;
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (increas)
            rend.sharedMaterial = materials[0];
        else
            rend.sharedMaterial = materials[1];
 
#pragma warning disable CS0618 // Type or member is obsolete
        if (btn.active)
#pragma warning restore CS0618 // Type or member is obsolete
        {
            counter = 0;
        }
        else
        {
            counter += 1 * Time.deltaTime;
        }

        if ((int) counter >= 2)
        {
            increas = !increas;
            counter = 0;
            scale *= -1;
        }

    }
}
