using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicPlayer : MonoBehaviour
{
    private void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.pitch = 1.0f;
    }
    public void pitchIncrease()
    {
       
        StartCoroutine("EnablePitchIncrease");
    }
    public void pitchDecrease()
    {
       
        StartCoroutine("EnablePitchDecrease");
    }

    IEnumerator EnablePitchIncrease()    // Coroutine for updating musicspeed when it hits fast block
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.pitch = 1.2f;
        yield return new WaitForSeconds(5.0f);
        audioSource.pitch = 1.0f;
    }

    IEnumerator EnablePitchDecrease()    // Coroutine for updating musicspeed when it hits Slow block
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.pitch = 0.7f;
        yield return new WaitForSeconds(5.0f);
        audioSource.pitch = 1.0f;
    }

    // Use this for initialization
    private void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;

        if (numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

   
    }




}
