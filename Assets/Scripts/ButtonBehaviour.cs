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

                break;
            default:
                break;
        }
    }
}
