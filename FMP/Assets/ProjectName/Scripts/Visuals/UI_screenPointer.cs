using RBitUtils;
using UnityEngine;

public class UI_screenPointer : MonoBehaviour
{
    public Camera cam;

    RectTransform rt => transform as RectTransform;
    public Vector3 prevPos;
    public Vector3 delta;

    /// <summary>
    /// Position in world units relative to the camera.
    /// </summary>
    public Vector3 relativePos;
    public Vector3 prevRelative;
    public Vector3 relativeDelta;

    public Vector2 prevAnchored;
    public Vector2 anchorPosDelta;

    public Vector3 prevLocal;
    public Vector3 localDelta;

    void Update()
    {
        // calc pos
        ((RectTransform)transform).anchoredPosition = MGR_game.input.generalActions.MousePos.ReadValue<Vector2>() / MGR_game.levelUI.canvas.scaleFactor;
        relativePos = transform.position - cam.transform.position;

        //calc delta
        delta = transform.position - prevPos;
        relativeDelta = relativePos - prevRelative;
        anchorPosDelta = rt.anchoredPosition - prevAnchored;
        localDelta = rt.localPosition - prevLocal;


        // set prev
        prevPos = transform.position;
        prevRelative = relativePos;
        prevAnchored = rt.anchoredPosition;
        prevLocal = rt.localPosition;
    }
}
