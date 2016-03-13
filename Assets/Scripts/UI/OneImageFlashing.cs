using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class OneImageFlashing : MonoBehaviour {


    [SerializeField]
    Image normal_image_;

    [SerializeField]
    int time_ = 0;

    int count;

    bool is_select_ = false;

    void Start()
    {

        count = time_;
    }

    public void IsSelect()
    {
        is_select_ = true;
    }

    void Update()
    {
        OneImageFlash(is_select_);
    }

    public void OneImageFlash(bool is_select)
    {

        if (!is_select) return;

        if (count > 0)
        {
            if ((count / 3) % 2 == 1)
            {
                normal_image_.enabled = false;
            }
            else
            {
                normal_image_.enabled = true;

            }
            count--;
        }
        else
            if (count <= 0)
        {
            count = time_;
            is_select_ = false;
        }
    }

}

