using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    public Image bar;

    private float _originalSize;
    public static UIHealthBar Instance { get; private set; }

    // Use this for initialization
    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        _originalSize = bar.rectTransform.rect.width;
    }

    public void SetValue(float value)
    {
        bar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _originalSize * value);
    }
}