using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour {

    public GameObject hp;
    //public GameObject stamina;
    public GameObject stamina;
    Animation anim;
    Vector2 st;
    bool isAnimationPlay = false;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animation>();
        st = stamina.transform.localScale;
    }
	
	// Update is called once per frame
	void Update () {
        st = stamina.transform.localScale;
		if(!isAnimationPlay && (anim.IsPlaying("Skill") || anim.IsPlaying("Attack")))
        {
            isAnimationPlay = true;
            if (st.x > 0.01)
            {
                if (anim.IsPlaying("Attack"))
                    st.x -= 0.04f * Time.deltaTime;
                else
                    st.x -= 0.2f * Time.deltaTime;
            }
            //Debug.Log(st.x);
            stamina.transform.localScale = st;
        }
        if (isAnimationPlay && (anim.IsPlaying("Skill") || anim.IsPlaying("Attack")))
        {
            if (st.x > 0.01)
            {
                if (anim.IsPlaying("Attack"))
                    st.x -= 0.04f * Time.deltaTime;
                else
                    st.x -= 0.2f * Time.deltaTime;
            }
            stamina.transform.localScale = st;

        }

        if(isAnimationPlay && (!anim.IsPlaying("Skill") || !anim.IsPlaying("Attack")))
        {
            isAnimationPlay = false;
            
        }

        if (!isAnimationPlay && (!anim.IsPlaying("Skill") || !anim.IsPlaying("Attack")))
        {
            
            if (st.x < 1)
                st.x += 0.02f * Time.deltaTime;
            stamina.transform.localScale = st;
        }

	}
}
