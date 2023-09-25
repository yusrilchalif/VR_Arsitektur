using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShowAssitance : MonoBehaviour
{
    [SerializeField] GameObject assitance;
    private GameObject assistanceSpawn;
    [SerializeField] GameObject content;

    public Animator assitanceAnimator;
    public bool playerInside = false;
    public Transform spawnRobot;
    public float destroyDelay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerInside = true;
            print("check");
            if (spawnRobot != null)
            {
                ActiveAnimator();
                //Destroy(assistanceSpawn);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && playerInside)
        {
            assitanceAnimator.SetTrigger("EndedAnim");

            //wait until animator ended
            float animatorLength = assitanceAnimator.GetCurrentAnimatorClipInfo(0).Length;
            Destroy(assistanceSpawn, animatorLength + destroyDelay);
            
        }
    }

    void ActiveAnimator()
    {
        assistanceSpawn = Instantiate(assitance, spawnRobot.transform.position, Quaternion.identity);
        assitanceAnimator.SetTrigger("HelloAnim");
    }
}
