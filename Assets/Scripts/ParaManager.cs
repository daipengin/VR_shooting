using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameMode
{
    None,
    ScoreAttack,
    Extermination,
    Practice,
}

public enum SceneMode
{
    None,
    Select,
    Play,
    Result
}

public enum Difficulty
{
    Easy,
    Normal,
    Hard,
    Expert
}

public struct EnemyStatus{
    public float MaxHP;
    public float Speed;
    public float Warp_CT;
    public int GetScore;
    public int LostScore;
    public EnemyType type;

}

public class ParaManager : MonoBehaviour
{
    [SerializeField]
    public bool mousemode = true;
    [SerializeField]
    public float selectTime;
    [SerializeField]
    public float shot_CT;
    [SerializeField]
    public Vector2 camera_rotate_speeed;



    static public ParaManager instance;

    public GameMode Mode = GameMode.ScoreAttack;
    public SceneMode _SceneMode = SceneMode.None;
    public Difficulty Diff = Difficulty.Easy;

    public float selectberFillAmount = 0;
    public int killcount;
    public int damagecount;
    public int Score;
    public float targetnum;

    public float PlayingTime;


    public float Enemy_Generate_Time;

    public EnemyStatus Enemy_status_pre;
    public EnemyStatus Meteorite_status_pre;

  




    private void Awake()
    {
        Mode = GameMode.ScoreAttack;
        if (instance == null) instance = this;
        else Destroy(gameObject);
#if UNITY_EDITOR
        mousemode = true;
#else
        mousemode = false;
#endif

        //Reset_GameMode(ParaManager.instance.Mode);
        Reset_Difficulty(ParaManager.instance.Diff);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Reset_GameMode(GameMode mode)
    {
        killcount = 0;
        selectberFillAmount = 0;
        switch (mode)
        {
            case GameMode.ScoreAttack:
                targetnum = 60;
                break;
            case GameMode.Extermination:
                targetnum = 10;
                break;
            case GameMode.Practice:
                targetnum = 60;
                break;
            default:
                break;
        }
        Mode = mode;       
        //_SceneMode = SceneMode.Select;
        
    } 

    public void Reset_Difficulty(Difficulty diff)
    {
        killcount = 0;
        selectberFillAmount = 0;
        targetnum = 60;
        Score = 0;
        damagecount = 0;
        switch (diff)
        {
            case Difficulty.Easy:

                Enemy_Generate_Time = 5;
                Enemy_status_pre = new EnemyStatus
                {
                    Speed = 0.7f,
                    MaxHP = 3,
                    Warp_CT = 10,
                    GetScore = 10,
                    LostScore = 5,
                    type = EnemyType.warp
                };
                Meteorite_status_pre = new EnemyStatus
                {
                    Speed = 0.7f,
                    MaxHP = 3,
                    Warp_CT = 10,
                    GetScore = 10,
                    LostScore = 5,
                    type = EnemyType.straight
                };

                break;
            case Difficulty.Normal:
                Enemy_Generate_Time = 3;
                Enemy_status_pre = new EnemyStatus
                {
                    Speed = 1f,
                    MaxHP = 5,
                    Warp_CT = 5,
                    GetScore = 50,
                    LostScore = 40,
                    type = EnemyType.warp
                };
                Meteorite_status_pre = new EnemyStatus
                {
                    Speed = 1.1f,
                    MaxHP = 6,
                    Warp_CT = 0,
                    GetScore = 50,
                    LostScore = 20,
                    type = EnemyType.straight
                };

                break;
            case Difficulty.Hard:
                Enemy_Generate_Time = 5;
                Enemy_status_pre = new EnemyStatus
                {
                    Speed = 1.5f,
                    MaxHP = 10,
                    Warp_CT = 3,
                    GetScore = 150,
                    LostScore = 200,
                    type = EnemyType.warp
                };
                Meteorite_status_pre = new EnemyStatus
                {
                    Speed = 2f,
                    MaxHP = 15,
                    Warp_CT = 0,
                    GetScore = 150,
                    LostScore = 100,
                    type = EnemyType.straight
                };

                break;
            case Difficulty.Expert:
                break;
            default:
                break;
        }
        Diff = diff;
        
    }



    public void GoNextScene()
    {
        int num = SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % num);
    }
}
