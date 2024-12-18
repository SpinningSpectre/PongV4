using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnFireworks : MonoBehaviour
{
    [SerializeField] private Transform[] corners;
    [SerializeField] private Color[] fireworkColors;
    [SerializeField] private GameObject fireworkPrefab;
    [SerializeField] private float[] fireworkCooldowns;

    bool onCooldown = false;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!onCooldown)
        {
            spawnFirework();
            time = UnityEngine.Random.Range(fireworkCooldowns[0], fireworkCooldowns[1]);
            onCooldown = true;
        }
        if(time < 0)
        {
            onCooldown = false;
        }
        time -= Time.deltaTime;
    }

    private void spawnFirework()
    {
        float x = Math.Abs(corners[1].position.x) + Math.Abs(corners[0].position.x);
        float y = Math.Abs(corners[1].position.y) + Math.Abs(corners[0].position.y);
        float ranX = UnityEngine.Random.Range(0, x);
        float ranY = UnityEngine.Random.Range(0, y);
        Vector2 pos = new Vector2(ranX + corners[0].position.x, ranY + corners[0].position.y);
        GameObject firework = Instantiate(fireworkPrefab,pos, Quaternion.identity,this.transform);
        int col = UnityEngine.Random.Range(0,fireworkColors.Length);

        ParticleSystem particle = firework.GetComponent<ParticleSystem>();
        ParticleSystem.MainModule main = particle.main;
        main.startColor = new ParticleSystem.MinMaxGradient(fireworkColors[col], fireworkColors[col]);
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particle.particleCount];
    }
}
