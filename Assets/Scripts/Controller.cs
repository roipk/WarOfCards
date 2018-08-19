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

        /*  if (x != 0 && y != 0)
          float x = CrossPlatformInputManager.GetAxis("Horizontal");
          float y = CrossPlatformInputManager.GetAxis("Vertical");
          Vector3 movment = new Vector3(x, 0, y);
          rb.velocity = movment * 4f;

          {
              transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(x, y) * Mathf.Rad2Deg, transform.eulerAngles.z);
          }

              if (x != 0 || y != 0)
          {
              anim.Play("Walk");
          }

          else
          {
              anim.Play("Idle");
          }
         */

        


    }
}   
