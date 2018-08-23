using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour {

    public RectTransform  hp;
    //public GameObject player;
    //public GameObject stamina;
    public GameObject stamina;
    Animation anim;
    Vector2 st;
    bool isAnimationPlay = false;
    bool isAnimationEnd = true;
    float damag;
    bool death = false;
    float x = 1f;





    private void OnTriggerEnter(Collider other)
    {
        x -= 0.01f;

        hp.localScale = new Vector3(x, 1f, 1f);
    } 






    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animation>();
        st = stamina.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {


        //st = stamina.transform.localScale;
        if (!isAnimationPlay && (anim.IsPlaying("Skill") || anim.IsPlaying("Attack")) || anim.IsPlaying("Death"))
        {
            isAnimationPlay = true;
            if (st.x > 0.01)
            {
                if (anim.IsPlaying("Attack"))
                    st.x -= 0.04f * Time.deltaTime;
                else if (anim.IsPlaying("Skill"))
                    st.x -= 0.2f * Time.deltaTime;
                else
                {
                    st.x -= 0.04f;
                    death = true;
                }
            }
            //Debug.Log(st.x);
            stamina.transform.localScale = st;
        }

        if (isAnimationPlay && (anim.IsPlaying("Skill") || anim.IsPlaying("Attack") || anim.IsPlaying("Death")))
        {
            if (st.x > 0.01)
            {
                if (anim.IsPlaying("Attack"))
                    st.x -= 0.04f * Time.deltaTime;
                else if (anim.IsPlaying("Skill"))
                    st.x -= 0.2f * Time.deltaTime;
                else
                {
                    st.x -= 0.04f;
                    
                }
            }
            stamina.transform.localScale = st;

        }

        if (isAnimationPlay && (!anim.IsPlaying("Skill") || !anim.IsPlaying("Attack") || anim.IsPlaying("Death")))
        {
            isAnimationPlay = false;
        }

        if (!isAnimationPlay && (!anim.IsPlaying("Skill") || !anim.IsPlaying("Attack") || !anim.IsPlaying("Death")))
        {
            if (death)
                Destroy(gameObject);

            if (st.x < 1)
                st.x += 0.02f * Time.deltaTime;
            stamina.transform.localScale = st;
        }
/*
        if(st.x<0.05)
        {
            anim.Play("Death");
        }*/
    }
}
