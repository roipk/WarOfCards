using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class controller1 : MonoBehaviour {
    static Animator anim;
    public JoyButton joyButtonAttack;
    public JoyButton joyButtonBlock;
    public float speed = 15.0f;
    public float rotationSpeed = 5.0f;

    public PlayerController controllerJoystic;
    public Vector3 moveVector { set; get; }
    

    void Start() {
        anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
     void Update() {

        moveVector = PoolInput();
        Rotation();
        Move();

      }


    private void Rotation()
    {
        Vector3 relativePos = new Vector3(0f, 0f, 0f);
        
         //top to left
         if (moveVector.x == 0 && moveVector.z > 0)
            relativePos = new Vector3(0f, 0f, -1f);
        if (moveVector.x >= -0.1 && moveVector.x < 0 && moveVector.z > 0)
             relativePos = new Vector3(0.1f, 0f, -0.9f);
         if (moveVector.x >= -0.2 && moveVector.x < -0.1 && moveVector.z > 0)
             relativePos = new Vector3(0.2f, 0f, -0.8f);
         if (moveVector.x >= -0.3 && moveVector.x < -0.2 && moveVector.z > 0)
             relativePos = new Vector3(0.3f, 0f, -0.7f);
         if (moveVector.x >= -0.4 && moveVector.x < -0.3 && moveVector.z > 0)
             relativePos = new Vector3(0.4f, 0f, -0.6f);
         if (moveVector.x >= -0.5 && moveVector.x < -0.4 && moveVector.z > 0)
             relativePos = new Vector3(0.5f, 0f, -0.5f);
         if (moveVector.x >= -0.6 && moveVector.x < -0.5 && moveVector.z > 0)
             relativePos = new Vector3(0.6f, 0f, -0.4f);
         if (moveVector.x >= -0.7 && moveVector.x < -0.6 && moveVector.z > 0)
             relativePos = new Vector3(0.7f, 0f, -0.3f);
         if (moveVector.x >= -0.8 && moveVector.x < -0.7 && moveVector.z > 0)
             relativePos = new Vector3(0.8f, 0f, -0.2f);
         if (moveVector.x >= -0.9 && moveVector.x < -0.8 && moveVector.z > 0)
             relativePos = new Vector3(0.9f, 0f, -0.1f);
         if (moveVector.x >= -1 && moveVector.x < -0.9 && moveVector.z > 0)
             relativePos = new Vector3(1f, 0f, 0f);


             //top to right 
             if (moveVector.x == 0 && moveVector.z > 0)
                 relativePos = new Vector3(0f, 0f, -1f);
            if (moveVector.x > 0 && moveVector.x < 0.1 && moveVector.z > 0)
                 relativePos = new Vector3(-0.1f, 0f, -0.9f);
             if (moveVector.x > 0.1 && moveVector.x <= 0.2 && moveVector.z > 0)
                 relativePos = new Vector3(-0.2f, 0f, -0.8f);
             if (moveVector.x > 0.2 && moveVector.x <= 0.3 && moveVector.z > 0)
                 relativePos = new Vector3(-0.3f, 0f, -0.7f);
             if (moveVector.x > 0.3 && moveVector.x <= 0.4 && moveVector.z > 0)
                 relativePos = new Vector3(-0.4f, 0f, -0.6f);
             if (moveVector.x > 0.4 && moveVector.x <= 0.5 && moveVector.z > 0)
                 relativePos = new Vector3(-0.5f, 0f, -0.5f);
             if (moveVector.x > 0.5 && moveVector.x <= 0.6 && moveVector.z > 0)
                 relativePos = new Vector3(-0.6f, 0f, -0.4f);
             if (moveVector.x > 0.6 && moveVector.x <= 0.7 && moveVector.z > 0)
                 relativePos = new Vector3(-0.7f, 0f, -0.3f);
             if (moveVector.x > 0.7 && moveVector.x <= 0.8 && moveVector.z > 0)
                 relativePos = new Vector3(-0.8f, 0f, -0.2f);
             if (moveVector.x > 0.8 && moveVector.x <= 0.9 && moveVector.z > 0)
                 relativePos = new Vector3(-0.9f, 0f, -0.1f);
             if (moveVector.x > 0.9 && moveVector.x <= 1 && moveVector.z > 0)
                 relativePos = new Vector3(-1f, 0f, 0f);









             //botton to right 
             if (moveVector.x == 0 && moveVector.z < 0)
                 relativePos = new Vector3(0f, 0f, 1f);
            if (moveVector.x > 0 && moveVector.x <= 0.1 && moveVector.z < 0)
                 relativePos = new Vector3(-0.1f, 0f, 0.9f);
             if (moveVector.x > 0.1 && moveVector.x <= 0.2 && moveVector.z < 0)
                 relativePos = new Vector3(-0.2f, 0f, 0.8f);
             if (moveVector.x > 0.2 && moveVector.x <= 0.3 && moveVector.z < 0)
                 relativePos = new Vector3(-0.3f, 0f, 0.7f);
             if (moveVector.x > 0.3 && moveVector.x <= 0.4 && moveVector.z < 0)
                 relativePos = new Vector3(-0.4f, 0f, 0.6f);
             if (moveVector.x > 0.4 && moveVector.x <= 0.5 && moveVector.z < 0)
                 relativePos = new Vector3(-0.5f, 0f, 0.5f);
             if (moveVector.x > 0.5 && moveVector.x <= 0.6 && moveVector.z < 0)
                 relativePos = new Vector3(-0.6f, 0f, 0.4f);
             if (moveVector.x > 0.6 && moveVector.x <= 0.7 && moveVector.z < 0)
                 relativePos = new Vector3(-0.7f, 0f, 0.3f);
             if (moveVector.x > 0.7 && moveVector.x <= 0.8 && moveVector.z < 0)
                 relativePos = new Vector3(-0.8f, 0f, 0.2f);
             if (moveVector.x > 0.8 && moveVector.x <= 0.9 && moveVector.z < 0)
                 relativePos = new Vector3(-0.9f, 0f, 0.1f);
            if (moveVector.x > 0.9 && moveVector.x <= 1 && moveVector.z < 0)
                 relativePos = new Vector3(-1f, 0f, 0f);






             //botton to left
             if (moveVector.x == 0 && moveVector.z < 0)
                 relativePos = new Vector3(0f, 0f, 1f);
            if (moveVector.x >= -0.1 && moveVector.x < 0 && moveVector.z < 0)
                 relativePos = new Vector3(0.1f, 0f, 0.9f);
             if (moveVector.x >= -0.2 && moveVector.x < -0.1 && moveVector.z < 0)
                 relativePos = new Vector3(0.2f, 0f, 0.8f);
             if (moveVector.x >= -0.3 && moveVector.x < -0.2 && moveVector.z < 0)
                 relativePos = new Vector3(0.3f, 0f, 0.7f);
             if (moveVector.x >= -0.4 && moveVector.x < -0.3 && moveVector.z < 0)
                 relativePos = new Vector3(0.4f, 0f, 0.6f);
             if (moveVector.x >= -0.5 && moveVector.x < -0.4 && moveVector.z < 0)
                 relativePos = new Vector3(0.5f, 0f, 0.5f);
             if (moveVector.x >= -0.6 && moveVector.x < -0.5 && moveVector.z < 0)
                 relativePos = new Vector3(0.6f, 0f, 0.4f);
             if (moveVector.x >= -0.7 && moveVector.x < -0.6 && moveVector.z < 0)
                 relativePos = new Vector3(0.7f, 0f, 0.3f);
             if (moveVector.x >= -0.8 && moveVector.x < -0.7 && moveVector.z < 0)
                 relativePos = new Vector3(0.8f, 0f, 0.2f);
             if (moveVector.x >= -0.9 && moveVector.x < -0.8 && moveVector.z < 0)
                 relativePos = new Vector3(0.9f, 0f, 0.1f);
            if (moveVector.x >= -1 && moveVector.x < -0.9 && moveVector.z < 0)
                 relativePos = new Vector3(1f, 0f, 0f);





        Debug.Log(moveVector);
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        Quaternion corrent = transform.localRotation;
        transform.localRotation = Quaternion.Slerp(corrent, rotation, Time.deltaTime*rotationSpeed);
    }
    private void Move()
    {
                if (joyButtonAttack.Pressed)
                      anim.SetBool("isAttack", true);

                  else
                      anim.SetBool("isAttack", false);

                  if (joyButtonBlock.Pressed)
                      anim.SetBool("isBlocking", true);
                  else
                      anim.SetBool("isBlocking", false);
                  if(moveVector.x != 0 || moveVector.z != 0)
                  {
                    this.transform.Translate(0f, 0f, speed*Time.deltaTime);
                    anim.SetBool("isWalking", true);
                  }
                  else
                  {
                      anim.SetBool("isWalking", false);
                  }
    }

    private Vector3 PoolInput()
    {
        Vector3 dir = Vector3.zero;
        dir.x = controllerJoystic.Horizontal();
        dir.z = controllerJoystic.Vertical();

        if (dir.magnitude > 1)
            dir.Normalize();

        return dir;
    }


}

