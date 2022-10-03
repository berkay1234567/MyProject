using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLookAtCursor : MonoBehaviour
{
    [SerializeField] Camera cam;
    Transform turret;
    Vector3 mousePos;
    Rigidbody rb;
    [SerializeField]float speed;
    float angle;
    Vector3 target;

    private void Awake()
    {
        turret = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        LAMouse();
    }

    void LAMouse()
    {
        /*angle +=Input.GetAxis("Mouse X") * speed * -Time.deltaTime;
        //angle = Mathf.Clamp(angle,0,180);
        turret.localRotation = Quaternion.AngleAxis(angle, Vector3.up);*/

        /*Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition)- turret.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        turret.rotation = rotation;*/

        /*mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = mousePos - rb.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.left);
        rb.rotation = rotation; */

       /* Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            
            angle = Mathf.Atan2(hitInfo.point.y, hitInfo.point.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            rb.rotation = rotation; 
        }*/

        /*target = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        var diffrence = target - turret.transform.position;
        
        float rotationY = Mathf.Atan2(diffrence.x,diffrence.z) * Mathf.Rad2Deg;
        turret.transform.rotation = Quaternion.Euler(0.0f,rotationY,0.0f);*/

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);

        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;  

        float angle = Mathf.Atan2(mousePos.y, mousePos.x)* Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0,0 , angle+90));

        
        
    }
}
