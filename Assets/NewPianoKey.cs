using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class NewPianoKey : MonoBehaviour {
    private AudioSource notePlayer;
    public int intervalFromA;
    public int octaveFromA4;
    public GameObject keysystem;
    private int midiNoteNumber;
    
    private bool notePlaying = false;
    private float interval;
    private float PianoPitcher;
    private bool ballTouching;
    private bool keyPlaying;
    private bool ballPlaying;
    private GlobalScale globalKey;



    //public int octave;
    void Awake()
    {
        globalKey = keysystem.GetComponent<GlobalScale>();
    }

    // Use this for initialization
    void Start() {

        interval = octaveFromA4 * 12 + intervalFromA;
        float midiFloat = 57 + interval;
        midiNoteNumber = (int)midiFloat;

        MeshRenderer myMeshRenderer = GetComponent<MeshRenderer>();

        notePlayer = GetComponent<AudioSource>();
        float noteRelation = interval / 12;
        PianoPitcher = Mathf.Pow(2, noteRelation);
        notePlayer.pitch = PianoPitcher;
        Debug.Log(PianoPitcher); ;
        int trueInterval = intervalFromA + 9;

        
        bool[] key = globalKey.key;
        bool inKey = key[trueInterval];

  
        if (inKey == false)
        {
            myMeshRenderer.enabled = false;
        }

    }
	
	// Update is called once per frame
	void Update () {
        //notePlayer.pitch = PianoPitcher + (MidiMaster.GetKnob(0, 63));

        if (MidiMaster.GetKey(midiNoteNumber) > 0 && keyPlaying == false)
        {
            notePlay();
            keyPlaying = true;
                }
        else if (MidiMaster.GetKey(midiNoteNumber) == 0 && keyPlaying == true)
        {
            noteStop();
           keyPlaying = false;
        }

        else if (ballTouching == true && ballPlaying == false)
        {
            Debug.Log("touching");
            notePlay();
            ballPlaying = true;
        }

        else if (ballTouching == false && ballPlaying == true)
        {
            Debug.Log("not touching");
            noteStop();
            ballPlaying = false;
            
        }

    }

    void OnCollisionStay(Collision collision)
    {

        ballTouching = true;




    }

    void OnCollisionExit(Collision collision)
    {
        ballTouching = false;

    }



        void notePlay()
        {
            notePlayer.Play();
            GetComponent<Animator>().SetBool("down", true);
        notePlaying = true;


        Debug.Log("playing a note");

        }

        void noteStop()
        {
            notePlayer.Stop();
            GetComponent<Animator>().SetBool("down", false);
        notePlaying = false;


    }


    }
