using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;
using UnityEngine.UI;


public class controller1 : MonoBehaviour {
    static Animator anim;
    public JoyButton joyButtonAttack;
    public JoyButton joyButtonBlock;
    public float speed = 15.0f;
    public float rotationSpeed = 5.0f;
    public Transform enemy;
    private bool sideEnemy = false;
    Vector3 relativePos;
    public Slider hp;
    public GameObject sward;
    public PlayerController controllerJoystic;
    public Vector3 moveVector { set; get; }

    float counter;
    void Start() {
        anim = GetComponent<Animator>();
        relativePos = new Vector3(0f, 0f, -1f);
        counter = 0;
        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.LookRotation(enemy.position), Time.deltaTime);
    }

    // Update is called once per frame
     void Update() {

        act();
        if (counter >= 5)
            this.enabled = false;

        if (hp.value <= 0)
        {
            counter += 1 * Time.deltaTime;
            return;
        }
        else
        {
            //relativePos = Vector3.forward;
                moveVector = PoolInput();
            if (moveVector.x != 0 || moveVector.z != 0)
            {
                Rotation();
                Move();
            }
            else
            {
                anim.SetBool("isWalking", false);
                
            }
           
        }
    }


    private void Rotation()
    {
          

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



            

       

       
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        Quaternion corrent = transform.localRotation;
        transform.localRotation = Quaternion.Slerp(corrent, rotation, Time.deltaTime*rotationSpeed);
    }
    private void Move()
    {
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


    private void act()
    {
        
        if (joyButtonAttack.Pressed)
        {
            
            anim.SetBool("isAttack", true);
        }

        else
        {
            anim.SetBool("isAttack", false);
        }
        if (joyButtonBlock.Pressed)
            anim.SetBool("isBlocking", true);
        else
            anim.SetBool("isBlocking", false);
              
         
         
        
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

