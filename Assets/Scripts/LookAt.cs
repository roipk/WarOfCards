using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

    string enemy = "Eliezer";
    GameObject target;
	// Use this for initialization
	void Start () {
        target = GameObject.Find(enemy);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);

        transform.LookAt(targetPosition);
	}
}
