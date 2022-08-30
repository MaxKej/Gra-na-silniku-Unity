using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruch : MonoBehaviour
{
    Rigidbody rakieta;
    AudioSource silnik;

    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainBooster;
    [SerializeField] ParticleSystem Booster1;
    [SerializeField] ParticleSystem Booster2;

    [SerializeField] float predkosc = 1000f;
    [SerializeField] float rotacja = 250f;

    void Start()
    {
        rakieta = GetComponent<Rigidbody>();
        silnik = GetComponent<AudioSource>();
    }

    void Update()
    {
        Stery();
        Naped();
    }

    void Naped()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            OdpalSilnik();
        }
        else
        {
            WylaczSilnik();
        }
    }

    void Stery()
    {
        if(Input.GetKey(KeyCode.A))
        {
            PrawySter();
        }
        else if(Input.GetKey(KeyCode.D))
        {
            LewySter();
        }
        else
        {
            WylaczStery();
        }
    }

    void OdpalSilnik()
    {
        rakieta.AddRelativeForce(Vector3.up * predkosc * Time.deltaTime);
        if(!silnik.isPlaying)
        {
            silnik.PlayOneShot(mainEngine);
        }
        if(!mainBooster.isPlaying)
        {
            mainBooster.Play();
        }
    }

    void WylaczSilnik()
    {
        silnik.Stop();
        mainBooster.Stop();
    }

    void PrawySter()
    {
        Rotacja(rotacja);
        if(!Booster1.isPlaying)
        {
            Booster1.Play();
        }
    }

    void LewySter()
    {
        Rotacja(-rotacja);
        if(!Booster2.isPlaying)
        {
            Booster2.Play();
        }
    }

    void WylaczStery()
    {
        Booster1.Stop();
        Booster2.Stop();
    }

    void Rotacja(float obrot)
    {
        rakieta.freezeRotation = true;
        transform.Rotate(Vector3.forward * obrot * Time.deltaTime);
        rakieta.freezeRotation = false;
    }
}
