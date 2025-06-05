using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class turn_page : MonoBehaviour
{
    [SerializeField] List<Texture2D> _textures;
    [SerializeField] RawImage _book_menu_1;
    [SerializeField] int index = 0;
    [SerializeField] int maxIndex = 2;
    [SerializeField] int minIndex = 0;
    [SerializeField] GameSceneManager _sceneManager;
    [SerializeField] Image gameImage;
    [SerializeField] TMP_Text title;
    [SerializeField] TMP_Text description;

    [SerializeField] string[] titles;
    [SerializeField] string[] descriptions;
    [SerializeField] Sprite[] gameImages;

    void Start()
    {
        _book_menu_1.texture = _textures[index];
    }

    public void pregress()
    {
        index = Mathf.Clamp(index + 1, minIndex, maxIndex);
        if (index < _textures.Count)
        {
            _book_menu_1.texture = _textures[index];
            UpdateComponents(index);
        }


    }
    public void regress()
    {
        index = Mathf.Clamp(index - 1, minIndex, maxIndex);
        if (index < _textures.Count)
        {
            _book_menu_1.texture = _textures[index];
            UpdateComponents(index);
        }

    }
    public void load_scene ()
    {

        if (index == 0) 
        {

            _sceneManager.ChangeScene("Lady Red light game");
                
         }

        if (index == 1)
        {

            _sceneManager.ChangeScene("Medical Medication Game");

        }

        if (index == 2)
        {

            _sceneManager.ChangeScene("Feminist Speech Game");

        }

    }
        
    public void UpdateComponents(int i)
    {
        gameImage.sprite = gameImages[i];
        title.text = titles[i];
        description.text = descriptions[i];
    }
    void Update()
    {
        
    }
}
