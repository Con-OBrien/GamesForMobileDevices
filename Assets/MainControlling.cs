using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControlling : MonoBehaviour
{
    private Touch touch;
    private float speedModifier;
    public Moveable_Object[] objects;
    public Moveable_Object object_move;
    GameObject sphere, cube, cylinder;
    public Moveable_Object selectedObject = null ;
    bool selected_option = false;
    Moveable_Object object_sphere;

    void Start()
    {
        speedModifier = 0.01f;
        sphere = GameObject.Find("Sphere");
        cube = GameObject.Find("Cube");
        cylinder = GameObject.Find("Cylinder");
        object_sphere = sphere.GetComponent<Moveable_Object>();
        Moveable_Object object_cube = cube.GetComponent<Moveable_Object>();
        Moveable_Object object_cylinder = cylinder.GetComponent<Moveable_Object>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray raycast = Camera.main.ScreenPointToRay(touch.position);
        RaycastHit raycastHit;

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
           

            if (touch.phase == TouchPhase.Began) { 
                if (Physics.Raycast(raycast, out raycastHit))
                {
                    Moveable_Object object_hit = raycastHit.transform.GetComponent<Moveable_Object>();
                    SelectObject(object_hit);                        
                }
                else
                {
                    selectedObject.deselect();
                }
               
            }

   
        }
        if (Input.touchCount == 2)
        {
            if(Physics.Raycast(raycast, out raycastHit))
            {

               
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            selectedObject.transform.localScale = new Vector3(deltaMagnitudeDiff, deltaMagnitudeDiff, deltaMagnitudeDiff);
            }
        }
    }
    void SelectObject(Moveable_Object obj) {
        if(selectedObject != null) {
            if (obj == selectedObject)
                return;

            obj.select();

            ClearSelection();
        }

        selectedObject = obj;
    }

    void ClearSelection()
    {
        selectedObject.deselect();
        selectedObject = null;
        
    }
}
