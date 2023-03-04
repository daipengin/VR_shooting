using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraRayCast : MonoBehaviour
{

    float timer = 0;
    Collider selected = null;
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
                if(selected != hit.collider)
                {
                    timer += Time.deltaTime;
                    ParaManager.instance.selectberFillAmount = timer / ParaManager.instance.selectTime;
                    if (timer > ParaManager.instance.selectTime)
                    {
                        ParaManager.instance.selectberFillAmount = 0;
                        ButtonBehaviour script = hit.transform.GetComponent<ButtonBehaviour>();
                        script.selected();
                        selected = hit.collider;
                        timer = 0;
                        ParaManager.instance.selectberFillAmount = timer / ParaManager.instance.selectTime;
                    }
                }
                
            }
            
        }
        else
        {
            selected = null;
            timer = 0;
            ParaManager.instance.selectberFillAmount = timer / ParaManager.instance.selectTime;
        }
    }

}
