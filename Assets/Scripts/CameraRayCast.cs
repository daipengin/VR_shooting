using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraRayCast : MonoBehaviour
{

    float timer = 0;
    Collider selected = null;
    [SerializeField]
    GameObject bullet;
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
            switch (hit.collider.tag)
            {
                case "button":
                    if (selected != hit.collider)
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
                        }
                    }
                    break;
                case "enemy":
                    timer += Time.deltaTime;
                    ParaManager.instance.selectberFillAmount = timer / ParaManager.instance.shot_CT;
                    if (timer > ParaManager.instance.shot_CT)
                    {
                        ParaManager.instance.selectberFillAmount = 0;
                        Enemy script = hit.transform.GetComponent<Enemy>();
                        timer = 0;
                        Vector3 pos = transform.position;
                        if (ParaManager.instance.mousemode) pos.y -= 0.5f;
                        else pos.x -= 0.5f; 
                        GameObject obj = Instantiate(bullet,pos,Quaternion.identity);
                        obj.transform.GetComponent<bullet>().target = hit.point;
                    }
                    break;
                default:
                    break;
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
