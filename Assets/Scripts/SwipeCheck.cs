using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SwipeCheck : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public static event UnityAction<float> SwipeMade;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.delta.x) > (Mathf.Abs(eventData.delta.y)))
        {
            if (eventData.delta.x > 0)
            {
                SwipeMade?.Invoke(1);
            }
            else
            {
                SwipeMade?.Invoke(-1);
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {

    }
}
