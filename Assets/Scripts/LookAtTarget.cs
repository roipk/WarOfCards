using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class LookAtTarget : MonoBehaviour {

   
    public GameObject target;
    public GameObject ded;
    

    Animator anim;
    //private string player = "Player";
    public float forceMult = 200;
    float rotSpeed = 0.8f;
    float speed = 3f;
    Vector3 direction;
    // bool test = false;
    //int currentEnemy = 0 ;
    //float distance = 0;

    // Use this for initialization

    void Start () {
        if (this.gameObject.tag == "Player")
            target = GameObject.Find("Enemy");
          else
            target = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        Vector3 direction = new Vector3(0, 0, 0);
        //anim.SetBool("Idle", true);

    }
	

    // Update is called once per frame
    void Update () {

       /* Debug.Log(Quaternion.LookRotation(direction).x);
        // Transform targetPosition = target.GetComponent<Transform>();

        //float z = Math.Abs(transform.rotation.z - target.transform.rotation.z);


        float x = transform.rotation.x - target.transform.rotation.x;
    
        direction.y = Math.Abs(transform.rotation.y - target.transform.rotation.y); ;   
        direction.x = (float)Math.Sqrt((float)Math.Pow(x,2)-(float)Math.Pow(direction.y,2));
        direction.z = Math.Abs(transform.rotation.z - target.transform.rotation.z);



        //כאן למטה זה מעביר אותו מצב סיבוב ממה שהיה למצב הסתכלות החדש המצב החדש צריך להיות אחרי ההזזה
        this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),rotSpeed * Time.deltaTime);
        this.transform.Translate(0, 0, 0);
        
        */




       // Vector3 direction = target.transform.position - transform.position;


        //if(direction.y>0.1)
         


      //  Vector3 worldUp = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        transform.LookAt(targetPosition);
        

        // this.transform.Translate(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
        //distance = Vector3.Distance(transform.position, target.transform.position);
        /* if (direction.magnitude < 0.5f)
         {
             anim.SetBool("RoundKick", true);
             anim.SetBool("Walk", false);
         }*/
        //  transform.LookAt(new Vector3(0, 0, 0));
        //    transform.position = transform.forward * Time.deltaTime * forceMult;


    }
}
