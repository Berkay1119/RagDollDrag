using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DragRagDoll : MonoBehaviour
{
    float speed = 50f;
    GameObject selected;
    float vector_x;
    float vector_y;
    int layerMask = 1 << 6;

    void Update()
    {
        if (Input.touchCount!=0 && selected==null)
        {
            Selected();
        }
    }
    private void FixedUpdate()
    {
        if (Input.touchCount == 0)
        {   
            if(selected!=null)
            {
                selected.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0) * speed;
            }
            selected = null;
        }
        if (selected != null)
        {
            Move();
        }
    }

    void Selected()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            selected = hit.transform.gameObject;
        }
    }
    
    void Move()
    {
        Vector3 position = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 10);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
        vector_x = (worldPosition - selected.transform.position).x;
        vector_y = (worldPosition - selected.transform.position).y;
        selected.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(vector_x, vector_y, 0) * speed;
    }
}
