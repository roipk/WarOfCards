using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;



public class NewWalk : MonoBehaviour {

    public GameObject player;
    public GameObject test;
    float speedWalk = 200f;
    float speedRound;
    //Rigidbody rg;

    protected JoyButton joyButton;
    Quaternion target;

    float x2 = 0;
    float y2 = 0;
  

    // Use this for initialization
    void Start () {
        speedRound = speedWalk / 2;
        joyButton = FindObjectOfType<JoyButton>();
        //rg = test.GetComponent<Rigidbody>();
        // target = Quaternion.Euler(0, (Mathf.Atan2(x, y) * Mathf.Rad2Deg), 0);

    }

    // Update is called once per frame
    void Update() {
        

        x2 = CrossPlatformInputManager.GetAxisRaw("Horizontal_2");
        y2 = CrossPlatformInputManager.GetAxisRaw("Vertical_2");
        float w = (Mathf.Atan2(x2, y2) * Mathf.Rad2Deg);
       // Debug.Log(w);
        float t = 0;
        if ((w > 90 && w <= 135) || (w > 0 && w <= 45) || (w<180 && w>=90) ||(w <= 90 && w >= 45))
            t = 4f;
          
        else if ((w < -90 && w >= -135) || (w < 0 && w >= -45) || (w>-180 && w<=-135) || (w >= -90 && w <= -45))
            t = -4f;
        else
            t = 0;
                
        test.transform.Rotate(Vector3.up,t, Space.Self);
          
        



    }
   
   
}
