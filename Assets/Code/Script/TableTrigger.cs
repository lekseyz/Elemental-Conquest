using UnityEngine;
using UnityEngine.UI;

public class TableTrigger : MonoBehaviour
{
    public Transform player; 
    public GameObject infoImage; 

    public float triggerDistance = 3f; 

    private bool playerInRange = false; 

    private void Update()
    {
       
        float distance = Vector3.Distance(transform.position, player.position);

        
        if (distance <= triggerDistance)
        {
            
            if (!playerInRange)
            {
               
                infoImage.SetActive(true);
                playerInRange = true;
            }
        }
        else
        {
            if (playerInRange)
            {
                infoImage.SetActive(false);
                playerInRange = false;
            }
        }
    }
}
