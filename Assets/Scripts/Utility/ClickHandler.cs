using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private ClickEvent clickHandler;

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.Instance.ClickEvent(this.gameObject);

    }

    public void AddClickHandler(UnityAction<GameObject> handler)
    {
        this.clickHandler.AddListener(handler);
    }

    [System.Serializable]
    public class ClickEvent : UnityEvent<GameObject> { }
}
