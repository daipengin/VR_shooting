using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ButtonType{ 
    None,
    StartButton,
    SelectGameModeButton,
    ResultButton
}

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField]
    GameMode gameMode;

    [SerializeField]
    ButtonType buttonType;

    // Start is called before the first frame update
    void Start()
    {
        transform.tag = "button";   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selected()
    {
        switch (buttonType)
        {
            case ButtonType.StartButton:
                ParaManager.instance._SceneMode = SceneMode.Play;
                break;
            case ButtonType.SelectGameModeButton:
                ParaManager.instance.Reset_date(gameMode);
                /*
                switch (gameMode)
                {
                    case GameMode.TimeAttack:
                        ParaManager.instance.targetnum = 60;
                        break;
                    case GameMode.Extermination:
                        ParaManager.instance.targetnum = 10;
                        break;
                    case GameMode.Practice:
                        ParaManager.instance.targetnum = 60;
                        break;
                    default:
                        break;
                }
                ParaManager.instance.Mode = gameMode;*/
                break;
            case ButtonType.ResultButton:
                ParaManager.instance._SceneMode = SceneMode.Select;
                ParaManager.instance.Reset_date(ParaManager.instance.Mode);
                break;
            default:
                break;
        }
    }
}
