using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour {
    private Touch touch;
    public float speed=200f;
    private Rigidbody rb;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    float rayLangth;

    public Camera mainCamera;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        touch = Input.GetTouch(0);
	}
	
	// Update is called once per frame
	void Update () {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput*speed;

        Ray cameraRay = mainCamera.ScreenPointToRay(touch.position);
       // Vector3 pointLock = cameraRay.GetPoint(rayLangth);
       if(Input.touchCount>0)
        Debug.Log(Input.GetTouch(0).position);
        //transform.LookAt(pointLock);
	}

    private void FixedUpdate()
    {
        rb.velocity = moveVelocity;
    }
}
