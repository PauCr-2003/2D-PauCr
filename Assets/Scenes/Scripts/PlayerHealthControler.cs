using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthControler : MonoBehaviour
{

    public int maxLives = 5;
    public int lives = 5;
    // Start is called before the first frame update
    void Start()
    {
        lives = maxLives;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage()
    {
        if (lives > 0) ;
            lives = lives - 1;

        PlayerAudioController hAudio = gameObject.GetComponent<PlayerAudioController>();
        hAudio.Damage();
        Debug.Log("The player has taken damage");
    }

    internal void Regenerate()
    {
        throw new NotImplementedException();
    }
}