using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Hit : MonoBehaviour {
    public GameObject hp;
    private Animator anim;
    bool playingAnim = false;
   
    private void OnTriggerEnter(Collider other)
    {
        
        Animator enemyAnim = other.GetComponentInParent<Animator>();
        //Debug.Log(this.gameObject.tag + " attack  = " + !enemyAnim.GetBool("isAttack"));

        if (other.gameObject.tag != this.gameObject.tag && !enemyAnim.GetBool("isAttack"))
            return;

        anim.SetBool("isDamaged", true);
        anim.SetBool("isBack", false);
        playingAnim = true;
        hp.transform.localScale-= new Vector3(0f,0.04f,0f);
        if (hp.transform.localScale.y <= 0)
        {
            hp.transform.localScale = Vector3.zero;
            anim.SetBool("isDead", true);
        }
    
    }

    private void OnTriggerExit(Collider other)
    {
        Animator enemyAnim = other.GetComponentInParent<Animator>();
        

        if (!enemyAnim.GetBool("isAttack"))
        {

            anim.SetBool("isBack", true);
            anim.SetBool("isAttack", false);
            anim.SetBool("isWalking", false);
            anim.SetBool("isIdle", false);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.1f);
        }
    }


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();

   }
	
	// Update is called once per frame
	void Update () {
       // Debug.Log("enemy forward = " + transform.forward);
        if (anim.GetBool("isDamaged") && !playingAnim)
            {
                anim.SetBool("isDamaged", false);
            }
        else if (anim.GetBool("isDamaged"))
            playingAnim = false;


    }
}
