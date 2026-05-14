using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class MGR_input : MonoBehaviour
{
    public Input input;
    public Input.GameActions gameActions;
    public Input.GeneralActions generalActions;
    public event System.Action OnInputReady;
    public GameCamera cam;

    public UI_worldPointer worldPointer;
    public UI_screenPointer screenPointer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = new Input();
        input.Enable();

        gameActions = input.Game;
        gameActions.Enable();

        generalActions = input.General;
        generalActions.Enable();

        OnInputReady?.Invoke();

        worldPointer.cam = MGR_game.levelUI.uiCam;
        screenPointer.cam = MGR_game.levelUI.uiCam;
    }

    // Update is called once per frame
    void Update()
    { 

    }  
}
