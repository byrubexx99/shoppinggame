using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIDragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Canvas Canvas;
    private RectTransform RectTransform;
    private CanvasGroup CanvasGroup;
    [HideInInspector] public Transform ParentAfterDrag;

    private void Awake()
    {
        RectTransform = GetComponent<RectTransform>();
        CanvasGroup = GetComponent<CanvasGroup>();
        if (Canvas == null) Canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData EventData)
    {
        ParentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        CanvasGroup.blocksRaycasts = false;
        CanvasGroup.alpha = 0.7f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransform.anchoredPosition += eventData.delta / Canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(ParentAfterDrag);
        RectTransform.anchoredPosition = Vector2.zero;
        CanvasGroup.blocksRaycasts = true;
        CanvasGroup.alpha = 1f;
    }
}