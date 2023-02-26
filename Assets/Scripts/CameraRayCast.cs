using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraRayCast : MonoBehaviour
{

    float timer = 0;

    [SerializeField]
    float selectTime;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Select();
    }

    private void Select()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {

            if(hit.collider.tag == "button")
            {
                timer += Time.deltaTime;
                ParaManager.instance.selectberFillAmount = timer / selectTime;
                if (timer > selectTime)
                {
                    ParaManager.instance.selectberFillAmount = 0;
                    ButtonBehaviour script = hit.transform.GetComponent<ButtonBehaviour>();
                    script.selected();
                }
            }
            
        }
        else
        {
            timer = 0;
            ParaManager.instance.selectberFillAmount = timer / selectTime;
        }
    }

}
