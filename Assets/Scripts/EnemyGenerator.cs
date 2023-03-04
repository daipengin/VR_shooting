using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject Enemy_prefab;

    [SerializeField]
    float Min_range;
    [SerializeField]
    float Max_range;

    [SerializeField]
    float GenCT;

    [SerializeField]
    Transform target;

    float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > GenCT)
        {
            GenerateEnemy();
            time = 0;
        }
    }

    public void GenerateEnemy()
    {
        GameObject enemy = Instantiate(Enemy_prefab, transform);
        float range = Random.Range(Min_range, Max_range);
        enemy.transform.rotation = Quaternion.Euler(0, Random.value *360, 0);
        enemy.transform.Translate(transform.forward * range);
        Enemy script = enemy.GetComponent<Enemy>();
        script.target = target;
    }
}
