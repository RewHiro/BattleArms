using System.Collections.Generic;
using UnityEngine;

public class GatlingGun : Weapon
{
    Animator animator_ = null;

    [SerializeField]
    float Speed = 100;//速度

    BulletCreater bullet_creater_ = null;
    Vector3 origin_pos_ = Vector3.zero;

    [SerializeField]
    GameObject spark_prefab_ = null;

    [SerializeField]
    Material left_material_ = null;

    [SerializeField]
    Material right_material_ = null;

    SoundManager sound_manager_ = null;

    float shot_count_ = 0.2f;
    float over_heat_count_ = 0.0f;
    float cool_down_ = 0.0f;

    bool is_ready_ = true;

    float POWER = 0.0f;

    readonly int LOOP_STATE_HASH = Animator.StringToHash("Loop");
    readonly int IDLE_STATE_HASH = Animator.StringToHash("Idle");

    static bool is_left_ = false;

    void Awake()
    {
        var color = 128.0f / 255.0f;
        right_material_.color = new Color(color, color, color);
        left_material_.color = new Color(color, color, color);
    }

    void Start()
    {
        bullet_creater_ = FindObjectOfType<BulletCreater>();
        var parameter = FindObjectOfType<GatlingGunParameter>();
        if (parameter == null) return;
        POWER = parameter.GetAttackPower(0);
        sound_manager_ = FindObjectOfType<SoundManager>();

        animator_ = GetComponent<Animator>();

        if (is_left_)
        {
            foreach (var renderer in GetComponentsInChildren<MeshRenderer>())
            {
                renderer.material = right_material_;
            }
        }
        is_left_ = true;
    }

    void Update()
    {

        var material = is_left_ ? right_material_ : left_material_;

        var color = 128.0f / 255.0f;
        var diff_color = 255.0f - 128.0f;
        var red = 128.0f + diff_color * over_heat_count_ / 20.0f;
        material.color = new Color(red / 255.0f, color, color);

        over_heat_count_ -= Time.deltaTime;

        if (over_heat_count_ < 0.0f)
        {
            over_heat_count_ = 0.0f;
        }

        if (is_ready_) return;

        cool_down_ += Time.deltaTime;

        if (cool_down_ <= 5.0f) return;
        is_ready_ = true;
        cool_down_ = 0.0f;
        over_heat_count_ = 0.0f;
    }

    public override bool CanShot()
    {
        return shot_count_ <= 0.0f;
    }

    public override IEnumerable<GameObject> CreateBullet()
    {
        List<GameObject> bullets = new List<GameObject>();
        var obj = Instantiate(FindObjectOfType<BulletCreater>().getGutringBullet);
        obj.transform.position = gameObject.transform.position;
        obj.transform.Translate(gameObject.transform.forward);
        obj.transform.rotation = gameObject.transform.rotation;
        obj.transform.Rotate(0, -90, 0);
        Vector3 force;

        var reticle_position = Reticle.transform.position;

        var direction = (reticle_position - transform.position).normalized;

        const float diff = 0.1f;

        var random = new Vector3(Random.Range(-diff, diff), Random.Range(-diff, diff), Random.Range(-diff, diff));

        force = (direction + random) * 300;
        obj.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);

        obj.layer = layer_;

        Destroy(obj, 3.0f);

        obj.GetComponent<BulletPower>().SetPower(POWER);

        bullets.Add(obj);

        sound_manager_.PlaySE(7);

        return bullets;
    }

    public override void OnAttack()
    {
        base.OnAttack();

        if (animator_.GetCurrentAnimatorStateInfo(0).shortNameHash == IDLE_STATE_HASH)
        {
            animator_.SetTrigger("Start");
        }

        if (animator_.GetCurrentAnimatorStateInfo(0).shortNameHash != LOOP_STATE_HASH) return;

        if (!is_ready_) return;

        over_heat_count_ += Time.deltaTime * 2;


        if (shot_count_ <= 0.0f)
        {
            shot_count_ = 0.02f;

            if (origin_pos_ == Vector3.zero)
            {
                origin_pos_ = WeaponObject.transform.localPosition;
            }
            spark_prefab_.SetActive(true);
            var diff = 0.01f;
            var random = new Vector3(Random.Range(-diff, diff), Random.Range(-diff, diff), 0.0f);
            WeaponObject.transform.localPosition = origin_pos_ + random;
        }
        shot_count_ -= Time.deltaTime;

        if (over_heat_count_ > 20.0f)
        {
            is_ready_ = false;
            shot_count_ = 0.02f;
        }
    }

    public override void OnNotAttack()
    {
        base.OnNotAttack();

        animator_.SetTrigger("Stop");
        shot_count_ = 0.2f;
        spark_prefab_.SetActive(false);
    }
}
