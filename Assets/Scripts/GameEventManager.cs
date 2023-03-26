using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    static public GameEventManager instance;


    float time;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }


    public void DethEnemy()
    {
        
        switch (ParaManager.instance.Mode)
        {
            case GameMode.ScoreAttack:
                break;
            case GameMode.Extermination:
                ParaManager.instance.targetnum--;
                break;
            case GameMode.Practice:
                break;
            default:
                break;
        }
    }

    void Timer()
    {
        switch (ParaManager.instance._SceneMode)
        {
            case SceneMode.None:
                break;
            case SceneMode.Select:
                time = ParaManager.instance.targetnum;
                break;
            case SceneMode.Play:
                
                switch (ParaManager.instance.Mode)
                {
                    case GameMode.ScoreAttack:
                        time -= Time.deltaTime;
                        ParaManager.instance.targetnum = time;
                        break;
                    case GameMode.Extermination:
                        time += Time.deltaTime;
                        ParaManager.instance.PlayingTime = time;
                        break;
                    case GameMode.Practice:
                        time -= Time.deltaTime;
                        ParaManager.instance.targetnum = time;
                        break;
                    default:
                        break;
                }

                if(ParaManager.instance.targetnum <= 0)
                {
                    ParaManager.instance._SceneMode = SceneMode.Result;
                    time = 3;
                }

                break;
            case SceneMode.Result:
                break;
            default :
                break;
        }
    }
}
