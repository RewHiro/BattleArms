using UnityEngine;
using System.Collections;

public class ParentDestory : MonoBehaviour {

	void Update ()
    {
      if(gameObject.transform.childCount == 0)
        {
            Destroy(gameObject);
        }  

	}
}
