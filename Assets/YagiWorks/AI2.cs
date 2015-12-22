using UnityEngine;
using System.Collections;

enum DISTANCE_STATE
{
    SHORT,
    MIDDLE,
    LONG
}

enum ATTACK_STATE
{
    ATTACK,
    WAIT,
}

public class AI2 : MonoBehaviour
{
    [SerializeField]
    private Transform player;    //プレイヤーを代入
    [SerializeField]
    private float speed = 3; //移動速度

    [SerializeField]
    GameObject right_weapon_object_ = null;

    [SerializeField]
    GameObject left_weapon_object_ = null;

    //敵キャラクターがどの程度近づいてくるか設定(この値以下には近づかない）
    [SerializeField]
    private float shortlimitDistance = 100f;
    [SerializeField]
    private float middlelimitDistance = 1000f;
    [SerializeField]
    private float longlimitDistance = 3000f;

    private float limitDistance;

    private DISTANCE_STATE distance_state;
    private ATTACK_STATE attack_state;

    private int timer = 0;
    private int atktimer = 0;

    // private bool isGround = false;

    HPManager hp_manager_ = null;
    EnemyStater enemy_stater_ = null;

    //ゲーム開始時に一度
    void Start()
    {
        //Playerオブジェクトを検索し、参照を代入

        hp_manager_ = GetComponent<HPManager>();
        enemy_stater_ = GetComponent<EnemyStater>();

        distance_state = DISTANCE_STATE.LONG;
        attack_state = ATTACK_STATE.WAIT;
    }

    //毎フレームに一度
    void Update()
    {
        if (!hp_manager_.isActive) return;
        if (!enemy_stater_.isNormal) return;
        if (GameObject.FindGameObjectWithTag("Player") == null) return;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 playerPos = player.position;                 //プレイヤーの位置
        Vector3 direction = playerPos - transform.position; //方向と距離を求める。
        float distance = direction.sqrMagnitude;            //directionから距離要素だけを取り出す。
        direction = direction.normalized;                   //単位化（距離要素を取り除く）
        direction.y = 0f;                                   //後に敵の回転制御に使うためY軸情報を消去。これにより敵が上下を向かなくなる。

        //プレイヤーとの距離を設定
        switch (distance_state)
        {
            case DISTANCE_STATE.SHORT:
                limitDistance = shortlimitDistance;
                break;
            case DISTANCE_STATE.MIDDLE:
                limitDistance = middlelimitDistance;
                break;
            case DISTANCE_STATE.LONG:
                limitDistance = longlimitDistance;
                break;
        }

        //プレイヤーの距離が一定以上でなければ、敵キャラクターはプレイヤーへ近寄ろうとしない
        if (distance >= limitDistance)
        {

            //プレイヤーとの距離が制限値以上なので普通に近づく
            transform.position = transform.position + (direction * speed * Time.deltaTime);

        }
        else if (distance < limitDistance)
        {

            //プレイヤーとの距離が制限値未満（近づき過ぎ）なので、後退する。
            transform.position = transform.position - (direction * speed * Time.deltaTime);
        }

        //プレイヤーの方を向く
        transform.rotation = Quaternion.LookRotation(direction);



        if (timer >= 180)
        {
            int var;
            var = Random.Range(0, 3);
            Debug.Log(var);
            if (var == 0)
            {
                distance_state = DISTANCE_STATE.SHORT;
                Debug.Log("short");
            }
            if (var == 1)
            {
                distance_state = DISTANCE_STATE.MIDDLE;
                Debug.Log("middle");
            }
            if (var == 2)
            {
                distance_state = DISTANCE_STATE.LONG;
                Debug.Log("long");
            }
            timer = 0;
        }

        if (atktimer >= 20)
        {
            int var;
            var = Random.Range(0, 60);
            if (var < 10) { }
            else if (var < 30) { Attack(); }
            else { }
            atktimer = 0;
        }

        timer += 1;
        atktimer += 1;

        //Debug.Log(timer);

        ////重力落下処理（プレイヤーの距離関係なく下に移動する）
        //Vector3 rayPos = transform.position;
        //rayPos.y -= 1f;

        //if (!Physics.Raycast(rayPos, Vector3.down, 0.5f))
        //{
        //    transform.position = transform.position + (Vector3.down * 9.8f * Time.deltaTime);
        //}
        ////地面判定線を見れるようにする
        //Debug.DrawRay(rayPos, Vector3.down * 1 / 10);

        ////敵のY座標が-5以下の時自身を削除
        //if (transform.position.y <= -5f)
        //{
        //    Destroy(gameObject);
        //}
    }

    void Attack()
    {
        Debug.Log("Attack");
        var right_weapon = right_weapon_object_.GetComponentInChildren<Weapon>();
        right_weapon.SetLayer(14);
        right_weapon.CreateBullet();
        right_weapon.SetReticle(player.gameObject);

        var left_weapon = left_weapon_object_.GetComponentInChildren<Weapon>();
        left_weapon.SetLayer(14);
        left_weapon.CreateBullet();
        left_weapon.SetReticle(player.gameObject);
    }
}