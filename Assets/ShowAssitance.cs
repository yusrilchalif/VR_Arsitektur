using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAssitance : MonoBehaviour
{
    [SerializeField] GameObject assitance;
    private GameObject assistanceSpawn;
    [SerializeField] GameObject content;

    public Animator assitanceAnimator;
    public bool isActive = false;
    public Transform spawnRobot;

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
            print("check");
            ActiveAnimator();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            print("uncheck");
            if(spawnRobot != null)
            {
                Destroy(assistanceSpawn);
            }
        }
    }

    void ActiveAnimator()
    {
        //    assitance.SetActive(true);
        //    content.SetActive(true);
        isActive = true;
        assistanceSpawn = Instantiate(assitance, spawnRobot.transform.position, Quaternion.identity);
    }

    void DeactiveAnimator()
    {
        Destroy(assitance);
        content.SetActive(false);
    }
}
