using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RollResults : MonoBehaviour
{
    public TMPro.TextMeshProUGUI SuccessState, SuccessCount;
    public Image successTint, failureTint, bestial, messy, failure, success;
    

    public void RollResultsStart(bool Success, int successCount, bool hunger)
    {
        StartCoroutine(UpdateUI(Success, successCount, hunger));
    }

    public IEnumerator UpdateUI(bool Success, int successCount, bool hunger)
    {
        SuccessCount.enabled = true;
        SuccessCount.text = successCount.ToString();
        
        if (Success)
        {
            successTint.enabled = true;
            SuccessState.enabled = true;
            SuccessState.text = "Success!";
            

            if (hunger)
            {
                messy.enabled = true;
            }
            else
            {
                success.enabled = true;
            }
        }
        else
        {
            failureTint.enabled = true;
            SuccessState.enabled = true;
            SuccessState.text = "Failure!";
            
            if(hunger)
            {
                bestial.enabled = true;
            }
            else
            {
                failure.enabled = true;
            }
        }

        yield return new WaitForSeconds(2f);

        successTint.enabled = false;
        failureTint.enabled = false;
        bestial.enabled = false;
        messy.enabled = false;
        failure.enabled = false;
        success.enabled = false;
        SuccessCount.enabled = false;
        SuccessState.enabled = false;
        
    }
}
