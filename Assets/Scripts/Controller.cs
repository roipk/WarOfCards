using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

public class Controller : MonoBehaviour {
    protected Joystick joystick;
    //Rigidbody rb;
    Animation anim;
   // protected bool move;
  
    void Start () {
       // rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animation>();
        joystick = FindObjectOfType<Joystick>();   
    }
	
	// Update is called once per frame
	void Update () {


        


    }
}   
