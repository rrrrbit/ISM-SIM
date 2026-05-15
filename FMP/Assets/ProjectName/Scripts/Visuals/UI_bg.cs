using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class UI_bg : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool dragging;
    public bool hovered;

    private void Start()
    {
        MGR_game.input.OnInputReady += InputCallbacks;
    }
    void InputCallbacks()
    {
        MGR_game.input.input.General.LMB.started += OnPointerDown;
        MGR_game.input.input.General.LMB.canceled += OnPointerUp;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        hovered = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        hovered = false;
    }
    void OnPointerDown(InputAction.CallbackContext ctx)
    {
        if (hovered)
        {
            dragging = true;
        }

    }
    void OnPointerUp(InputAction.CallbackContext ctx)
    {
        dragging = false;
    }
}
