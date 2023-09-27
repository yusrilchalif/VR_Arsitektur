using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] List<Sprite> sprites;
    [SerializeField] Image image;
    [SerializeField] Button nextBtn, prevBtn;

    private int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        ShowImage(currentIndex);

        nextBtn.onClick.AddListener(NextImage);
        prevBtn.onClick.AddListener(PrevImage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowImage(int index)
    {
        image.sprite = sprites[index];
    }

    public void NextImage()
    {
        currentIndex++;

        if(currentIndex >= sprites.Count)
        {
            currentIndex = sprites.Count - 1;
        }
        ShowImage(currentIndex);
    }

    public void PrevImage()
    {
        currentIndex--;

        if(currentIndex < 0)
        {
            currentIndex = 0;
        }
        ShowImage(currentIndex);
    }
}
