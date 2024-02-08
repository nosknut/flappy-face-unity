using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
/*
public class HandleTextFile
{
    static void WriteString()
    {
        string path = "Assets/Resources/test.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("Test");
        writer.Close();

        //Re-import the file to update the reference in the editor
        AssetDatabase.ImportAsset(path);
        TextAsset asset = Resources.Load("test");

        //Print the text from the file
        Debug.Log(asset.text);
    }
    
    static void ReadString()
    {
        string path = "Assets/Resources/test.txt";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }

}
*/
public class PointSystem : MonoBehaviour {

    public Text pointBox;
    public int highScore;
    public TextAsset file;
    public bool resetHighScore;
    int points;

	// Use this for initialization
	void Start () {
        getHScore();
    }

    void getHScore()
    {
        try
        {
            string _highScore = FRead();
            if (_highScore != "")
            {
                highScore = int.Parse(_highScore);
                Debug.Log("Aquired HighScore from file" + highScore);
            }
            else
            {
                Debug.Log("No prevous High Score");
            }
        }
        catch (System.FormatException e)
        {
            Debug.Log(e.Data);
        }

    }

    string FRead()
    {
        string info = "";
        try
        {
            StreamReader stream = new StreamReader(file.name); // "/setup");
            info = stream.ReadLine();
            stream.Close();
        }
        catch (FileLoadException e)
        {
            Debug.Log(e.Data);
        }
        return info;
    }

    void FWrite(string _text)
    {
        try
        {
            StreamWriter stream = new StreamWriter(file.name); // "/setup");
            Debug.Log("Storing new High Score: " + _text); // file.name);
            stream.Write(_text);
            stream.Close();
        }
        catch (FileLoadException e)
        {
            Debug.Log(e.Data);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        points ++;
        GameObject.Destroy(other);
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        points = 0;
    }


    // Update is called once per frame
    void Update () {
        if (points > highScore)
        {
            highScore = points;
            FWrite(highScore.ToString());

        }
        string info = (points.ToString() + " / " + highScore.ToString());
        pointBox.text = info;
        //pointBox.GetComponent<RectTransform>().position = new Vector2(((Screen.width / 2) - (500 / 2)), (pointBox.GetComponent<RectTransform>().position.y));
        if (resetHighScore) FWrite("0");

	}
}
