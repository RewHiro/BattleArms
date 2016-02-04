using UnityEngine;
using System.Collections;

public class BeamShot : Weapon {
	
	float timer = 0.0f;
	float effectDisplayTime = 0.2f;
	float range = 100.0f;
	Ray shotRay;
	RaycastHit shotHit;  
	ParticleSystem beamParticle;
	LineRenderer lineRenderer;

    [SerializeField]
    GameObject explosion_effect_ = null;

    SoundManager sound_manager_ = null;

    float POWER = 0.0f;

    bool is_shot_ = false;
	
	// Use this for initialization
	void Awake () {
		beamParticle = GetComponent<ParticleSystem> ();
		lineRenderer = GetComponent<LineRenderer> ();

        var parameter = FindObjectOfType<RocketLauncherParameter>();
        if (parameter == null) return;
        POWER = parameter.GetAttackPower(0);
	}

    void Start()
    {
        sound_manager_ = FindObjectOfType<SoundManager>();
    }
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= effectDisplayTime) {
			disableEffect ();
		}
	}

    public override void OnAttack()
    {
        if (!is_shot_)
        {
            sound_manager_.PlaySE(9);
            is_shot_ = true;
        }
        shot();
        base.OnAttack();
    }

    public override void OnNotAttack()
    {
        is_shot_ = false;
        base.OnNotAttack();
    }

    private void shot(){
		timer = 0f;
		beamParticle.Stop ();
		beamParticle.Play ();
		lineRenderer.enabled = true;

        var direction = Reticle.gameObject.transform.position - transform.position;
        direction.Normalize();

        transform.rotation =
        Quaternion.LookRotation(direction, Vector3.up);

        lineRenderer.SetPosition (0, transform.position);
		shotRay.origin = transform.position;
		shotRay.direction = transform.forward;
		if(Physics.Raycast(shotRay , out shotHit , range))
        {
            // hit
            var collider = shotHit.collider;
            if (collider.tag == "Enemy")
            {
                var effect = Instantiate(explosion_effect_);
                effect.transform.position = shotHit.point;
                collider.GetComponent<HPManager>().Damage(POWER);
            }
             
		}
		lineRenderer.SetPosition(1 , shotRay.origin + shotRay.direction * range);
		
		
	}
	
	private void disableEffect(){
		beamParticle.Stop ();
		lineRenderer.enabled = false;
	}
}