using System.Collections.Generic;
using NUnit.Framework;
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

    void Start()
    {
        _book_menu_1.texture = _textures[index];
    }

    public void progress()
    {
        index = Mathf.Clamp(index + 1, minIndex, maxIndex);
        if (index < _textures.Count)
        {
            _book_menu_1.texture = _textures[index];
        }

    }
    public void regress()
    {
        index = Mathf.Clamp(index - 1, minIndex, maxIndex);
        if (index < _textures.Count)
        {

            _book_menu_1.texture = _textures[index];

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
        
   
    void Update()
    {
        
    }
}
