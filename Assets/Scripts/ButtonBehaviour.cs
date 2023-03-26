using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ButtonType{ 
    None,
    StartButton,
    SelectGameModeButton,
    SelectGameDifficulty,
    ResultButton
}

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField]
    GameMode gameMode;

    [SerializeField]
    Difficulty difficulty;

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
                ParaManager.instance.Reset_GameMode(gameMode);
                /*
                switch (gameMode)
                {
                    case GameMode.ScoreAttack:
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
                //ParaManager.instance.Reset_GameMode(ParaManager.instance.Mode);
                ParaManager.instance.Reset_Difficulty(ParaManager.instance.Diff);
                break;
            case ButtonType.SelectGameDifficulty:
                ParaManager.instance.Reset_Difficulty(difficulty);
                break;
            default:
                break;
        }
    }
}
