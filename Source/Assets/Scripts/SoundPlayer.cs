using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audio;
    // Start is called before the first frame update
    void Start()
    {
        _audio = gameObject.GetComponent<AudioSource>();
    }
    public void PlaySound()
    {
        _audio.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
