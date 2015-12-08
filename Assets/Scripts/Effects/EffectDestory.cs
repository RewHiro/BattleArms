using UnityEngine;
using System.Collections;

public class EffectDestory : MonoBehaviour {

    ParticleSystem particle_;

    void Start()
    {
        Init();
    }

    void Update()
    {
        ParticleDestroy();
    }

    void Init()
    {
        particle_ = GetComponent<ParticleSystem>();
    }

    void ParticleDestroy()
    {
        if (particle_)
        {
            if (!particle_.IsAlive())
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Debug.Log("これは「ParticleSystem」じゃないです。");
        }
    }

}