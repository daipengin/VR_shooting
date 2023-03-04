using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ButtonType{ 
    None,
    StartButton,
    SelectGameModeButton,
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
                //Debug.Log("ÉQÅ[ÉÄäJén");
                ParaManager.instance._SceneMode = SceneMode.Play;
                break;
            case ButtonType.SelectGameModeButton:
                switch (gameMode)
                {
                    case GameMode.TimeAttack:
                        break;
                    case GameMode.Extermination:
                        break;
                    case GameMode.Practice:
                        break;
                    default:
                        break;
                }
                ParaManager.instance.Mode = gameMode;
                break;
            default:
                break;
        }
    }
}
