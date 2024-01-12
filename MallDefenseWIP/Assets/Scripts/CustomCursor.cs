using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public Transform CursorVisual;
    public Vector3 Displacement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CursorVisual.position = Input.mousePosition + Displacement;
        Cursor.visible = false;
    }
}
