using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
[RequireComponent(typeof(Image))]
public class SetImageTint : MonoBehaviour
{
    public TokenResolvableValue<Color> color;
    void Update()
    {
        GetComponent<Image>().color = color;
    }
}
