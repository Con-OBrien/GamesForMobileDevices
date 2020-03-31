using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable_Object : MonoBehaviour
{
    private Touch touch;
    private float speedModifier;
    Renderer my_renderer;
    public bool selected = false;
    GameObject sphere, cube, cylinder;
    void Start()
    {
        speedModifier = 0.01f;
        sphere = GameObject.Find("Sphere");
        cube = GameObject.Find("Cube");
        cylinder = GameObject.Find("Cylinder");
        my_renderer = GetComponent<Renderer>();

    }
    void Update()
    {
        Ray raycast = Camera.main.ScreenPointToRay(touch.position);
        RaycastHit raycastHit;

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                if (Physics.Raycast(raycast, out raycastHit))
                {

                    if (raycastHit.collider.name == "Sphere")
                    {
                        
                        sphere.transform.position = new Vector3(
                        sphere.transform.position.x + touch.deltaPosition.x * speedModifier,
                        sphere.transform.position.y, sphere.transform.position.z + touch.deltaPosition.y * speedModifier);
                    }
                    else if(raycastHit.collider.name == "Cube")
                    {
                       cube.transform.position = new Vector3(
                       cube.transform.position.x + touch.deltaPosition.x * speedModifier,
                       cube.transform.position.y, cube.transform.position.z + touch.deltaPosition.y * speedModifier);
                    }
                    else if(raycastHit.collider.name == "Cylinder")
                    {
                        cylinder.transform.position = new Vector3(
                       cylinder.transform.position.x + touch.deltaPosition.x * speedModifier,
                       cylinder.transform.position.y, cylinder.transform.position.z + touch.deltaPosition.y * speedModifier);
                    }
                }
            }

            
            if (touch.phase == TouchPhase.Began)
            {
                if (Physics.Raycast(raycast, out raycastHit))
                {
                
                    if (raycastHit.collider.name == "Sphere")
                    {
                        Debug.Log("Name message - yes!");

                    }
                }
            }
        }

    }
    internal void select()
    {
        my_renderer.material.color = Color.blue;

    }
    internal void deselect()
    {
        my_renderer.material.color = Color.red;
    }
}
        
