using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameMode
{
    None,
    TimeAttack,
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

    public GameMode Mode = GameMode.Extermination;
    public SceneMode _SceneMode = SceneMode.None;

    public float selectberFillAmount = 0;
    public int killcount;
    public float targetnum;

    public float PlayingTime;

    private void Awake()
    {
        if(instance == null) instance = this;
        else Destroy(gameObject);
#if UNITY_EDITOR
        mousemode = true;
#else
        mousemode = false;
#endif
        Reset_date(ParaManager.instance.Mode);
        

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Reset_date(GameMode mode)
    {
        killcount = 0;
        selectberFillAmount = 0;
        switch (mode)
        {
            case GameMode.TimeAttack:
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



    public void GoNextScene()
    {
        int num = SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % num);
    }
}
