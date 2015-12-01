using UnityEngine;
using UnityEngine.UI;

public class StartUpProduction : MonoBehaviour
{

    Image image_ = null;
    float alpha_ = 1.0f;

    void Start()
    {
        image_ = GetComponent<Image>();
    }

    void Update()
    {
        if (image_.color.a == 0.0f) return;
        alpha_ += -Time.deltaTime;
        image_.color = new Color(0, 0, 0, alpha_);
    }
}
