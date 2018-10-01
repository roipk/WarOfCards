using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerEnemy : MonoBehaviour {
    static Animator anim;
    public Transform player;
    public GameObject hp;
    public float speed = 0.2f;
//    Rigidbody rb;
    //public GameObject character;
    bool attack = false;
    float counter;
    

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        //rb = GetComponent<Rigidbody>();
        counter = 0;
        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.LookRotation(player.position), Time.deltaTime);
    }
	
	// Update is called once per frame
	void Update () {
       

        
        Animator win = player.gameObject.GetComponent<Animator>();
        if (win.GetBool("isDead"))
        {

            anim.SetBool("isWin", true);
            anim.SetBool("isDamaged", false);
            anim.SetBool("isBack", false);
            anim.SetBool("isAttack", false);
            anim.SetBool("isWalking", false);
            anim.SetBool("isIdle", false);
            return;
        }
         


        if ((int)counter > 5)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            gameObject.active = false;
#pragma warning restore CS0618 // Type or member is obsolete
            return;
        }
        else if (hp.transform.localScale.y<=0)
        {
           // Debug.Log((int)counter);
            counter += 1 * Time.deltaTime;
            return;
        }
        else
        {
            Move();
        }
        
    }


    
    private void Move()
    {
        Vector3 relativePos = (player.position + new Vector3(0, transform.position.y - player.position.y, 0)) - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        Quaternion corrent = transform.localRotation;

       // float angle = Vector3.Angle(relativePos, this.transform.forward);
        transform.localRotation = Quaternion.Slerp(corrent, rotation, Time.deltaTime);

        
        anim.SetBool("isIdle", false);
        Debug.Log(transform.position);
        //Debug.Log("meter    " + Vector3.Distance(player.position, this.transform.position) + "        angle = " + angle);
        float distane = Vector3.Distance(player.position, this.transform.position);
        if (distane < 25f)
        {

           if (anim.GetBool("isBack"))
            {
               // Debug.Log("in");
                anim.SetBool("isWalking", false);
                anim.SetBool("isAttack", false);
                this.transform.Translate(0f, 0f, -1*speed);
                attack = false;
            }

           if (distane > 13f)
            {
               // Debug.Log("in distane > 13");
                this.transform.Translate(0f, 0f,speed);
                anim.SetBool("isBack", false);
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttack", false);
                attack = true;

            }
            else if (distane >= 6f && !anim.GetBool("isBack"))
            {
                attack = true;

                //Debug.Log("in distane > 8");
                //Debug.Log("in walke meter    " + relativePos.magnitude);
                this.transform.Translate(0f, 0f, speed);
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttack", false);
               /* anim.SetBool("isIdle", false);
                anim.SetBool("isBack", false);
                    attack = false;*/
            }
            else
            {
                if(attack)
                anim.SetBool("isAttack", true);
                //attack = true;
            }
                

        }
            

        
        else
        {
            //Debug.Log("in");
            anim.SetBool("isIdle", true);
            anim.SetBool("isAttack", false);
            anim.SetBool("isWalking", false);
        }
    }


}
