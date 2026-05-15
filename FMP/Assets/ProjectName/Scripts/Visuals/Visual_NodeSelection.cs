using RBitUtils.ResponseTypes;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Visual_NodeSelection), true)]
public class EDITOR_Visual_NodeSelection : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        if (GUILayout.Button("Reload Settings"))
        {
            ((Visual_NodeSelection)target).InitEasing();
        }
    }
}
public class Visual_NodeSelection : MonoBehaviour
{
    public Vec3Response<Spring> posEasing;
    public Spring scaleEasing;
    public TokenResolvableValue<SpringSettings> posEasingSettings;
    public Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posEasingSettings.token.Reload += InitEasing;
        InitEasing();
    }
    public void InitEasing()
    {
        SpringSettings settings = posEasingSettings;
        posEasing = new(x => new Spring(x, settings.frequency, settings.damping, settings.response), transform.position);
        scaleEasing = new(transform.localScale.x, settings.frequency, settings.damping, settings.response);
    }
    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = posEasing.Update(Time.deltaTime, target.position);
            transform.localScale = Vector3.one * scaleEasing.Update(Time.deltaTime, target.localScale.x);
        }
    }
}
