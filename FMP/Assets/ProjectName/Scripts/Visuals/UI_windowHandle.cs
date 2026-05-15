using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class UI_windowHandle : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Vector2Int action;
    public RectTransform targetTransform;
    public bool doing;
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
            doing = true;
        }

    }
    void OnPointerUp(InputAction.CallbackContext ctx)
    {
        doing = false;
    }

    void Update()
    {
        if (hovered || doing ) SetPointer();
        if (!doing) return;

        RectTransform t = targetTransform;

        Vector2 delta = MGR_game.input.screenPointer.localDelta;
        Vector2 deltaX = Vector2.right * delta.x;
        Vector2 deltaY = Vector2.up * delta.y;

        if (action == new Vector2Int( 1,  1)) t.offsetMax += delta; // top right
        if (action == new Vector2Int( 0,  1)) t.offsetMax += deltaY; // top
        if (action == new Vector2Int(-1,  1)) { t.offsetMin += deltaX; t.offsetMax += deltaY; } // top left

        if (action == new Vector2Int(-1,  0)) t.offsetMin += deltaX; // left
        if (action == new Vector2Int( 0,  0)) { t.offsetMin += delta; t.offsetMax += delta; } // all
        if (action == new Vector2Int( 1,  0)) t.offsetMax += deltaX; // right

        if (action == new Vector2Int( 1, -1)) { t.offsetMax += deltaX; t.offsetMin += deltaY; } // bottom right
        if (action == new Vector2Int( 0, -1)) t.offsetMin += deltaY; // bottom
        if (action == new Vector2Int(-1, -1)) targetTransform.offsetMin += delta; // bottom left
    }

    void SetPointer()
    {
        if (action == new Vector2Int(1, 1)) ChangeCursor(WindowsCursor.DoublePointedArrowPointingNortheastAndSouthwest); // top right
        if (action == new Vector2Int(0, 1)) ChangeCursor(WindowsCursor.DoublePointedArrowPointingNorthAndSouth); // top
        if (action == new Vector2Int(-1, 1)) ChangeCursor(WindowsCursor.DoublePointedArrowPointingNorthwestAndSoutheast); // top left

        if (action == new Vector2Int(-1, 0)) ChangeCursor(WindowsCursor.DoublePointedArrowPointingWestAndEast); // left
        //if (action == new Vector2Int(0, 0)) { t.offsetMin += delta; t.offsetMax += delta; } // all
        if (action == new Vector2Int(1, 0)) ChangeCursor(WindowsCursor.DoublePointedArrowPointingWestAndEast); // right

        if (action == new Vector2Int(1, -1)) ChangeCursor(WindowsCursor.DoublePointedArrowPointingNorthwestAndSoutheast); // bottom right
        if (action == new Vector2Int(0, -1)) ChangeCursor(WindowsCursor.DoublePointedArrowPointingNorthAndSouth); // bottom
        if (action == new Vector2Int(-1, -1)) ChangeCursor(WindowsCursor.DoublePointedArrowPointingNortheastAndSouthwest); // bottom left
    }


    public enum WindowsCursor
    {
        StandardArrowAndSmallHourglass = 32650,
        StandardArrow = 32512,
        Crosshair = 32515,
        Hand = 32649,
        ArrowAndQuestionMark = 32651,
        IBeam = 32513,
        //Icon = 32641, // Obsolete for applications marked version 4.0 or later. 
        SlashedCircle = 32648,
        //Size = 32640,  // Obsolete for applications marked version 4.0 or later. Use FourPointedArrowPointingNorthSouthEastAndWest
        FourPointedArrowPointingNorthSouthEastAndWest = 32646,
        DoublePointedArrowPointingNortheastAndSouthwest = 32643,
        DoublePointedArrowPointingNorthAndSouth = 32645,
        DoublePointedArrowPointingNorthwestAndSoutheast = 32642,
        DoublePointedArrowPointingWestAndEast = 32644,
        VerticalArrow = 32516,
        Hourglass = 32514
    }

    private static void ChangeCursor(WindowsCursor cursor)
    {
        SetCursor(LoadCursor(IntPtr.Zero, (int)cursor));
    }

    [DllImport("user32.dll", EntryPoint = "SetCursor")]
    public static extern IntPtr SetCursor(IntPtr hCursor);

    [DllImport("user32.dll", EntryPoint = "LoadCursor")]
    public static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);

}
