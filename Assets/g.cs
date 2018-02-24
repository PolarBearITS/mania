using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class g : MonoBehaviour {
    public static float rec_x = -2;
    public static float rec_y = 0;
    public static string rec_path = "stepmania/dance/receptor/";
    public static string rec_hitsound = "bassdrum";
    public static float col_spacing = 0.04f;
    public static float col_width = 1.28f;
    public static string[] keys = { "d", "f", "j", "k" };
    public static bool setup_done = false;

    // Use this for initialization
    void Start()
    {
        song s = new song("keeno - glow", "4K Easy");
        setup_done = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
