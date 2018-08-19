using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.EventSystems;

public class LookAround : MonoBehaviour {
    public GameObject player;
    public GameObject enemy;
    protected Joystick joystick;
   float speed =0.5f;

    float rotateSpeed;
    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        //enemy.transform.position = new Vector3(joystick.Horizontal * 100f*Time.deltaTime, joystick.Vertical * 100f * Time.deltaTime);

        //Debug.Log(joystick.Horizontal*100f);
        //enemy.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);

        //player.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);   
    }
}
