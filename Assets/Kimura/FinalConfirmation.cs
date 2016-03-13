using UnityEngine;
using System.Collections;

public class FinalConfirmation : MonoBehaviour {

    [SerializeField]
    GameObject[] close_hit_gameobject_;

    private bool is_final_confirmation_ = false;
    private Animator _animator;
    private int _final_confirmation_Hash = Animator.StringToHash("Is_FinalConfirmation");

    void Start ()
    {
        _animator = GetComponent<Animator>();
    }
	
	void Update (){}

    public void  Open()
    {
        foreach(var gameobject in close_hit_gameobject_)
        {
            gameobject.SetActive(false);
        }

        is_final_confirmation_ = true;
        _animator.SetBool(_final_confirmation_Hash, is_final_confirmation_);
    }

    public void Close()
    {

        is_final_confirmation_ = false;
        _animator.SetBool(_final_confirmation_Hash, is_final_confirmation_);

        foreach (var gameobject in close_hit_gameobject_)
        {
            gameobject.SetActive(true);
        }

    }
}
