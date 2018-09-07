using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerEnemy : MonoBehaviour {
    static Animator anim;
    public Transform player;
    public Slider hp;
    Rigidbody rb;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        if (hp.value <= 0)
            return;

      //  Vector3 direction = player.position - this.transform.position;


       // Debug.Log("direct = "+direction.magnitude);
        //Debug.Log("angle = "+angle);
       

        Vector3 relativePos = (player.position + new Vector3(0, transform.position.y - player.position.y, 0))-transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        Quaternion corrent = transform.localRotation;
        transform.localRotation = Quaternion.Slerp(corrent, rotation, Time.deltaTime);
        
        //transform.localRotation.SetFromToRotation(relativePos,Vector3.zero);

        float angle = Vector3.Angle(relativePos, this.transform.forward);

        
        if (Vector3.Distance(player.position, this.transform.position) < 20f && angle < 30f)
        {
            //direction.x = 0f;
            //direction.z = 0f;
            // this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            //transform.rotation = Quaternion.LookRotation(direction);


            if (relativePos.magnitude > 8f)
            {
                this.transform.Translate(0f, 0f, 0.05f);
                anim.SetBool("isWalking", true);
            }
            else
            {
                anim.SetBool("isAttack", true);
            }
        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isAttack", false);
            anim.SetBool("isWalking", false);
        }
    }

}
