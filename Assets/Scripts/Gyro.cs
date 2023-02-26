using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gyro : MonoBehaviour
{
    Transform m_transform;

    Quaternion currentGyro;

    bool mousemode;

    [SerializeField]
    public GameObject VRCanvas, MouseCanvas;

    

    readonly Quaternion _BASE_ROTATION = Quaternion.Euler(90, 0, 90);

 

    // Start is called before the first frame update
    void Start()
    {
        mousemode = ParaManager.instance.mousemode;
        

        if (mousemode)
        {
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            Input.gyro.enabled = true;
        }
        m_transform = transform;
        Screen.orientation = ScreenOrientation.Portrait;
    }

    float xRotation = 0f;
    // Update is called once per frame
    void Update()
    {

        if (mousemode)
        {
            float mouseX = Input.GetAxis("Mouse X") * 300 * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * 300 * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.parent.Rotate(Vector3.up * mouseX);
        }
        else
        {
            Quaternion gyro = Input.gyro.attitude;
            m_transform.localRotation = _BASE_ROTATION * (new Quaternion(-gyro.x, -gyro.y, gyro.z, gyro.w));
            if (Input.GetMouseButtonDown(1))
            {
                SceneManager.LoadScene("Title");
            }
        }

    }  
}
