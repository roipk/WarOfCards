using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour {

    public Slider hp;
    //public GameObject player;
    //public GameObject stamina;
    public Slider stamina;
    Animator anim;
    //Vector2 st;
    //bool isAnimationPlay = false;
    //bool isAnimationEnd = true;
    float damag;
    bool death = false;
    float x = 1f;
    



    private void OnTriggerEnter(Collider other)
    {
        Animator enemyAnim = other.GetComponentInParent<Animator>();
        //xDebug.Log(this.gameObject.tag + " attack  = "+ !enemyAnim.GetBool("isAttack"));
        if (other.gameObject.tag != this.gameObject.tag && !enemyAnim.GetBool("isAttack"))
            return;

        hp.value -= 10f;
        anim.SetBool("isDamaged", true);
        if (hp.value <= 0)
        {
            anim.SetBool("isDead", true);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        Animator enemyAnim = other.GetComponentInParent<Animator>();
        if (!enemyAnim.GetBool("isAttack"))
        {

            anim.SetBool("isDamaged", false);
            // anim.SetBool("isBack", true);
            anim.SetBool("isAttack", false);
            anim.SetBool("isWalking", false);
            anim.SetBool("isIdle", false);
            //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.1f);
        }
        if (!enemyAnim.GetBool("isDead"))
        {
            anim.SetBool("isWin", false);
            anim.SetBool("isDamaged", false);
            anim.SetBool("isBack", false);
            anim.SetBool("isAttack", false);
            anim.SetBool("isWalking", false);
            anim.SetBool("isIdle", false);
        }


    }




        // Use this for initialization
        void Start()
    {
        anim = GetComponent<Animator>();
       // enemyAnim = enemy.GetComponent<Animator>();
        //st = stamina.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        


        /*
        //st = stamina.transform.localScale;
        if (!isAnimationPlay && (anim.IsPlaying("Block") || anim.IsPlaying("Attack")))// || anim.IsPlaying("Death"))
        {
            isAnimationPlay = true;
            if (stamina.value > 5)
            {
                if (anim.IsPlaying("Attack"))
                    stamina.value -= 0.4f * Time.deltaTime;
                else if (anim.IsPlaying("Block"))
                    stamina.value -= 1f * Time.deltaTime;
                else
                {
                    stamina.value -= 0.04f;
                    death = true;
                }
            }
            //Debug.Log(st.x);
            stamina.transform.localScale = st;
        }
        
        if (isAnimationPlay && (anim.IsPlaying("Block") || anim.IsPlaying("Attack") ))//|| anim.IsPlaying("Death")))
        {
            if (stamina.value > 5f)
            {
                if (anim.IsPlaying("Attack"))
                    stamina.value -= 0.4f * Time.deltaTime;
                else if (anim.IsPlaying("Block"))
                    stamina.value -= 1f * Time.deltaTime;
                else
                {
                    st.x -= 0.04f;
                    
                }
            }
            //stamina.transform.localScale = st;

        }

        if (isAnimationPlay && (!anim.IsPlaying("Block") || !anim.IsPlaying("Attack")  ))// || anim.IsPlaying("Death")))
        {
            isAnimationPlay = false;
        }

        if (!isAnimationPlay && (!anim.IsPlaying("Block") || !anim.IsPlaying("Attack") ))//|| !anim.IsPlaying("Death")))
        {
            if (death)
                Destroy(gameObject);

            if (stamina.value < 5)
                stamina.value += 0.2f * Time.deltaTime;
           // stamina.transform.localScale = st;
        }
/*
        if(st.x<0.05)
        {
            anim.Play("Death");
        }*/
    }
}
