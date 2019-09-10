using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KModkit;
using System.Linq;



public class FlowerPatch : MonoBehaviour {

    private bool day = true;
    private bool work = false;
    public int Flower_Color;
    public int Flower_Answer;
    private int textcolor;
    private int day_random;
    private int textletter;
    private Queue<IEnumerator> Queue = new Queue<IEnumerator>();
    public GameObject[] Flowers;
    public GameObject[] MoonPolkaDots;
    public Material[] FlowerMat;
    public GameObject Field;
    public GameObject Sky;
    public GameObject Sun;
    public GameObject Moon;
    public Material[] FieldColor;
    public Material[] SkyColor;
    public Color[] Colors;
    public string[] LogRelatedThingy;
    public KMAudio Dirt_Sound;
    public KMBombInfo BombInfo;
    public KMNeedyModule Needy;
    public KMSelectable Button;
    public GameObject Button_enabler;
    public TextMesh Letter;
    


    // Use this for initialization
    void Start () {
        Button_enabler.SetActive(false);


    }
    void Awake()
    {
        GetComponent<KMNeedyModule>().OnNeedyActivation += OnNeedyActivation;
        GetComponent<KMNeedyModule>().OnNeedyDeactivation += OnNeedyDeactivation;
        GetComponent<KMNeedyModule>().OnTimerExpired += OnTimerExpired;
        Button.OnInteract += delegate () {Needy.GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress,transform); Button.AddInteractionPunch(); Queue.Enqueue(CycleFlowers()) ; return false; };


    }
    void OnNeedyActivation()
    {
        Button_enabler.SetActive(true);
        Flower_Color = Random.Range(0, 8);
        day_random = Random.Range(0, 2);
        textcolor = Random.Range(0, 8);
        textletter = Random.Range(0, 8);
        
        switch (textcolor)
        {
            case 0:
                Letter.color = Colors[0];
                break;
            case 1:
                Letter.color = Colors[1];
                break;
            case 2:
                Letter.color = Colors[2];
                break;
            case 3:
                Letter.color = Colors[3];
                break;
            case 4:
                Letter.color = Colors[4];
                break;
            case 5:
                Letter.color = Colors[5];
                break;
            case 6:
                Letter.color = Colors[6];
                break;
            case 7:
                Letter.color = Colors[7];
                break;
        }
        
        switch (textletter)
        {
            case 0:
                Letter.text = "B";
                break;
            case 1:
                Letter.text = "G";
                break;
            case 2:
                Letter.text = "I";
                break;
            case 3:
                Letter.text = "O";
                break;
            case 4:
                Letter.text = "R";
                break;
            case 5:
                Letter.text = "P";
                break;
            case 6:
                Letter.text = "W";
                break;
            case 7:
                Letter.text = "Y";
                break;
        }
        Debug.Log("The letter is "+ LogRelatedThingy[textletter]);
        Debug.Log("The color is " + LogRelatedThingy[textcolor]);
        if (day_random == 0)
        {
            if (BombInfo.GetSerialNumberNumbers().Last() % 2 == 0)
            {
                Flower_Answer = textcolor;
                Debug.Log("It's day outside and the last digit of the serial number is even.");
                Debug.Log("Submission should be the color of the letter.");
                Debug.LogFormat("The answer is {0}", LogRelatedThingy[textcolor]);
                Sky.GetComponent<MeshRenderer>().material = SkyColor[0];
                Field.GetComponent<MeshRenderer>().material = FieldColor[0];
                Sun.GetComponent<MeshRenderer>().enabled = true;
                Moon.GetComponent<MeshRenderer>().enabled = false;
                for (int i = 0; i < 7; i++)
                {
                    MoonPolkaDots[i].GetComponent<MeshRenderer>().enabled = false;
                }

            }
            else
            {
                Flower_Answer = textletter;
                Debug.Log("It's day outside and the last digit of the serial number is odd.");
                Debug.Log("Submission should be the color that it's first character is the letter.");
                Debug.LogFormat("The answer is {0}", LogRelatedThingy[textletter]);
                Sky.GetComponent<MeshRenderer>().material = SkyColor[0];
                Field.GetComponent<MeshRenderer>().material = FieldColor[0];
                Sun.GetComponent<MeshRenderer>().enabled = true;
                Moon.GetComponent<MeshRenderer>().enabled = false;
                for (int i = 0; i < 7; i++)
                {
                    MoonPolkaDots[i].GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }
        else
        {
            if (BombInfo.GetSerialNumberNumbers().Last() % 2 == 0)
            {
                Flower_Answer = textletter;
                Debug.Log("It's night outside and the last digit of the serial number is even.");
                Debug.Log("Submission should be the color that it's first character is the letter.");
                Debug.LogFormat("The answer is {0}",LogRelatedThingy[textletter]);
                Sky.GetComponent<MeshRenderer>().material = SkyColor[1];
                Field.GetComponent<MeshRenderer>().material = FieldColor[1];
                Sun.GetComponent<MeshRenderer>().enabled = false;
                Moon.GetComponent<MeshRenderer>().enabled = true;
                for (int i = 0; i < 7; i++)
                {
                    MoonPolkaDots[i].GetComponent<MeshRenderer>().enabled = true;
                }

            }
            else
            {
                Flower_Answer = textcolor;
                Debug.Log("It's night outside and the last digit of the serial number is odd.");
                Debug.Log("Submission should be the color of the letter.");
                Debug.LogFormat("The answer is {0}", LogRelatedThingy[textcolor]);
                Sky.GetComponent<MeshRenderer>().material = SkyColor[1];
                Field.GetComponent<MeshRenderer>().material = FieldColor[1];
                Sun.GetComponent<MeshRenderer>().enabled = false;
                Moon.GetComponent<MeshRenderer>().enabled = true;
                for (int i = 0; i < 7; i++)
                {
                    MoonPolkaDots[i].GetComponent<MeshRenderer>().enabled = true;
                }

            }
        }
        
        if (Flower_Color == 0)
        {
            for (int i = 0; i < 7; i++)
            {
                Flowers[i].GetComponent<MeshRenderer>().material = FlowerMat[0];
            }
        }
        else if (Flower_Color == 1)
        {
            for (int i = 0; i < 7; i++)
            {
                Flowers[i].GetComponent<MeshRenderer>().material = FlowerMat[1];
            }
        }
        else if (Flower_Color == 2)
        {
            for (int i = 0; i < 7; i++)
            {
                Flowers[i].GetComponent<MeshRenderer>().material = FlowerMat[2];
            }
        }
        else if (Flower_Color == 3)
        {
            for (int i = 0; i < 7; i++)
            {
                Flowers[i].GetComponent<MeshRenderer>().material = FlowerMat[3];
            }
        }
        else if (Flower_Color == 4)
        {
            for (int i = 0; i < 7; i++)
            {
                Flowers[i].GetComponent<MeshRenderer>().material = FlowerMat[4];
            }
        }
        else if (Flower_Color == 5)
        {
            for (int i = 0; i < 7; i++)
            {
                Flowers[i].GetComponent<MeshRenderer>().material = FlowerMat[5];
            }
        }
        else 
        {
            for (int i = 0; i < 7; i++)
            {
                Flowers[i].GetComponent<MeshRenderer>().material = FlowerMat[6];
            }
        }

        




    }
    void OnNeedyDeactivation()
    {

    }
    void OnTimerExpired()
    {
        Button_enabler.SetActive(false);
        if (Flower_Color == Flower_Answer)
        {
            Needy.HandlePass();
            
        }
        else
        {
            Needy.HandleStrike();
            
            Debug.LogFormat("You submitted the wrong color, it was {0} but you submitted {1}",LogRelatedThingy[Flower_Answer], LogRelatedThingy[Flower_Color]);
        }
    }
    IEnumerator CycleFlowers()
    {
        int randomsound;
        switch (Flower_Color)
        {
            case 0:
                for(int i =0;i<7;i++)
                {
                    Flowers[i].GetComponent<MeshRenderer>().material = FlowerMat[1];
                    Flower_Color = 1;
                    randomsound = Random.Range(0, 4);
                    switch (randomsound)
                    {
                        case 0:
                            Needy.GetComponent<KMAudio>().PlaySoundAtTransform("dirtsfx1", transform);
                            break;
                        case 1:
                            Needy.GetComponent<KMAudio>().PlaySoundAtTransform("dirtsfx2", transform);
                            break;
                        case 2:
                            Needy.GetComponent<KMAudio>().PlaySoundAtTransform("dirtsfx3", transform);
                            break;
                        case 3:
                            Needy.GetComponent<KMAudio>().PlaySoundAtTransform("dirtsfx4", transform);
                            break;
                    }
                    yield return new WaitForSeconds(0.14285714285f);
                }
                break;
            case 1:
                for (int i = 0; i < 7; i++)
                {
                    Flowers[i].GetComponent<MeshRenderer>().material = FlowerMat[2];
                    Flower_Color = 2;
                    randomsound = Random.Range(0, 4);
                    switch (randomsound)
                    {
                        case 0:
                            Needy.GetComponent<KMAudio>().PlaySoundAtTransform("dirtsfx1", transform);
                            break;
                        case 1:
                            Needy.GetComponent<KMAudio>().PlaySoundAtTransform("dirtsfx2", transform);
                            break;
                        case 2:
                            Needy.GetComponent<KMAudio>().PlaySoundAtTransform("dirtsfx3", transform);
                            break;
                        case 3:
                            Needy.GetComponent<KMAudio>().PlaySoundAtTransform("dirtsfx4", transform);
                            break;
                    }
                    yield return new WaitForSeconds(0.14285714285f);
                }
                break;
            case 2:
                for (int i = 0; i < 7; i++)
                {
                    Flowers[i].GetComponent<MeshRenderer>().material = FlowerMat[3];
                    Flower_Color = 3;
                    randomsound = Random.Range(0, 4);
                    switch (randomsound)
                    {
                        case 0:
                            Needy.GetComponent<KMAudio>().PlaySoundAtTransform("dirtsfx1", transform);
                            break;
                        case 1:
                            Needy.GetComponent<KMAudio>().PlaySoundAtTransform("dirtsfx2", transform);
                            break;
                        case 2:
                            Needy.GetComponent<KMAudio>().PlaySoundAtTransform("dirtsfx3", transform);
                            break;
                        case 3:
                            Needy.GetComponent<KMAudio>().PlaySoundAtTransform("dirtsfx4", transform);
                            break;
                    }
                    yield return new WaitForSeconds(0.14285714285f);
                }
                break;
            case 3:
                for (int i = 0; i < 7; i++)
                {
                    Flowers[i].GetComponent<MeshRenderer>().material = FlowerMat[4];
                    Flower_Color = 4;
                    randomsound = Random.Range(0, 4);
                    switch (randomsound)
                    {
                        case 0:
                            Needy.GetComponent<KMAudio>().PlaySoundAtTransform("dirtsfx1", transform);
                            break;
                        case 1:
                            Needy.GetComponent<KMAudio>().PlaySoundAtTransform("dirtsfx2", transform);
                            break;
                        case 2:
                            Needy.GetComponent<KMAudio>().PlaySoundAtTransform("dirtsfx3", transform);
                            break;
                        case 3:
                            Needy.GetComponent<KMAudio>().PlaySoundAtTransform("dirtsfx4", transform);
                            break;
                    }
                    yield return new WaitForSeconds(0.14285714285f);
                }
                break;
            case 4:
                for (int i = 0; i < 7; i++)
                {
                    Flowers[i].GetComponent<MeshRenderer>().material = FlowerMat[5];
                    Flower_Color = 5;
                    randomsound = Random.Range(0, 4);
                    switch (randomsound)
                    {
                        case 0:
                            Needy.GetComponent<KMAudio>().PlaySoundAtTransform("dirtsfx1", transform);
                            break;
                        case 1:
                            Needy.GetComponent<KMAudio>().PlaySoundAtTransform("dirtsfx2", transform);
                            break;
                        case 2:
                            Needy.GetComponent<KMAudio>().PlaySoundAtTransform("dirtsfx3", transform);
                            break;
                        case 3:
                            Needy.GetComponent<KMAudio>().PlaySoundAtTransform("dirtsfx4", transform);
                            break;
                    }
                    yield return new WaitForSeconds(0.14285714285f);
                }
                break;
            case 5:
                for (int i = 0; i < 7; i++)
                {
                    Flowers[i].GetComponent<MeshRenderer>().material = FlowerMat[6];
                    Flower_Color = 6;
                    randomsound = Random.Range(0, 4);
                    switch (randomsound)
                    {
                        case 0:
                            Needy.GetComponent<KMAudio>().PlaySoundAtTransform("dirtsfx1", transform);
                            break;
                        case 1:
                            Needy.GetComponent<KMAudio>().PlaySoundAtTransform("dirtsfx2", transform);
                            break;
                        case 2:
                            Needy.GetComponent<KMAudio>().PlaySoundAtTransform("dirtsfx3", transform);
                            break;
                        case 3:
                            Needy.GetComponent<KMAudio>().PlaySoundAtTransform("dirtsfx4", transform);
                            break;
                    }
                    yield return new WaitForSeconds(0.14285714285f);
                }
                break;
            case 6:
                for (int i = 0; i < 7; i++)
                {
                    Flowers[i].GetComponent<MeshRenderer>().material = FlowerMat[7];
                    Flower_Color = 7;
                    randomsound = Random.Range(0, 4);
                    switch (randomsound)
                    {
                        case 0:
                            Needy.GetComponent<KMAudio>().PlaySoundAtTransform("dirtsfx1", transform);
                            break;
                        case 1:
                            Needy.GetComponent<KMAudio>().PlaySoundAtTransform("dirtsfx2", transform);
                            break;
                        case 2:
                            Needy.GetComponent<KMAudio>().PlaySoundAtTransform("dirtsfx3", transform);
                            break;
                        case 3:
                            Needy.GetComponent<KMAudio>().PlaySoundAtTransform("dirtsfx4", transform);
                            break;
                    }
                    yield return new WaitForSeconds(0.14285714285f);
                }
                break;
            case 7:
                for (int i = 0; i < 7; i++)
                {
                    Flowers[i].GetComponent<MeshRenderer>().material = FlowerMat[0];
                    Flower_Color = 0;
                    randomsound = Random.Range(0, 4);
                    switch (randomsound)
                    {
                        case 0:
                            Needy.GetComponent<KMAudio>().PlaySoundAtTransform("dirtsfx1", transform);
                            break;
                        case 1:
                            Needy.GetComponent<KMAudio>().PlaySoundAtTransform("dirtsfx2", transform);
                            break;
                        case 2:
                            Needy.GetComponent<KMAudio>().PlaySoundAtTransform("dirtsfx3", transform);
                            break;
                        case 3:
                            Needy.GetComponent<KMAudio>().PlaySoundAtTransform("dirtsfx4", transform);
                            break;
                    }
                    yield return new WaitForSeconds(0.14285714285f);
                }
                break;
        }
        work = false;
    }


    // Update is called once per frame
    void Update () {

        if(!work && Queue.Count > 0 )
        {

            IEnumerator task = Queue.Dequeue();
            StartCoroutine(task);
            work = true;
        }
		
	}
}
