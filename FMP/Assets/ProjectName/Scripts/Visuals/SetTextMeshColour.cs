using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

[ExecuteAlways]
[RequireComponent(typeof(TMP_Text))]
public class SetTextMeshColour : MonoBehaviour
{
    public TokenResolvableValue<Color> color;
    void Update()
    {
        GetComponent<TMP_Text>().color = color;
    }
}
