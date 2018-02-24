using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class receptor : MonoBehaviour {
    int n;
    string key;
    int receptor_state = 0;
    bool held = false;
    string hit_path = "";
    AudioSource asr;
    Sprite[] imgs = new Sprite[2];

	void Start () {
        while (!g.setup_done)
        {
            continue;
        }
        n = int.Parse(gameObject.name.Replace("receptor", ""));
        key = g.keys[n - 1];
        asr = GetComponent<AudioSource>();
        hit_path = song.path + g.rec_hitsound;
        AudioClip c = Resources.Load(hit_path, typeof(AudioClip)) as AudioClip;
        asr.clip = c;
        print(song.path);
        for (int i = 0; i < 2; i++)
        {
            imgs[i] = Resources.Load(g.rec_path + n + "_" + i, typeof(Sprite)) as Sprite;
        }
        gameObject.transform.position = new Vector2(g.rec_x + g.col_width*(n-1), g.rec_y);
    }
        
    private void Update()
    {
        if (Input.GetKeyDown(key))
        {
            receptor_state = 1;
        }
        if (Input.GetKeyUp(key))
        {
            receptor_state = 0;
            held = false;
        }
    }
    void FixedUpdate () {
        gameObject.GetComponent<SpriteRenderer>().sprite = imgs[receptor_state];
        if (receptor_state == 1 && !held)
        {
            asr.Play();
            held = true;
        }
	}
}
