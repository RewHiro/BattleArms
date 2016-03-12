using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    GameObject target;

    float shotInterval = 0;
    float shotIntervalMax = 1.0f;
    
    [SerializeField]
    private float limitDistance = 1000f;
    [SerializeField]
    private float rotateSpeed = 5f;
    
	void Start () {

        target = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () {
        if (Vector3.Distance(target.transform.position, transform.position) <= limitDistance)
        {
            Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);

            shotInterval += Time.deltaTime;

            //  発射時間に達するとShot
            if (shotInterval > shotIntervalMax)
            {
                Debug.Log("Shot");
                shotInterval = 0;
            }
        }
	}
}
