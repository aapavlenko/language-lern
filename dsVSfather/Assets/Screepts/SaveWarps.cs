using UnityEngine;
using System.IO;
using System.Collections.Generic;

public  class SaveWarps : MonoBehaviour
{
    [SerializeField] private Warper warper;
    private string path;

    private void Start()
    {
#if UNITY_ANDEOID && !UNITY_EDITOR
        path = Path.Combine(Application.persistentDataPath, "Save.json");
#else
        path = Path.Combine(Application.dataPath, "Save.json");
#endif
        LoadField(path);
    }

    [ContextMenu("Save")]
    public void SaveField(string path,Warper warper)
    {
        File.WriteAllText(path, JsonUtility.ToJson(warper));
    }
    [ContextMenu("Load")]
    public Warper LoadField(string path)
    {
        if (File.Exists(path))
        {
            warper = JsonUtility.FromJson<Warper>(File.ReadAllText(path));
        }
        else
        {
            Debug.LogError("нету файла\n" + path);
        }
        return warper;
    }
}


[System.Serializable]
public class Warper
{
    public Dictionary<string,string[]> warps;
}
