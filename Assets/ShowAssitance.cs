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

            AnimatorClipInfo[] clipInfo = assitanceAnimator.GetCurrentAnimatorClipInfo(0);
            if (clipInfo.Length > 0)
            {
                float animationLength = clipInfo[0].clip.length;
                Invoke("DestoyObject", animationLength + destroyDelay);
            }
            else
            {
                // Tidak ada informasi animasi yang tersedia
                DestoyObject();
            }

        }
    }

    void ActiveAnimator()
    {
        assistanceSpawn = Instantiate(assitance, spawnRobot.transform.position, spawnRobot.transform.rotation);
        assitanceAnimator.SetTrigger("HelloAnim");
        content.SetActive(true);
    }

    void DestoyObject()
    {
        Destroy(assistanceSpawn);
        content.SetActive(false);
    }


}
