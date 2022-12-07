using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;

    private void Awake()
    {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        /*highscoreEntryList = new List<HighscoreEntry>()
        {
            new HighscoreEntry{score = 523321, name = "AAA"},
            new HighscoreEntry{score = 126151, name = "CAT"},
            new HighscoreEntry{score = 156512, name = "NGN"},
            new HighscoreEntry{score = 54365, name = "LUK"},
            new HighscoreEntry{score = 988554, name = "TOM"},
            new HighscoreEntry{score = 3385, name = "XAR"},
            new HighscoreEntry{score = 445766, name = "DAS"},
            new HighscoreEntry{score = 713245, name = "MAX"},
        };*/

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        // Esto habría que reemplazarlo con el Quicksort
        for (int i = 0; i < highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscoreEntryList.Count; j++)
            {
                if (highscoreEntryList[j].score > highscoreEntryList[i].score)
                {
                    //Swap
                    HighscoreEntry temporal = highscoreEntryList[i];
                    highscoreEntryList[i] = highscoreEntryList[j];
                    highscoreEntryList[j] = temporal;
                }
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }

        
        /*Highscores highscores = new Highscores { highscoreEntryList = highscoreEntryList};
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("highscoreTable"));*/
        
    }


    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 50f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;

        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;
    
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;



        }

        entryTransform.Find("posText").GetComponent<Text>().text = rankString;
        
        int score = highscoreEntry.score;

        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

        string name = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);
    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }


    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }
}
