using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearArea : MonoBehaviour
{

    public float timeSinceLastTrigger = 0f;
    private int numberObjectsCollided = 0;
    private bool notFoundClearArea = false;

    // Update is called once per frame
    void Update()
    {
        timeSinceLastTrigger += Time.deltaTime;
        if(numberObjectsCollided == 0 && timeSinceLastTrigger > 1f && !notFoundClearArea)
        {
            SendMessageUpwards("OnFindClearArea"); // u objektima iznad sebe u hijerarhiji trazi funkciju OnfindClearArea
            notFoundClearArea = true;
        }
    }




    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            return;
        }
        numberObjectsCollided++;
        timeSinceLastTrigger = 0f;

        //if(other.gameObject.name == "Helicopter")
        //{
        //    print("dela");
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            return;
        }
        numberObjectsCollided--;
        timeSinceLastTrigger = 0f;
    }


}
