using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    [SerializeField] private Image imageToChange;
    [SerializeField] private Sprite spriteToUse;

    [ContextMenu("Test change image")]
    private void ChangeSpriteTest()
    {
        imageToChange.sprite = spriteToUse;
    }
}
