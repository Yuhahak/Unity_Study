using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class SkillTableDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    private float x2;
    private float y2;
    private float distanceX;
    private float distanceY;
    private Vector2 initialPosition;

    public float scrollSpeed = 1f;
    public float minScale = 0.1f;
    public float maxScale = 10f;
    public GameObject skillIcon;

    public void Start()
    {
        x2 = transform.position.x;
        y2 = transform.position.y;
    }

    private void OnEnable()
    {
        skillIcon.transform.localScale = new Vector3(0.7f, 0.7f);
    }

    void Update()
    {
        float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");

        // Scale the object based on the scroll wheel input
        if (scrollWheelInput != 0f)
        {
            Vector3 newScale = skillIcon.transform.localScale + Vector3.one * scrollWheelInput * scrollSpeed;
            newScale = ClampScale(newScale);
            skillIcon.transform.localScale = newScale;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        distanceX = Input.mousePosition.x - x2;
        distanceY = Input.mousePosition.y - y2;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x - distanceX, Input.mousePosition.y - distanceY);
        transform.position = mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        x2 = transform.position.x;
        y2 = transform.position.y;
    }

    private Vector2 ClampScale(Vector3 scale)
    {
        scale.x = Mathf.Clamp(scale.x, minScale, maxScale);
        scale.y = Mathf.Clamp(scale.y, minScale, maxScale);
        return scale;
    }
}
