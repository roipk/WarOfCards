using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCaracter : MonoBehaviour {


    float distans;
    Vector3 locationCaracter;
    public GameObject gameObject;

  
// Use this for initialization
void Start () {
        locationCaracter = GetComponent<Transform>().position;
    }

    // Update is called once per frame


    private void Update()
    {
       // isShow();
        
    }


    void isShow()
    {

	   
            distans = Vector3.Distance(GetComponent<Transform>().position, locationCaracter);
            if(distans  == 0)
            {
                gameObject.active = false;
            }
            else
                gameObject.active = true;
            locationCaracter = GetComponent<Transform>().position;
        
    }

}
