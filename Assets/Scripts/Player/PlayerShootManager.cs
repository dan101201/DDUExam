﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootManager : MonoBehaviour
{
    public GameObject shoot;
    public FireballStats stats;
    public Color color = Color.red;

    public float spread = 90;

    float canShoot;
    

    // Start is called before the first frame update
    void Start()
    {
        canShoot = stats.ReloadSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
        canShoot -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot <= 0f)
        {
            canShoot = stats.ReloadSpeed;
            float angle = spread/stats.Shots;
            for (int i = 1; i <= stats.Shots; i++)
            {
                Debug.Log("Fire!");
                GameObject newShoot = Instantiate(shoot, transform.position, transform.rotation);
                var temp = transform.rotation.eulerAngles;
                newShoot.transform.rotation = Quaternion.Euler(temp.x,temp.y-(spread/2+angle/2) + angle*i,temp.z);
                newShoot.GetComponent<Rigidbody>().velocity = newShoot.transform.forward * stats.FlySpeed;
                newShoot.GetComponent<FireBallEffect>().StartShot(stats);
                PlayAudio();
            }
        }

        
    }

    public AudioClip audioSource;
    private AudioSource source;
    public void PlayAudio() {
        if (source is null) source = transform.GetComponent<AudioSource>();
        source.clip = audioSource;
        source.Play();
    }

    public void PlayAudio(AudioClip clip) {
        if (source is null) source = transform.GetComponent<AudioSource>();
        source.clip = clip;
        source.Play();
    }


    public void AddStats(FireballStats modifier) {
        stats.FlySpeed *= modifier.FlySpeed;
        stats.TimeAlive *= modifier.TimeAlive;
        stats.ExplosionSize *= modifier.ExplosionSize;
        stats.ReloadSpeed *= modifier.ReloadSpeed;
        stats.fireBallSize *= modifier.fireBallSize;
        stats.damage *= modifier.damage;
        stats.Accuracy *= modifier.Accuracy;
        stats.Shots += modifier.Shots;
        stats.color = modifier.color;
    }
}
