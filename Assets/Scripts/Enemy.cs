using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float Move_Speed;
    float HP;
    public float MaxHP;
    [SerializeField]
    Image HPber;

    [SerializeField]
    GameObject Canvas;

    [SerializeField]
    GameObject ship;


    // Start is called before the first frame update
    void Start()
    {
        transform.tag = "enemy";
        HP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(target, transform.up);
        Vector3 vec = (target.position-transform.position);
        vec.Normalize();
        transform.Translate(vec * Move_Speed*Time.deltaTime);
        HPber.fillAmount = HP / MaxHP;
        Canvas.transform.LookAt(target);
        ship.transform.LookAt(target);


        if(ParaManager.instance._SceneMode != SceneMode.Play) Destroy(gameObject);
    }

    public void GetDamege(float damege)
    {
        HP -= damege;
        if(HP <= 0)
        {
            GameEventManager.instance.DethEnemy();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "bullet")
        {
            bullet script = other.transform.GetComponent<bullet>();
            GetDamege(script.bulletDamede);
            Destroy(script.gameObject);
        }
        if(other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
