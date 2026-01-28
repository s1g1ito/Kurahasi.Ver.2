using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class idouSE : MonoBehaviour
{
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound4;

    private AudioSource audioA;
    private AudioSource audioD;
    private AudioSource audioMouseButton;
    private AudioSource audioSpace;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // AudioSourceをキーごとに4つ作成
        audioA = gameObject.AddComponent<AudioSource>();
        audioA.clip = sound1;
        audioA.loop = true;

        audioD = gameObject.AddComponent<AudioSource>();
        audioD.clip = sound2;
        audioD.loop = true;

        audioMouseButton = gameObject.AddComponent<AudioSource>();
        audioMouseButton.clip = sound3;


        audioSpace = gameObject.AddComponent<AudioSource>();
        audioSpace.clip = sound4;

    }

    void Update()
    {
        // Aキー
        if (Input.GetKeyDown(KeyCode.A)) audioA.Play();
        if (Input.GetKeyUp(KeyCode.A)) audioA.Stop();

        // Dキー
        if (Input.GetKeyDown(KeyCode.D)) audioD.Play();
        if (Input.GetKeyUp(KeyCode.D)) audioD.Stop();

        if (Input.GetMouseButtonDown(0)) audioMouseButton.Play();


        // Spaceキー
        if (Input.GetKeyDown(KeyCode.Space)) audioSpace.Play();

    }
}
