using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public float range;
    bool grounded=true;
    public bool hasBarked = false;
    public float barkTimer;
    float hopHeight=5.0f;
    Vector3 hopDirection;

    [SerializeField]
    Rigidbody NPCRigidBody;

    public GameObject playerReference;

    void Start()
    {
        grounded = true;
        hopDirection.Set(0.0f, hopHeight, 0.0f);
    }

    void Update()
    {
        HopAnimation();
        Bark();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Floor"&&!grounded)
        {
            grounded=true;
        }
    }

    void HopAnimation()
    {
        if(grounded)
        {
            NPCRigidBody.AddForce(hopDirection, ForceMode.Impulse);
            grounded=false;
        }
    }

    void Bark()
    {
        float distance = CalculateDistanceToPlayer();

        if (!hasBarked)
        {
            if (distance <= range)
            {
                float volume = 1 / (distance + 1);
               // AudioController.getSingleton().PlaySFX(SoundClipId.SFX_BARK, transform.position,volume,1,0);
            }

            barkTimer = 0;
            hasBarked = true;
        }

        else
        {
            barkTimer += Time.deltaTime;

            if(barkTimer >= 2)
            {
                hasBarked = false;
            }
        }
    }

    float CalculateDistanceToPlayer()
    {
        return Vector3.Distance(playerReference.transform.position, transform.position);
    }
}
