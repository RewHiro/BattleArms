using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

    FaceEnemy face_enemy_;

	// Use this for initialization
	void Start () {
        face_enemy_ = GetComponent<FaceEnemy>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            face_enemy_.ChangeLockEnemy();                                                                                                                                                                                                                                                                                                                                                  //homo
        }
	}
}
