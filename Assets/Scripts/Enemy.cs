using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum EnemyType
{
    straight,
    warp
}
public class Enemy : MonoBehaviour
{
    public EnemyStatus ES;
    public Transform target;

    [SerializeField]
    GameObject warp_Particle;
    [SerializeField]
    GameObject Destroy_particle;
    [SerializeField]
    AudioClip Destroy_Clip;
    [SerializeField]
    AudioClip warp_Clip;

    AudioSource AS;



    float Move_Speed;
    float MaxHP;
    EnemyType enemyType;
    float Warp_CT;
    int GetScore;
    int LostScore;
    float HP;
    void SetStatus()
    {
        Move_Speed = ES.Speed;
        MaxHP = ES.MaxHP;
        enemyType = ES.type;
        Warp_CT = ES.Warp_CT;
        GetScore = ES.GetScore;
        LostScore = ES.LostScore;
    }



    [SerializeField]
    Image _HPbar;

    [SerializeField]
    GameObject _Canvas;

    [SerializeField]
    GameObject enemy_Mesh;


    // Start is called before the first frame update
    void Start()
    {
        SetStatus();
        _Canvas = transform.Find("Canvas").gameObject;
        _HPbar = _Canvas.transform.Find("HPbar").GetComponent<Image>();
        enemy_Mesh = transform.Find("Mesh").gameObject;

        AS = GetComponent<AudioSource>();


        transform.tag = "enemy";
        HP = MaxHP;
        switch (enemyType)
        {
            case EnemyType.straight:
                break;
            case EnemyType.warp:
                StartCoroutine(WarpMove());
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(target, transform.up);
        Vector3 vec = (target.position-transform.position);
        vec.Normalize();
        transform.Translate(vec * Move_Speed*Time.deltaTime);
        _HPbar.fillAmount = HP / MaxHP;
        _Canvas.transform.LookAt(target);
        enemy_Mesh.transform.LookAt(target);
        


        if(ParaManager.instance._SceneMode != SceneMode.Play) Destroy(gameObject);
    }
    
    IEnumerator WarpMove()
    {
        while (true)
        {
            float range = (target.position - transform.position).magnitude;
            float rad_range = Random.Range(0f, 2f * Mathf.PI);
            Vector3 pos;
            pos = new Vector3(range * Mathf.Sin(rad_range), transform.position.y, range * Mathf.Cos(rad_range));
            GameObject obj = Instantiate(warp_Particle);
            obj.transform.position = transform.position;
            Destroy(obj,1f);
            AS.PlayOneShot(warp_Clip);
            transform.position = pos;
            yield return new WaitForSeconds(Warp_CT);
        }

    }


    public void GetDamege(float damege)
    {
        HP -= damege;
        if(HP <= 0)
        {
            ParaManager.instance.killcount++;
            ParaManager.instance.Score += GetScore;
            GameObject obj = Instantiate(Destroy_particle);
            obj.transform.position = transform.position;
            GameObject sound = Instantiate(new GameObject());
            sound.transform.position = transform.position;
            AudioSource sas = sound.AddComponent<AudioSource>();
            sas.PlayOneShot(Destroy_Clip);
            Destroy(sound,4);
            Destroy(obj, 1f);
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


            ParaManager.instance.damagecount++;
            ParaManager.instance.Score -= LostScore;
            Destroy(gameObject);
        }
    }
}
