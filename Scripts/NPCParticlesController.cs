using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCParticlesController : MonoBehaviour
{
    [SerializeField]
    ParticleSystem NPCParticles;
    // Start is called before the first frame update
    void Start()
    {
        NPCParticles.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
