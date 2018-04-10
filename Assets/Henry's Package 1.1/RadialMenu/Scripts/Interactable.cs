using UnityEngine;
using System.Collections;

//Add this script to game objects with which you want to interact
public class Interactable : MonoBehaviour
{
    [System.Serializable]
    public class Action
    {
        public Color color;
        public Sprite sprite;
        public string title;
    }

    //title to appear on radial menu
    public string title;
    public Action[] options;

    void Start()
    {
        if (title == "" || title == null)
        {
            title = gameObject.name;
        }
    }

    void OnMouseDown()
    {
        RadialMenuSpawner.ins.SpawnMenu(this);
    }

}
