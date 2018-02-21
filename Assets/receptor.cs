using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class receptor : MonoBehaviour {
    int n;
    string key;
    int receptor_state;
    Sprite[] imgs = new Sprite[2];

	void Start () {
        n = int.Parse(gameObject.name.Replace("receptor", ""));
        receptor_state = 0;
        key = g.keys[n - 1];
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
        }
    }
    void FixedUpdate () {
        gameObject.GetComponent<SpriteRenderer>().sprite = imgs[receptor_state];
	}
}
