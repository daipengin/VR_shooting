using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    public GameObject VRCanvas, MouseCanvas;

    bool mousemode;

    Image selectber;
    Text currentModeText;

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
    }

    // Update is called once per frame
    void Update()
    {
        selectber.fillAmount = ParaManager.instance.selectberFillAmount;
    }
}
