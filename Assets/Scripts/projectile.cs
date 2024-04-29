using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{


    public float speed = 10f;

    public float rotation = 0f;

    [SerializeField]
    float totalKnockbackTime = 0.1f,
        knockbackMultiplier = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D r = GetComponent<Rigidbody2D>();
        r.velocity = transform.right * speed; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Ground"))
        {
            if (other.gameObject.tag == "Player" && health.Instance.playerHealth > 0)
            {
                PlayerController.Instance.knockbackCounter = totalKnockbackTime;
                PlayerController.Instance.knockbackMultiplier = knockbackMultiplier;

                if (other.transform.position.x <= transform.position.x)
                {
                    PlayerController.Instance.knockbackDirection = true;

                }
                if (other.transform.position.x > transform.position.x)
                {
                    PlayerController.Instance.knockbackDirection = false;
                }
                health.Instance.damage();

            };
            Destroy(gameObject);
        }
    }


}
