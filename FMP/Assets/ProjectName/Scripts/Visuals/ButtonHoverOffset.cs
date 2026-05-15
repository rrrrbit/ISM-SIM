using RBitUtils.ResponseTypes;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

[CustomEditor(typeof(ButtonHoverOffset), true)]
public class EDITOR_ButtonHoverOffset : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Reload Settings"))
        {
            ((ButtonHoverOffset)target).InitEasing();
        }
    }
}
public class ButtonHoverOffset : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Vector3 offset;
    Vector3 startingPos;
    public TokenResolvableValue<SpringSettings> posEasingSettings;
    Vec3Response<Spring> posEasing;
    Vector3 targetPos;

    void Start()
    {
        startingPos = ((RectTransform)transform).anchoredPosition;
        posEasingSettings.token.Reload += InitEasing;
        InitEasing();
    }
    public void InitEasing()
    {
        SpringSettings settings = posEasingSettings;
        posEasing = new(x => new Spring(x, settings.frequency, settings.damping, settings.response), ((RectTransform)transform).anchoredPosition);
    }

    void Update()
    {
        ((RectTransform)transform).anchoredPosition = posEasing.Update(Time.deltaTime, targetPos);
    }

    public void OnPointerEnter(PointerEventData data)
    {
        targetPos = startingPos + offset;
    }

    public void OnPointerExit(PointerEventData data)
    {
        targetPos = startingPos;
    }
}
