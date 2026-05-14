using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class UI_windowHandle : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool doing;
    public Vector2Int action;
    public RectTransform targetTransform;
    public Vector2 offset;
    public bool hovered;

    private void Start()
    {
        MGR_game.input.OnInputReady += InputCallbacks;
    }

    void InputCallbacks()
    {
        MGR_game.input.input.General.LMB.started += OnPointerDown;
        MGR_game.input.input.General.LMB.canceled += OnPointerUp;
        MGR_game.input.input.General.MouseDelta.performed += OnPointerMove;
    }

    void OnPointerDown(InputAction.CallbackContext ctx)
    {
        if (hovered)
        {
            doing = true;
        }

        offset = targetTransform.position - MGR_game.input.worldPointer.pos;
    }

    void OnPointerUp(InputAction.CallbackContext ctx)
    {
        doing = false;
    }

    void OnPointerMove(InputAction.CallbackContext ctx)
    {
        if (!doing) return;
        if (action == Vector2Int.zero)
        {
            targetTransform.position += MGR_game.input.screenPointer.relativeDelta;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovered = false;
    }
}
