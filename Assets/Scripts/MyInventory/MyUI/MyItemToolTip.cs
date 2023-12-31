using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MyItemToolTip : MonoBehaviour
{
    public Text itemName;
    public Text itemInfo;
    RectTransform rectTransform;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    private void OnEnable()
    {
        MyUpdatePosition();
    }
    private void Update()
    {
        MyUpdatePosition();
    }


    public void MyUpdatePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);

        float width = corners[3].x - corners[0].x;
        float height = corners[1].y - corners[1].y;

        if (mousePos.y < height)
        {
            rectTransform.position = mousePos + Vector3.up * height * 0.6f;
        }
        else if (Screen.width - mousePos.x > width)
        {
            rectTransform.position = mousePos + Vector3.right * width * 0.6f;
        }
        else
            rectTransform.position = mousePos + Vector3.left * width * 0.6f;
    }
    public void SetUpToolTip(MyItemData_SO item)
    {
        itemName.text = item.itemName;
         
        itemInfo.text = item.Setdescription();
    }
}
