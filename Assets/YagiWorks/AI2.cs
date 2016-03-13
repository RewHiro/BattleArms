using UnityEngine;
using System.Collections.Generic;
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
    
    private GameObject nearObj;
    private float searchTime=0;

    HPManager hp_manager_ = null;
    EnemyStater enemy_stater_ = null;

    ServerStageManager server_stage_manager_ = null;

    float JUMP_POWER = 0.0f;
    float BOOST_POWER = 150.0f;

    bool guard = false;

    [SerializeField]
    GameObject red_boost_ = null;

    [SerializeField]
    GameObject blue_boost_ = null;

    // private bool isGround = false;

    Weapon right_weapon_ = null;
    Weapon left_weapon_ = null;

    EnterRoom enter_room_ = null;

    string room_name_ = "";

    public string roomName
    {
        get
        {
            return room_name_;
        }
    }

    public void SetRoomName(string name)
    {
        room_name_ = name;
    }

    //ゲーム開始時に一度
    void Start()
    {
        hp_manager_ = GetComponent<HPManager>();
        enemy_stater_ = GetComponent<EnemyStater>();

        //Playerオブジェクトを検索し、参照を代入
        player = GameObject.FindGameObjectWithTag("Player").transform;
        distance_state = DISTANCE_STATE.LONG;
        attack_state = ATTACK_STATE.WAIT;

        right_weapon_ = right_weapon_object_.GetComponentInChildren<Weapon>();
        left_weapon_ = left_weapon_object_.GetComponentInChildren<Weapon>();

        var id = GetComponent<Identificationer>().id;
        var air_frame_parameter = FindObjectOfType<AirFrameParameter>();
        speed = air_frame_parameter.GetMoveSpeed(id);
        JUMP_POWER = air_frame_parameter.GetJumpPower(id);
        BOOST_POWER = air_frame_parameter.GetBoostPower(id);

        foreach (var room in FindObjectsOfType<EnterRoom>())
        {
            if (room.transform.parent.name.GetHashCode() != roomName.GetHashCode()) continue;
            enter_room_ = room;
            Debug.Log(gameObject.name);
        }

    }

    void FindComponent()
    {
        if (enter_room_ != null) return;

    }

    //毎フレームに一度
    void Update()
    {
        if (enemy_stater_.isMeleed || !hp_manager_.isActive)
        {
            StopAllCoroutines();
            guard = false;
        }

        if (!hp_manager_.isActive) return;
        if (!enemy_stater_.isNormal) return;

        if (server_stage_manager_ == null)
        {
            server_stage_manager_ = FindObjectOfType<ServerStageManager>();
        }
        if (server_stage_manager_ == null) return;
        if (server_stage_manager_.IsEndTutorial) return;

        if (!enter_room_.isEnter) return;

        if (!guard)
        {
            StartCoroutine(Move());
            guard = true;
        }

        Vector3 playerPos = player.position;                 //プレイヤーの位置
        Vector3 direction = playerPos - transform.position; //方向と距離を求める。
        float distance = direction.sqrMagnitude;            //directionから距離要素だけを取り出す。
        direction = direction.normalized;                   //単位化（距離要素を取り除く）
        //direction.y = 0f;                                   //後に敵の回転制御に使うためY軸情報を消去。これにより敵が上下を向かなくなる。

        //経過時間を取得
        searchTime += Time.deltaTime;

        if (searchTime >= 1.0f) {
            //最も近かったオブジェクトを取得
            nearObj = serchTag(gameObject, "Player");
            player = nearObj.transform;

            //経過時間を初期化
            searchTime = 0;
        }

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

        //プレイヤーの方を向く
        transform.rotation = Quaternion.LookRotation(direction);



        if (timer >= 180)
        {
            int var;
            var = UnityEngine.Random.Range(0, 3);
            if (var == 0)
            {
                distance_state = DISTANCE_STATE.SHORT;
            }
            if (var == 1)
            {
                distance_state = DISTANCE_STATE.MIDDLE;
            }
            if (var == 2)
            {
                distance_state = DISTANCE_STATE.LONG;
            }
            timer = 0;
        }

        if (atktimer >= 20)
        {
            int var;
            var = UnityEngine.Random.Range(0, 60);
            if (var < 10) { }
            else if (var < 30)
            {
                Attack();
            }
            else { }
            atktimer = 0;
        }

        timer += 1;
        atktimer += 1;

    }

    IEnumerator Move()
    {

        var time = 0.0f;

        red_boost_.SetActive(true);
        blue_boost_.SetActive(false);

        while (time < 5.0f)
        {
            time += Time.deltaTime;
            Vector3 playerPos = player.position;                 //プレイヤーの位置
            Vector3 direction = playerPos - transform.position; //方向と距離を求める。
            float distance = direction.sqrMagnitude;            //directionから距離要素だけを取り出す。
            direction = direction.normalized;                   //単位化（距離要素を取り除く）

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
            yield return null;
        }

        RandomAction();
    }

    IEnumerator Jump()
    {
        red_boost_.SetActive(false);
        blue_boost_.SetActive(true);

        GetComponent<Rigidbody>().AddForce(Vector3.up * JUMP_POWER, ForceMode.Impulse);

        var time = 0.0f;
        while (time < 1.0f)
        {
            time += Time.deltaTime;
            yield return null;
        }

        RandomAction();
    }

    IEnumerator BoostMove()
    {

        red_boost_.SetActive(false);
        blue_boost_.SetActive(true);

        var random = UnityEngine.Random.Range(0, 2);
        var direciont = random == 1 ? transform.right : -transform.right;

        GetComponent<Rigidbody>().AddForce(direciont * BOOST_POWER, ForceMode.Impulse);

        var time = 0.0f;
        while (time < 1.0f)
        {
            time += Time.deltaTime;
            yield return null;
        }

        StartCoroutine(Move());
    }

    void RandomAction()
    {
        var random = Random.Range(0, 101);
        if (random < 60)
        {
            StartCoroutine(Move());
        }
        else if (random < 90)
        {
            StartCoroutine(BoostMove());
        }
        else if (random < 100)
        {
            StartCoroutine(Jump());
        }
    }

    //指定されたタグの中で最も近いものを取得
    GameObject serchTag(GameObject nowObj,string tagName){
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        //string nearObjName = "";    //オブジェクト名称
        GameObject targetObj = null; //オブジェクト

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in  GameObject.FindGameObjectsWithTag(tagName)){
            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis){
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
            }

        }
        //最も近かったオブジェクトを返す
        //return GameObject.Find(nearObjName);
        return targetObj;
    }
    
    void Attack()
    {
        right_weapon_.SetLayer(14);
        right_weapon_.CreateBullet();
        right_weapon_.SetReticle(player.gameObject);

        left_weapon_.SetLayer(14);
        left_weapon_.CreateBullet();
        left_weapon_.SetReticle(player.gameObject);
    }

}