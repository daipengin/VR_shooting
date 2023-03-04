using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float Move_Speed;
    public float HP;

    // Start is called before the first frame update
    void Start()
    {
        transform.tag = "enemy";
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(target, transform.up);
        Vector3 vec = (target.position-transform.position);
        vec.Normalize();
        transform.Translate(vec * Move_Speed*Time.deltaTime);
    }
}
