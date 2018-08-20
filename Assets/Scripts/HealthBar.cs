using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour {

    public GameObject hp;
    //public GameObject stamina;
    public GameObject stamina;
    Animation anim;
    Vector2 temp;
    bool isAnimationPlay = false;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animation>();
        temp = stamina.transform.localScale;
    }
	
	// Update is called once per frame
	void Update () {
		if(!isAnimationPlay && anim.IsPlaying("Skill"))
        {
            isAnimationPlay = true;
            temp = stamina.transform.localScale;
            if(temp.x>0.01)
                temp.x-=0.2f*Time.deltaTime;
            Debug.Log(temp.x);
            stamina.transform.localScale = temp;
        }

        if(isAnimationPlay && !anim.IsPlaying("Attak"))
        {
            isAnimationPlay = false;
            
        }

        if (!isAnimationPlay && !anim.IsPlaying("Attak"))
        {
            
            if (temp.x < 1)
                temp.x += 0.02f * Time.deltaTime;
            stamina.transform.localScale = temp;
        }

	}
}
