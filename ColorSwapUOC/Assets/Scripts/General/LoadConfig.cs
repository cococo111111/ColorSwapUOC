using UnityEngine;
using System.IO;
using System;

public class LoadConfig : MonoBehaviour {

    public static LoadConfig Instance;
    private string configFileName;
    private string fileName;

	// Use this for initialization
	void Awake ()
    {
        DontDestroyOnLoad(this.gameObject);
        Instance = this;
        configFileName = GlobalInfo.configFile;
        fileName = Path.Combine(Application.persistentDataPath, "data");
        fileName = Path.Combine(fileName, configFileName + ".txt");
        if (!File.Exists(fileName))
        {
            PlayerInfo saveData = new PlayerInfo();
            //Save data from PlayerInfo to a file named players
            DataSaver.saveData(saveData, configFileName);
            GlobalInfo.gameFirstTime = "true";
            GlobalInfo.soundPlay = "true";
            GlobalInfo.maxScore = 0.ToString();
            GlobalInfo.coins = 0.ToString();
        } 
        else
        {
            Debug.Log("AQUI");
            PlayerInfo loadedData = DataSaver.loadData<PlayerInfo>(configFileName);
            if (loadedData == null)
            {
                return;
            }
            GlobalInfo.version = Application.version;
            GlobalInfo.maxScore = Decryptor.Decrypt(loadedData.maxScore);
            Debug.Log("MaxScore:" + GlobalInfo.maxScore);
            GlobalInfo.coins = Decryptor.Decrypt(loadedData.coins);
            Debug.Log("Coins: " + GlobalInfo.coins);
            GlobalInfo.soundPlay = Decryptor.Decrypt(loadedData.soundPlay);
            Debug.Log("Sound: " + GlobalInfo.soundPlay);
            for (int i = 0; i < loadedData.cards.Count; i++)
            {
                Debug.Log("Cards: " + loadedData.cards[i]);
                GlobalInfo.cards.Add(loadedData.cards[i]);
            }
            
            GlobalInfo.gameFirstTime = "false";
            if (Decryptor.Decrypt(loadedData.gameFirstTime) != "")
            {
                GlobalInfo.gameFirstTime = "false";
            } 

        }
    }

    public void SaveDataGame()
    {
        PlayerInfo saveData = new PlayerInfo();
        saveData.version = Decryptor.Encrypt(Application.version);
        saveData.maxScore = Decryptor.Encrypt(GlobalInfo.maxScore);
        saveData.coins = Decryptor.Encrypt(GlobalInfo.coins);
        saveData.soundPlay = Decryptor.Encrypt(GlobalInfo.soundPlay);
        saveData.cards = GlobalInfo.cards;
        //Save data from PlayerInfo to a file named players
        DataSaver.saveData(saveData, configFileName);
}
}
