using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;




public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public string newPlayerName;

    public int currentHighScore;

    public string currentHighPlayer;

    public static int currentscore;
    



    private void Awake()
    {
        
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        
    }

    // Start is called before the first frame update
    void Start()
    {
        loadData();
        PlayerData data2 = new PlayerData();
        Debug.Log(data2.scoreJson);
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void replaceData()
    {
        if (currentscore > currentHighScore)
        {
             currentHighScore = currentscore;
            currentHighPlayer = newPlayerName;

            PlayerData data = new PlayerData();
            
            data.scoreJson = currentHighScore;
            data.nameJson = currentHighPlayer;

            Debug.Log("score : " + data.scoreJson);

            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }


    }

    public void loadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            //GameManager.Instance.currentHighScore = data.scoreJson;

            //GameManager.Instance.currentHighPlayer = data.nameJson;

            currentHighScore = data.scoreJson;
            currentHighPlayer = data.nameJson;
        }

        Debug.Log("Data Loaded Successfully ");
    }
}


    

   

   

