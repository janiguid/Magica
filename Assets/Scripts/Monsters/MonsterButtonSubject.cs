using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterButtonSubject : MonoBehaviour
{
    [Header("MonsterInformation")]
    [SerializeField] private Image monImage;
    [SerializeField] private Text monText;
    [SerializeField] private GameObject descriptionBox;
    [SerializeField] private Image[] weaknessImages;
    [SerializeField] private Sprite[] elementIcons;

    [Header("Timers")]
    [SerializeField] private float buttonCooldown;
    

    private MonsterDescriptions[] Observers;

    // Start is called before the first frame update
    void Start()
    {
        Observers = FindObjectsOfType<MonsterDescriptions>();
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
        if (Input.touchCount == 1)
        {
            Touch point = Input.GetTouch(0);
            print(point.position);

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(point.position);




            for (int i = 0; i < Observers.Length; ++i)
            {
                if (Observers[i].Interact(worldPos.x, worldPos.y))
                {
                    
                    Sprite tempSprite;
                    string tempText;
                    string tempWeakness;
                    Observers[i].GetMonsterInformation(out tempSprite, out tempText, out tempWeakness);
                    monImage.sprite = tempSprite;
                    monText.text = tempText;
                    
                    ConfigureWeaknesses(tempWeakness);

                    descriptionBox.SetActive(true);


                    buttonCooldown = 0.3f;
                    break;
                }
            }
        }
    }
    

    //0 is fire
    //1 is water
    //2 is grass
    void ConfigureWeaknesses(string types)
    {
        char[] charWeaknessArray = types.ToCharArray();


        for(int i = 0; i < charWeaknessArray.Length; ++i)
        {
            if(charWeaknessArray[i] == 'f')
            {
                weaknessImages[i].sprite = elementIcons[0];
            }else if(charWeaknessArray[i] == 'w')
            {
                weaknessImages[i].sprite = elementIcons[1];
            }
            else if(charWeaknessArray[i] == 'g')
            {
                weaknessImages[i].sprite = elementIcons[2];
            }
            else
            {
                print("ERROR IN THE TYPES OF THE MONSTERS");
                weaknessImages[i].sprite = elementIcons[0];
            }
        }
    }

}
