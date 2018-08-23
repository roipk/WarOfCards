using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Hit : MonoBehaviour {
    public Slider hp;
    Animator anim;
    public string opponent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != opponent)
            return;
            hp.value -= 4f;
        if (hp.value <= 0)
            anim.SetBool("isDead", true);
        //Debug.Log("Hit");
    }


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
