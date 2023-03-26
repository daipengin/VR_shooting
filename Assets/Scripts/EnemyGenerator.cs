using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject Enemy_prefab;

    [SerializeField]
    GameObject meteorite_prefab;

    [SerializeField]
    float Min_range;
    [SerializeField]
    float Max_range;

    [SerializeField]
    float GenCT;

    [SerializeField]
    Transform target;

    [SerializeField]
    float Gen_Ypos;
    float time;

    List<GameObject> enemylist;

    // Start is called before the first frame update
    void Start()
    {
        GenCT = ParaManager.instance.Enemy_Generate_Time;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (ParaManager.instance._SceneMode)
        {
            case SceneMode.None:
                break;
            case SceneMode.Select:
                time = 0;
                break;
            case SceneMode.Play:
                time += Time.deltaTime;
                if (time > GenCT)
                {
                    GenerateEnemy();
                    GenerateMeteorite();
                    time = 0;
                }

                break;
            case SceneMode.Result:
                
                break;
            default:
                break;
        }
        
    }

    public void GenerateEnemy(bool isRandom = true)
    {
        GameObject enemy = Instantiate(Enemy_prefab, transform);
        float range = Random.Range(Min_range, Max_range);
        float rad_range = Random.Range(0f, 2f * Mathf.PI);
        Vector3 pos;
        if(isRandom) pos = new Vector3(range * Mathf.Sin(rad_range), Gen_Ypos, range * Mathf.Cos(rad_range));
        else pos = transform.position;
        enemy.transform.position = pos;
        Enemy script = enemy.GetComponent<Enemy>();
        script.target = target;
        script.ES = ParaManager.instance.Enemy_status_pre;
    }

    public void GenerateMeteorite(bool isRandom = true)
    {
        GameObject meteorite = Instantiate(meteorite_prefab, transform);
        float range = Random.Range(Min_range, Max_range);
        float rad_range = Random.Range(0f, 2f * Mathf.PI);
        Vector3 pos;
        if(isRandom) pos = new Vector3(range * Mathf.Sin(rad_range), Gen_Ypos, range * Mathf.Cos(rad_range));
        else pos = transform.position;
        meteorite.transform.position = pos;
        Enemy script = meteorite.GetComponent<Enemy>();
        script.target = target;
        script .ES = ParaManager.instance.Meteorite_status_pre;

    }


}
