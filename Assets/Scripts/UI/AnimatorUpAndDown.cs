using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnimatorUpAndDown : MonoBehaviour {

    private bool is_up_select = false;
    private bool is_down_select = false;
    private Animator _animator;
    private int _up_select_Hash = Animator.StringToHash("UPSelect");
    private int _down_select_Hash = Animator.StringToHash("DownSelect");

    void Start ()
    {
        _animator = GetComponent<Animator>();
	}
	
	void Update ()
    {


    }


    public void UpSelect()
    {
        is_up_select = true;
        is_down_select = false;
        _animator.SetBool(_down_select_Hash, is_down_select);

        _animator.SetBool(_up_select_Hash, is_up_select);
        is_up_select = false;
        Debug.Log("homo1");
    }

    public void DownSelect()
    {
        is_down_select = true;
        is_up_select = false;
        _animator.SetBool(_up_select_Hash, is_up_select);
        _animator.SetBool(_down_select_Hash, is_down_select);
        is_down_select = false;
        Debug.Log("homo");
    }

}
