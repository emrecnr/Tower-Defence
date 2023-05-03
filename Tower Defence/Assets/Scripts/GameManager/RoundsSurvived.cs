using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundsSurvived : MonoBehaviour
{
    public TextMeshProUGUI roundText;
    void Start()
    {
        
    }

    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }
    IEnumerator AnimateText()
    {
        roundText.text = "0";
        int rounds = 0;
        yield return new WaitForSeconds(.6f);
        while (rounds<HealthSystem.rounds)
        {
            rounds++;
            roundText.text = rounds.ToString();
            yield return new WaitForSeconds(.5f);
        }

    }
}
