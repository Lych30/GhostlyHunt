using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int MaxTrap;
    public static int StaticMaxTrap;
    public int MaxManifestation;
    public static int StaticMaxManifestation;
    public int MaxKey;
    public static int StaticMaxKey;
    public Shader defaultshader;
    public Sprite GreyTrap;
    public Sprite GreyManifestation;
    public Sprite GreyKey;

    public Text Key, Obstacles, Manifestation;

    private void Awake()
    {
        StaticMaxTrap = MaxTrap;
        StaticMaxManifestation = MaxManifestation;
        StaticMaxKey = MaxKey;
        UpdateUiText();
    }
    // Update is called once per frame
    void Update()
    {
       /* if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            var TouchPos = Camera.main.ScreenPointToRay(touch.position);

            RaycastHit2D hit = Physics2D.Raycast(TouchPos.origin,TouchPos.direction,Mathf.Infinity);
            if (hit)
            {
                Debug.Log(hit.transform.name);
                if (hit.transform.CompareTag("Trap"))
                {
                    hit.transform.GetComponent<TrapTest>().enabled = true;
                    
                }
            }
        }*/
    }
   
    public void UpdateUiText()
    {
        Key.text = StaticMaxKey.ToString();
        Obstacles.text = StaticMaxTrap.ToString();
        Manifestation.text = StaticMaxManifestation.ToString();
        if (StaticMaxKey <= 0)
        {
            GameObject.Find("KeyIcon").GetComponent<Image>().sprite = GreyKey;
        }
        if (StaticMaxManifestation <= 0)
        {
            GameObject.Find("ManifIcon").GetComponent<Image>().sprite = GreyManifestation;

        }
        if (StaticMaxTrap <= 0)
        {
            GameObject.Find("ObstaclesIcon").GetComponent<Image>().sprite = GreyTrap;
        }
    }
}
