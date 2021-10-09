using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(ParticleSystem))]
public class ParticleAttract : MonoBehaviour
{
    ParticleSystem starsParticle;
    ParticleSystem.Particle[] Particles;
    public Transform rocketTarget;
    public Transform sauronEye;
    public bool sauronEyeIsUp = false;
    public float speed = 5f;
    int numberStarsParticlesAlive;


    void Start()
    {
        starsParticle = GetComponent<ParticleSystem>();
        if(!GetComponent<Transform>()){
            GetComponent<Transform>();
        }
    }

    void Update()
    {
        Particles = new ParticleSystem.Particle[starsParticle.main.maxParticles];
        numberStarsParticlesAlive = starsParticle.GetParticles(Particles);
        float step = speed * Time.deltaTime;
        
        if (sauronEyeIsUp)
        {
            speed = 5f;
        }

        for(int i = 0; i < numberStarsParticlesAlive; i++){

            if (sauronEyeIsUp)
            {
                Particles[i].position = Vector3.LerpUnclamped(Particles[i].position, sauronEye.position, step);
            }
            else
            {
                Particles[i].position = Vector3.LerpUnclamped(Particles[i].position, rocketTarget.position, step);
            }
           
        }
        
        starsParticle.SetParticles(Particles, numberStarsParticlesAlive);

    }
}
