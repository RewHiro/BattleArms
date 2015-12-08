using UnityEngine;
using System.Collections;

public class EffectCreater : MonoBehaviour {

    float count_;

    [SerializeField]
    GameObject particle_system_;

    GameObject particle_object_;

    HPManager hp_manager_;

    bool is_effect_;

    void Start ()
    {
        is_effect_ = false;
        hp_manager_ = GetComponent<HPManager>();
        count_ = hp_manager_.hp;
    }
	
	void Update ()
    {
         count_ = hp_manager_.hp;
        if (count_ <= 0)
        {
            if (is_effect_ == false)
            {
                particle_object_ = Instantiate(particle_system_);
                //            game_object.transform.SetParent(particle_manager_.transform);
                particle_object_.name = particle_system_.name;
                is_effect_ = true;
            }
        }
        else
        {
            is_effect_ = false;
        }
    }
}
