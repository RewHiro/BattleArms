using UnityEngine;
using UnityEngine.UI;

public class HPUIManager : MonoBehaviour
{
    [SerializeField]
    GameObject object_ = null;

    RectTransform rect_transform_ = null;
    Image image_ = null;
    HPManager hp_manager_ = null;

    float MAX_WIDTH = 0.0f;
    float MAX_HP = 0;

    void Start()
    {
        hp_manager_ = object_.GetComponent<HPManager>();
        image_ = GetComponent<Image>();
        rect_transform_ = GetComponent<RectTransform>();
        MAX_WIDTH = rect_transform_.rect.width;
        MAX_HP = hp_manager_.hp;
    }

    void Update()
    {
        var size_delta = rect_transform_.sizeDelta;
        size_delta.x = (hp_manager_.hp / MAX_HP)* MAX_WIDTH;
        rect_transform_.sizeDelta = size_delta;
    }
}
