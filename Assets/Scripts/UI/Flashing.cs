using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Flashing : MonoBehaviour {

    [SerializeField]
    Image flashing_image_;

    [SerializeField]
    Image normal_image_;

    [SerializeField]
    int time_ = 0;

    int count;

    bool is_select_ = false;

    void Start ()
    {
        
        count = time_;
    }

    public void IsSelect()
    {
        is_select_ = true;
    }

    void Update()
    {
        TwoImageFlash(is_select_);
    }

    public void TwoImageFlash(bool is_select)
    {

        if (!is_select) return;
        if (count > 0)
        {
            
            if ((count / 4) % 2 == 1)
            {
                normal_image_.enabled = false;
                flashing_image_.enabled = true;
            }
            else
            {
                flashing_image_.enabled = false;
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
