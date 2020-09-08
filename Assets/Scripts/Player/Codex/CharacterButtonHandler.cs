using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButtonHandler : MonoBehaviour
{
    [Header("Character Information")]
    [SerializeField] private Image charImage;
    [SerializeField] private Text charText;
    [SerializeField] private GameObject descriptionBox;
    [SerializeField] private Image[] spellImages;
    [SerializeField] private Sprite[] elementIcons;
    [SerializeField] private Text[] runeCounters;

    [Header("Timers")]
    [SerializeField] private float buttonCooldown;


    private CharacterButtons[] Observers;

    // Start is called before the first frame update
    void Start()
    {
        Observers = FindObjectsOfType<CharacterButtons>();
        descriptionBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonCooldown > 0)
        {
            buttonCooldown -= Time.deltaTime;
            return;
        }


        if (descriptionBox.activeSelf == true) return;
        if (Input.touchCount == 1 || Input.GetMouseButtonDown(0))
        {


            Vector2 worldPos = Vector2.zero;
            if (Input.touchCount == 1)
            {
                Touch point = Input.GetTouch(0);
                print(point.position);
                worldPos = ConvertPosition(point.position);
            }
            else if (Input.GetMouseButtonDown(0))
            {
                worldPos = ConvertPosition(Input.mousePosition);
            }

            if (worldPos == Vector2.zero)
            {
                print("Error in converting inputs!");
            }



            for (int i = 0; i < Observers.Length; ++i)
            {
                if (Observers[i].Interact(worldPos.x, worldPos.y))
                {

                    Sprite tempSprite;
                    string tempText;
                    string tempWeakness;
                    Observers[i].GetMonsterInformation(out tempSprite, out tempText, out tempWeakness);
                    charImage.sprite = tempSprite;
                    charText.text = tempText;

                    ConfigureWeaknesses(tempWeakness);

                    descriptionBox.SetActive(true);


                    buttonCooldown = 0.3f;
                    break;
                }
            }
        }
    }


    Vector2 ConvertPosition(Vector2 pointToBeConverted)
    {
        return Camera.main.ScreenToWorldPoint(pointToBeConverted);
    }


    //0 is fire
    //1 is water
    //2 is grass
    void ConfigureWeaknesses(string types)
    {
        char[] charWeaknessArray = types.ToCharArray();
        int[] weaknessCount = new int[3];

        for (int i = 0; i < charWeaknessArray.Length; ++i)
        {
            if (charWeaknessArray[i] == 'f')
            {
                weaknessCount[0]++;
            }
            else if (charWeaknessArray[i] == 'w')
            {
                weaknessCount[1]++;
            }
            else if (charWeaknessArray[i] == 'g')
            {
                weaknessCount[2]++;
            }
            else
            {
                print("ERROR IN THE TYPES OF THE MONSTERS");
                spellImages[i].sprite = elementIcons[0];
            }
        }

        for (int i = 0; i < weaknessCount.Length; ++i)
        {
            runeCounters[i].text = weaknessCount[i].ToString();
        }

    }
}
