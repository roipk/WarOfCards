using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class controller1 : MonoBehaviour {

    static Animator anim;
    public JoyButton joyButtonAttack;
    public JoyButton joyButtonBlock;
    public float speed = 2.0f;
    public float rotationSpeed = 60.0f;

    void Start () {
        anim = GetComponent<Animator>();
      
	}
	
	// Update is called once per frame
	void Update () {

      

        float translation = CrossPlatformInputManager.GetAxis("Vertical") * speed;
        float rotation = CrossPlatformInputManager.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
        
        if (joyButtonAttack.Pressed)
            anim.SetBool("isAttack", true);
        
        else
            anim.SetBool("isAttack", false);

        if (joyButtonBlock.Pressed)
            anim.SetBool("isBlocking", true);
        else
            anim.SetBool("isBlocking", false);

        if(translation!=0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }


    }
}
