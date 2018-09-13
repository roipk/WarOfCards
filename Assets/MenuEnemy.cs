using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class MenuEnemy : MonoBehaviour, IVirtualButtonEventHandler
{
#pragma warning disable CS0618 // Type or member is obsolete
    public GameObject player;
    GameObject vbBtnStart;
   // Animator anim;
    
    // Use this for initialization
    void Start () {
        vbBtnStart = GameObject.Find("BtnStartGameEnemy");
        vbBtnStart.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        player.active = false;
     //   anim = player.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!player.active && !gameObject.active)
        {   
            //vbBtnStart.active = true;
        }
    }


    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if (vb.gameObject.name == "BtnStartGameEnemy")
            vbBtnStart.active = false;
    }
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        if (vb.gameObject.name == "BtnStartGameEnemy")
        {
           // player.active = true;
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete
}
