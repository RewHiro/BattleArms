using UnityEngine;

public class LeapPosition : MonoBehaviour
{
    [SerializeField]
    GameObject hand_contoroller_prefab_ = null;

    GameObject hand_contoroller_ = null;

    void Start()
    {
        hand_contoroller_ = Instantiate(hand_contoroller_prefab_);
        hand_contoroller_.transform.position = transform.position;
        hand_contoroller_.transform.rotation = transform.rotation;
    }

    void Update()
    {
        hand_contoroller_.transform.position = transform.position;
        hand_contoroller_.transform.rotation = transform.rotation;
    }
}
