using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameMode
{
    None,
    TimeAttack,
    Extermination,
    Practice
}

public class ParaManager : MonoBehaviour
{
    [SerializeField]
    public bool mousemode = true;



    static public ParaManager instance;

    public GameMode Mode = GameMode.None;

    public float selectberFillAmount = 0;

    private void Awake()
    {
        if(instance == null) instance = this;
        else Destroy(gameObject);
#if UNITY_EDITOR
        //mousemode = true;
#else
        //mousemode = false;
#endif
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoNextScene()
    {
        int num = SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % num);
    }
}
