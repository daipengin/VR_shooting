using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField]
    float m_Speed;
    [SerializeField]
    float LifeTime;
    [SerializeField]
    float Long;
    [SerializeField]
    public float bulletDamede;


    public Vector3 target;
    TrailRenderer tr;
    // Start is called before the first frame update
    void Start()
    {
        transform.tag = "bullet";
        Destroy(gameObject,LifeTime);
        tr = GetComponent<TrailRenderer>();
        tr.time = ParaManager.instance.shot_CT * Long;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vec = (target - transform.position);
        vec.Normalize();
        transform.Translate(vec*m_Speed*Time.deltaTime);
    }
}
