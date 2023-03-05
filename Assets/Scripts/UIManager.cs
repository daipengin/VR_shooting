using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    public GameObject VRCanvas, MouseCanvas;
    [SerializeField]
    GameObject WorldCanvas;
    [SerializeField]
    GameObject ResultCanvas;

    bool mousemode;

    Image selectber;
    Text currentModeText;
    Text Playing_infoText;
    Text ResultText;

    GameObject UseUI;
    // Start is called before the first frame update
    void Start()
    {
        mousemode = ParaManager.instance.mousemode;

        if (mousemode)
        {
            VRCanvas.SetActive(false);
            MouseCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            UseUI = MouseCanvas;
        }
        else
        {
            VRCanvas.SetActive(true);
            MouseCanvas.SetActive(false);
            Input.gyro.enabled = true;
            UseUI = VRCanvas;

        }

        selectber = UseUI.transform.GetChild(1).gameObject.GetComponent<Image>();
        currentModeText = UseUI.transform.GetChild(2).gameObject.GetComponent<Text>();
        Playing_infoText = UseUI.transform.GetChild(3).gameObject.GetComponent<Text>();
        ResultText = UseUI.transform.GetChild(4).gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
        selectber.fillAmount = ParaManager.instance.selectberFillAmount;

        switch (ParaManager.instance._SceneMode)
        {
            case SceneMode.None:
                break;
            case SceneMode.Select:
                currentModeText.enabled = true;
                currentModeText.text = "ëIëíÜÇÃÉQÅ[ÉÄÉÇÅ[Éh\n" + ParaManager.instance.Mode;
                WorldCanvas.SetActive(true);
                ResultCanvas.SetActive(false);
                Playing_infoText.enabled = false;
                ResultText.enabled = false;
                break;
            case SceneMode.Play:
                currentModeText.enabled = false;
                WorldCanvas.SetActive(false);
                ResultCanvas.SetActive(false);
                Playing_infoText.enabled = true;
                ResultText.enabled = false;
                switch (ParaManager.instance.Mode)
                {
                    case GameMode.TimeAttack:
                        Playing_infoText.text = ParaManager.instance.killcount + "ëÃåÇîj\nécÇË" + ParaManager.instance.targetnum.ToString("f1") + "ïb";
                        break;
                    case GameMode.Extermination:
                        Playing_infoText.text = ParaManager.instance.killcount + "ëÃåÇîj\nécÇË" + ParaManager.instance.targetnum.ToString("f0") + "ëÃ";
                        break;
                    case GameMode.Practice:
                        Playing_infoText.text = ParaManager.instance.killcount + "ëÃåÇîj\nécÇË" + ParaManager.instance.targetnum.ToString("f1") +"ïb";
                        break;
                    default:
                        break;
                }

                break;
            case SceneMode.Result:
                currentModeText.enabled = false;
                WorldCanvas.SetActive(false);
                ResultCanvas.SetActive(true);
                Playing_infoText.enabled = false;
                ResultText.enabled = true;
                switch (ParaManager.instance.Mode)
                {
                    case GameMode.TimeAttack:
                        ResultText.text ="åãâ \n"+ ParaManager.instance.killcount + "ëÃåÇîj";
                        break;
                    case GameMode.Extermination:
                        ResultText.text = "åãâ \n" + ParaManager.instance.PlayingTime.ToString("f1") + "ïbÇ≈åÇîj";
                        break;
                    case GameMode.Practice:
                        ResultText.text = "åãâ \n" + ParaManager.instance.killcount + "ëÃåÇîj";
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
