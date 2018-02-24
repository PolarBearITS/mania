using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using UnityEngine;

public class song : MonoBehaviour {

    StreamReader f;
    string[] sections = { "[General]", "[Editor]", "[Metadata]", "[Difficulty]", "[Events]", "[TimingPoints]", "[HitObjects]"};
    public static string path;

    public song(string map, string diff)
    {
        path = "Assets/" + map + "/";
        string diff_path = path + map + " [" + diff + "].osu";
        string[] lines = File.ReadAllLines(diff_path);
        Hashtable vars = new Hashtable();
        string section = "";
        int section_index = -1;
        foreach(string line in lines)
        {
            if(line == "") continue;

            int header_index;
            if ((header_index = Array.IndexOf(sections, line)) != -1){
                section = line.Substring(1, line.Length-2);
                section_index = header_index;
            } else
            {
                if (section_index > 0 && section_index < 4)
                {
                    String[] var = line.Split(':');
                    vars[var[0]] = var[1];
                    //print(section + " " + section_index + " -- " + var[0] + "," + var[1]);
                }
            }
        }
        foreach(DictionaryEntry var in vars)
        {
            print(var.Key + "," + var.Value);
        }
    }
}
