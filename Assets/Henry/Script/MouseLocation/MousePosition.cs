using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 MousePosition = Input.mousePosition;
            MousePosition.z = Camera.main.transform.position.z * -1;
            MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);
            transform.position = new Vector2(MousePosition.x, MousePosition.y);
        }
    }
}
