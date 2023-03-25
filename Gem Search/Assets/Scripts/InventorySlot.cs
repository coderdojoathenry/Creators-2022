using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour,
                             IBeginDragHandler,
                             IEndDragHandler,
                             IDragHandler,
                             IDropHandler
{
  public GemDefinition GemDefinition;
  public int GemCount;

  public Image SlotImage;
  public GameObject CountTextBadge;
  public TMP_Text CountText;

  public Vector2 DragIconSize = new Vector2(40, 40);

  private Canvas _canvas;
  private GameObject _draggingIcon;

  // Start is called before the first frame update
  void Start()
  {
    _canvas = GetComponentInParent<Canvas>();
  }

  // Update is called once per frame
  void Update()
  {
    if (GemDefinition == null || GemCount < 1)
    {
      SlotImage.sprite = null;
    }
    else
    {
      SlotImage.sprite = GemDefinition.Sprite;
    }

    CountTextBadge.SetActive(GemDefinition != null && GemCount > 1);
    CountText.text = GemCount.ToString();
  }

  public void OnBeginDrag(PointerEventData eventData)
  {
    if (GemDefinition == null || GemCount < 1)
      return;

    _draggingIcon = new GameObject("Icon");
    _draggingIcon.transform.SetParent(_canvas.transform, false);
    _draggingIcon.transform.SetAsLastSibling();

    var image = _draggingIcon.AddComponent<Image>();
    image.sprite = GemDefinition.Sprite;

    OnDrag(eventData);
  }

  public void OnDrag(PointerEventData eventData)
  {
    if (_draggingIcon == null)
      return;

    RectTransform iconRt = _draggingIcon.GetComponent<RectTransform>();
    RectTransform canvasRt = _canvas.GetComponent<RectTransform>();
    
    Vector3 globalMousePos;
    if (RectTransformUtility.ScreenPointToWorldPointInRectangle(canvasRt,
                                                                eventData.position,
                                                                eventData.pressEventCamera,
                                                                out globalMousePos))
    {
      iconRt.position = globalMousePos;
    }
  }

  public void OnDrop(PointerEventData eventData)
  {

  }

  public void OnEndDrag(PointerEventData eventData)
  {

  }
}
