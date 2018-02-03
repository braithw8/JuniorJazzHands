using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalScale : MonoBehaviour {
    public string keyName;
    //public bool[] key = new bool[12];
    private bool[] major = { true, false, true, false, true, true, false, true, false, true, false, true };
    private bool[] minor = { true, false, true, true, false, true, false, true, true, false, true, false };

    
    
    
    
    // Use this for initialization
    void Awake () {
        bool[] key = minor;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
