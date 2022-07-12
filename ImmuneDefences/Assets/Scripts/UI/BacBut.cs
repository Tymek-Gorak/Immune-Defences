using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class BacBut : MonoBehaviour
{
    [SerializeField] private int butNum;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown((KeyCode) 48 + butNum)){
            transform.GetComponent<Button>().OnSubmit(null);
            Wrapper();
        }
    }

    public void Wrapper() {
        SoundManager.soundInstance.Play("selectUnit");
        StartCoroutine("clicked");
    }


    private IEnumerator clicked(){
        yield return 0;
        yield return 0;
        EventManager.bacSelect = butNum;
        EventManager.clicked = true;
    }
}
