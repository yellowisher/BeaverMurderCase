using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeaverMurderCase
{
    public class PageScript_Title_bar : MonoBehaviour
    {

        // Update is called once per frame
        void Update()
        {
            if (Dialogue.DialogueManager.Instance._allTextShowed) {
                gameObject.GetComponent<Animator>().enabled = false;
            }
            else {
                gameObject.GetComponent<Animator>().enabled = true;
            }
        }
    }
}
