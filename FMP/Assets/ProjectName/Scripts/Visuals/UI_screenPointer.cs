using RBitUtils;
using UnityEngine;

public class UI_screenPointer : MonoBehaviour
{
    public Camera cam;

    public Vector3 relativeDelta;
    public Vector3 delta;
    public Vector3 prevRelativePos;
    public Vector3 prevPos;

    /// <summary>
    /// Position in world units relative to the camera.
    /// </summary>
    public Vector3 relativePos;
    public Vector3 pos;

    void Update()
    {
        prevPos = pos;
        prevRelativePos = relativePos;

        ((RectTransform)transform).anchoredPosition = MGR_game.input.generalActions.MousePos.ReadValue<Vector2>() / MGR_game.levelUI.canvas.scaleFactor;
        pos = transform.position;
        relativePos = pos - cam.transform.position;

        delta = pos - prevPos;
        relativeDelta = relativePos - prevRelativePos;
    }
}
