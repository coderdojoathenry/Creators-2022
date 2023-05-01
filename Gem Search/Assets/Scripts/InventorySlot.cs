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
  public TMP_Text NameText;

  public Vector2 DragIconSize = new Vector2(40, 40);

  private Canvas _canvas;
  private GameObject _draggingIcon;

  private GemInventoryAreaBase.GemInventoryAreaType _type;
  private GemInventory _gemInventory;

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
    NameText.text = (GemDefinition == null || GemCount < 1) ? "" : GemDefinition.name;
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

    // Set the size
    var imageRt = image.GetComponent<RectTransform>();
    imageRt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, DragIconSize.x);
    imageRt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, DragIconSize.y);

    // Set the alpha and interactability
    CanvasGroup canvasGroup = _draggingIcon.AddComponent<CanvasGroup>();
    canvasGroup.alpha = 0.75f;
    canvasGroup.blocksRaycasts = false;

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
    if (eventData.pointerDrag != null)
    {
      InventorySlot fromSlot = eventData.pointerDrag.GetComponent<InventorySlot>();

      if (fromSlot != null)
      {
        _gemInventory.DragBetween(fromSlot._type, _type, fromSlot.GemDefinition);
      }
    }
  }

  public void OnEndDrag(PointerEventData eventData)
  {
    if (_draggingIcon != null)
    {
      Destroy(_draggingIcon);
      _draggingIcon = null;
    }
  }

  public void SetDetails(GemDefinition gemDefinition, int count)
  {
    GemDefinition = gemDefinition;
    GemCount = count;
  }

  public void RegisterSlot(GemInventoryAreaBase.GemInventoryAreaType type,
                           GemInventory inventory)
  {
    _type = type;
    _gemInventory = inventory;
  }
}
