using UnityEngine;
using UnityEngine.UIElements;

[ExecuteAlways]
[RequireComponent(typeof(SpriteRenderer))]
public class SetSpriteColour : MonoBehaviour
{
    public TokenResolvableValue<Color> color;
    void Update()
    {
        GetComponent<SpriteRenderer>().color = color;
    }
}
