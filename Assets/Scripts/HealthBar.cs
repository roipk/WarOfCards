using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour {

    public RectTransform  hp;
    //public GameObject player;
    //public GameObject stamina;
    public Slider stamina;
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
        //st = stamina.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {


        //st = stamina.transform.localScale;
        if (!isAnimationPlay && (anim.IsPlaying("Skill") || anim.IsPlaying("Attack")) || anim.IsPlaying("Death"))
        {
            isAnimationPlay = true;
            if (stamina.value > 5)
            {
                if (anim.IsPlaying("Attack"))
                    stamina.value -= 0.4f * Time.deltaTime;
                else if (anim.IsPlaying("Skill"))
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

        if (isAnimationPlay && (anim.IsPlaying("Skill") || anim.IsPlaying("Attack") || anim.IsPlaying("Death")))
        {
            if (stamina.value > 5f)
            {
                if (anim.IsPlaying("Attack"))
                    stamina.value -= 0.4f * Time.deltaTime;
                else if (anim.IsPlaying("Skill"))
                    stamina.value -= 1f * Time.deltaTime;
                else
                {
                    st.x -= 0.04f;
                    
                }
            }
            //stamina.transform.localScale = st;

        }

        if (isAnimationPlay && (!anim.IsPlaying("Skill") || !anim.IsPlaying("Attack") || anim.IsPlaying("Death")))
        {
            isAnimationPlay = false;
        }

        if (!isAnimationPlay && (!anim.IsPlaying("Skill") || !anim.IsPlaying("Attack") || !anim.IsPlaying("Death")))
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
