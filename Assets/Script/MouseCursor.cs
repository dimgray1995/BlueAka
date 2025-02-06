using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseCursor : MonoBehaviour
{
    public RectTransform transform_cursor;
    public RectTransform[] transform_icons;
    //public Text text_mouse;
    public int mouseNumber;
    public int mouseX;
    public int mouseY;

    private void Start()
    {
        Init_Cursor();
        Cursor.lockState = CursorLockMode.Confined;

    }
    private void Update()
    {
        Update_MouseMoving();
    }

    private void Init_Cursor()
    {
        Cursor.visible = false;
        transform_cursor.pivot = Vector2.up;

        if (transform_cursor.GetComponent<Graphic>())
            transform_cursor.GetComponent<Graphic>().raycastTarget = false;


        for (int i = 0; i < transform_icons.Length; i++)
        {
            if (transform_icons[i].GetComponent<Graphic>())
                transform_icons[i].GetComponent<Graphic>().raycastTarget = false;
        }


    }

    private void Update_MouseMoving()
    {
        Vector2 mousePos = Input.mousePosition;
        transform_cursor.position = mousePos;
        Vector3 pivot = new Vector3(mouseX, mouseY, 0) * mouseNumber;
        for (int i = 0; i < transform_icons.Length; i++)
        {
            transform_icons[i].position = Vector3.Lerp(transform_icons[i].position, transform_cursor.position + pivot, Mathf.Pow(1.5f, i) * 0.005f);
        }

        //string message = mousePos.ToString();
        //text_mouse.text = message;
        //Debug.Log(message);
    }
}
