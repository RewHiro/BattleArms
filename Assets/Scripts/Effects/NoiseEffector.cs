using UnityEngine;
using System.Collections;

public class NoiseEffector : MonoBehaviour
{

    float count_ = 0.0f;

    [SerializeField]
    float EFFECT_TIME = 2.0f;

    Animator animator_ = null;
    SpriteRenderer sprite_rendrer_ = null;

    void Start()
    {
        animator_ = GetComponent<Animator>();
        sprite_rendrer_ = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sprite_rendrer_.color.a <= 0.0f) return;
        count_ += Time.deltaTime;
        if (count_ >= EFFECT_TIME)
        {
            sprite_rendrer_.color = new Color(0, 0, 0, 0);
        }
    }
}
