using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moves : MonoBehaviour {
    public GameObject target;
    Animator anim;

    public Transform lookTarget;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();        
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 nearTarget = target.transform.position - transform.position;
        var canAttack = Mathf.Sqrt(Mathf.Pow(nearTarget.x,2) + Mathf.Pow(nearTarget.y,2) + Mathf.Pow(nearTarget.z,2));
       // transform.LookAt(lookTarget,Vector3.zero);

        if (canAttack < 10f)
            anim.Play("Attack");
        else
            anim.Play("Idle");
	}
}
