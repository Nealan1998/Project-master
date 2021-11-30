using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnimateText : MonoBehaviour
{
    public List<CanvasGroup> textHolder = new List<CanvasGroup>();
    public List<Text> textDisplayBox = new List<Text>();
    public List<string> dialogue = new List<string>();

    public string nextScene; //name of the next Scene
    int whichText = 0; // which string will be read
    int positionInString = 0; //which letter is being typed
    Coroutine textPusher; //so se can stop the coroutine


    // Start is called before the first frame update
    void Start()
    {
        textPusher = StartCoroutine(WriteTheText());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator WriteTheText()
    {
        for(int i = 0; i<= dialogue[whichText].Length; i++)
        {
            textDisplayBox[whichText].text = dialogue[whichText].Substring(0, i);
            positionInString++;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void ProceedText()
    {
        //haven't made it to the end of the string
        if(positionInString<dialogue[whichText].Length)
        {
            //stop typing Text
            StopCoroutine(textPusher);
            //show the full string
            textDisplayBox[whichText].text = dialogue[whichText];
            positionInString = dialogue[whichText].Length;

            //have completed the string
        }
        else
        {
            //hide text holder
            textHolder[whichText].alpha = 0;
            textHolder[whichText].interactable = false;
            textHolder[whichText].blocksRaycasts = false;

            //proceed to next string
            whichText++;
            
            // No more text boxes, go to next scene
            if(whichText>= textDisplayBox.Count)
            {
                SceneManager.LoadScene(nextScene);
            }

            // there are more text boxes, show them
            else
            {
                positionInString = 0;
                textHolder[whichText].alpha = 1;
                textHolder[whichText].interactable = true;
                textHolder[whichText].blocksRaycasts = true;
                textPusher = StartCoroutine(WriteTheText());
            }
            
        }
    }
}
