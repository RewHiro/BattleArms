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
	
	// Use this for initialization
	void Awake () {
		beamParticle = GetComponent<ParticleSystem> ();
		lineRenderer = GetComponent<LineRenderer> ();
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
        shot();
        base.OnAttack();
    }

    private void shot(){
		timer = 0f;
		beamParticle.Stop ();
		beamParticle.Play ();
		lineRenderer.enabled = true;

        var direction = Reticle.gameObject.transform.position - transform.position;
        direction.Normalize();

        transform.rotation = 
        Quaternion.FromToRotation(transform.forward, direction);

		lineRenderer.SetPosition (0, transform.position);
		shotRay.origin = transform.position;
		shotRay.direction = transform.forward;
		
		int layerMask = 0;
		if(Physics.Raycast(shotRay , out shotHit , range , layerMask))
        {
            // hit
             
		}
		lineRenderer.SetPosition(1 , shotRay.origin + shotRay.direction * range);
		
		
	}
	
	private void disableEffect(){
		beamParticle.Stop ();
		lineRenderer.enabled = false;
	}
}