using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    public bool end = false;

    private int index;
    
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        
        if(!end)
        {
            StartCoroutine(Delete());
        }
    }
    IEnumerator Delete()
    {
        yield return new WaitForSeconds(2f);
        
        Destroy(gameObject);
    }
}
