using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour
{

    public Transform target; //プレイヤーの位置
    static Vector3 pos;
    NavMeshAgent agent;

    float agentToPatroldistance;
    float agentToTargetdistance;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    void Start()
    {
        DoPatrol();
    }


    void Update()
    {
        //Agentと目的地の距離
        agentToPatroldistance = Vector3.Distance(this.agent.transform.position, pos);

        //Agentとプレイヤーの距離
        agentToTargetdistance = Vector3.Distance(this.agent.transform.position, target.transform.position);


        //プレイヤーとAgentの距離が30f以下になると追跡開始
        if (agentToTargetdistance <= 30f)
        {
            DoTracking();

            //プレイヤーと目的地の距離が15f以下になると次の目的地をランダム指定
        }
        else if (agentToPatroldistance < 15f)
        {
            DoPatrol();
        }

    }



    //エージェントが向かう先をランダムに指定するメソッド
    public void DoPatrol()
    {
        var x = Random.Range(-50.0f, 50.0f);
        var z = Random.Range(-50.0f, 50.0f);
        pos = new Vector3(x, 0, z);
        agent.SetDestination(pos);
    }

    //targetに指定したplayerを追いかけるメソッド
    public void DoTracking()
    {
        pos = target.position;
        agent.SetDestination(pos);
    }

}
 
