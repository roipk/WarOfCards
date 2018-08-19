using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Walk : MonoBehaviour {

    Animation anim;
    Rigidbody rg;
    public GameObject player;
    public GameObject enemy;
    float speedWalk = 200f;
    float speedRound;
    bool turned = false;
    // Use this for initialization
    void Start () {
        anim = player.GetComponent<Animation>();
        rg = player.GetComponent<Rigidbody>();
        speedRound = speedWalk / 2;
    }
	
	// Update is called once per frame
	void Update () {
        float x = CrossPlatformInputManager.GetAxis("Horizontal");
        float y = CrossPlatformInputManager.GetAxis("Vertical");

        Vector3 direction = enemy.transform.position - player.transform.position;

        if (direction.magnitude < 10f)
        {
            anim.Play("Attack");
        }

        if (x != 0 && y != 0)
        {
            // turned = check(y, turned);
            player.transform.Rotate(Vector3.up, x* speedRound * Time.deltaTime);
           
                rg.velocity = (player.transform.forward * speedWalk) *( y * Time.deltaTime);
        }

        if (x!=0 || y != 0)
        {
            if (!anim.IsPlaying("Attack"))
                anim.Play("Walk");
        }
        else
        {
            if(!anim.IsPlaying("Attack"))
                anim.Play("Idle");
            player.transform.Rotate(Vector3.up,0f);
            rg.velocity = (player.transform.forward * 0f);

        }


        
        
	}

}
