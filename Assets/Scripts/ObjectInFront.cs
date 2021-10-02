using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectInFront : MonoBehaviour
{

    Image image; 

    // Start is called before the first frame update
    void Start()
    {
       image = this.gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
           try
        {

            RaycastHit hit;
            Ray ray = new Ray(this.gameObject.transform.position, transform.forward);


            if (Physics.Raycast(ray, out hit, 100))
            {

                string tagName = hit.collider.gameObject.tag;
                
                if("Player".Equals(tagName)){
                   image.CrossFadeAlpha(0f,0.05f,true);

                }else{
                    image.CrossFadeAlpha(255f,0.5f,true);
                }
                

            }
          



            Debug.DrawLine(ray.direction, hit.point, Color.red);
        }
        catch
        {

        }
    }
}
