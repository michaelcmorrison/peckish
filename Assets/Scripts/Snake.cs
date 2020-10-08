using System;
using System.Collections;
using UnityEngine;

public class Snake : MonoBehaviour, IDamage
{
    
    [SerializeField] private int damage;
    public int DamageAmount
    {
        get => damage;
        set => damage = value;
    }

    [SerializeField] private float slitherSpeed;
    [SerializeField] private float chargeSpeed;
    [SerializeField] private float chargeTime;
    [SerializeField] private Transform eyes;
    private bool _charging;

    void Update()
    {
        Physics2D.IgnoreLayerCollision(9,10, Birdie.IsFlying);
        
        if (!_charging && CheckIfCanSeePlayer())
        {
            StartCoroutine(Charge());
        }

        Move();
    }

    private void Move()
    {
        var speed = _charging ? chargeSpeed : slitherSpeed;
        transform.Translate(Vector3.left * (Time.deltaTime * speed));
    }

    private RaycastHit2D CastRayFromEyes()
    {
        RaycastHit2D hit = Physics2D.Raycast(eyes.position, eyes.TransformDirection(Vector2.left));
        return hit;
    }

    private bool CheckIfCanSeePlayer()
    {
        RaycastHit2D hit = CastRayFromEyes();
        
        if (hit && hit.collider.gameObject.CompareTag("Player"))
        {
            return !Birdie.IsFlying;
        }

        return false;
    }

    private IEnumerator Charge()
    {
        _charging = true;
        yield return new WaitForSeconds(chargeTime);
        _charging = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            transform.Rotate(Vector3.up, 180);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
