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

    public GameMode Mode = GameMode.None;
    public SceneMode _SceneMode = SceneMode.None;

    public float selectberFillAmount = 0;
    public int killcount;
    public float targetnum;

    private void Awake()
    {
        if(instance == null) instance = this;
        else Destroy(gameObject);
#if UNITY_EDITOR
        //mousemode = true;
#else
        //mousemode = false;
#endif
        Reset_date();
        

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Reset_date()
    {
        killcount = 0;
        selectberFillAmount = 0;
        _SceneMode = SceneMode.Select;
        Mode = GameMode.Extermination;
        targetnum = 1;
    } 



    public void GoNextScene()
    {
        int num = SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % num);
    }
}
