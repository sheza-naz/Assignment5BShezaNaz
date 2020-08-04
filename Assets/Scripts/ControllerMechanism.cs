using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ControllerMechanism : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource unknownVoice;
    public AudioSource capturedVoice;
    Rigidbody rb;
    int count = 0;
    float speed = 20;
    public TextMesh Myfabtext;
    public GameObject myPrefab;
    public Text totalMatching;
    public Text gameOver;
    public Text counterText;
    int calculateTotalMatching = 0;
    List<string> randomStringList = new List<string>();
    List<TextMesh> intList = new List<TextMesh>();
    List<Vector3> vectorPosition = new List<Vector3>();
    Vector3 pickPostionOfCollectable = new Vector3();
    //Vector3 vector = new Vector3();
    List<string> shufleList = new List<string>();
    bool r = true;
    public int ScreenNumber = 1;
    void Start()
    {
        intializePosition();
        stringList();
        
        int count = 0;
        shufleList = Fisher_Yates_CardDeck_Shuffle(randomStringList);
        for (int i = 0; i < shufleList.Count; i++)
        {
            if (matchingParenthesis(shufleList[i]))
            {
                calculateTotalMatching++;
            }
        }
        totalMatching.text = "Total Matching, Find it: " + calculateTotalMatching;       
        rb = GetComponent<Rigidbody>(); 
        generateRandomCollectablean();
    }


    // check string for matching parenthesis...
    private bool matchingParenthesis(string ab)
    {
        int count1 = 0;
        int count2 = 0;
        int len = ab.Length;
        for (int i = 0; i < len; i++)
        {
            string a = "(";
            string b = ")";
            string c = ab[i].ToString();
            if (a.Equals(c))
            {
                count1++;
            }
            else if (b.Equals(c))
            {
                count2++;
            }
            else
            { }
        }
        if (count1 == 0 && count2 == 0)
        {
            return false;
        }
        else
        {
            if (count1 == count2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    // function is used to set position of random text and Collectables.
    public void intializePosition()
    {
        System.Random r = new System.Random();
     for(int i = 20; i < 230; i = i + 20 )
        {
            for (int j = 20; j < 230; j = j + 20)
            {
                vectorPosition.Add(new Vector3(i, 3, j));
            }             
        }
    }

  
    // Update is called once per frame
    private void FixedUpdate()
    {
        float horizental = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 vector3 = new Vector3(horizental, 0.0f, vertical);
        rb.AddForce(vector3 * speed);     
    }
    void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("Pick Up"))
            {
            

                pickPostionOfCollectable = other.gameObject.transform.position;
                int i = returnPostionString(pickPostionOfCollectable);
            if (count == 15) {

                gameOver.text = "GAME OVER...";
            }
            else
            {
                if (matchingParenthesis(shufleList[i]))
                {
                    count = count + 1;
                    counterText.text = "Counter: " + count;
                    other.gameObject.SetActive(false);
                    intList[i].text = "".ToString();
                    Debug.Log("Counter:  " + count);
                    CapturedVoice();
                }
                else
                {
                    UnknownSound();
                }
            }
                
                
            
        }       
    }

    int returnPostionString(Vector3 vector3)
    {
        for (int i = 0; i < intList.Count; i++)
        {
            if (intList[i].transform.position == vector3)
            {
                return i;
            }
        }
        return 1;
    }

// This function is used to generate collectable and 3d text
    void generateRandomCollectablean()
    {  for (int i = 0; i < vectorPosition.Count; i++) {
            Instantiate(myPrefab, vectorPosition[i], Quaternion.identity);
            intList.Add(Instantiate(Myfabtext, vectorPosition[i], Quaternion.Euler(0f, 0f, 0f)));
            intList[i].text = shufleList[i].ToString();
        }
    }

    // function to Generate a coupon
    public static string GenerateString(int length, System.Random random)
    {
        string characters = "XS1";
        StringBuilder result = new StringBuilder(length);
        for (int i = 0; i < length; i++)
        {
            result.Append(characters[random.Next(characters.Length)]);
        }
        return result.ToString();
    }

    public void stringList()
    {
        System.Random r = new System.Random();
        
        for(int i = 0; i < vectorPosition.Count; i++)
        {
            if (i < 5)
            {
                string a = GenerateString(10, r);
                string b = "(" + a + ")";
                randomStringList.Add(b);
            }
            else if (i < 25)
            {
                string a = GenerateString(10, r);
                string b = "()"+a+ "()";
                randomStringList.Add(b);
            }
            else if ( i < 15)
            {
                string a = GenerateString(6, r);
                string b = "("+a+")" + a + "()";
                randomStringList.Add(b);
            }
            else if (i < 20)
            {
                string a = GenerateString(6, r);
                string b = "()(" + a + ")))((()(";
                randomStringList.Add(b);
            }

            else
            {
                string a = GenerateString(12, r);
                randomStringList.Add(a);
            }
        }
    }

    public  List<string> Fisher_Yates_CardDeck_Shuffle(List<string> aList)
    {

        System.Random _random = new System.Random();

        string myGO;

        int n = aList.Count;
        for (int i = 0; i < n; i++)
        {
            // NextDouble returns a random number between 0 and 1.
            // ... It is equivalent to Math.random() in Java.
            int r = i + (int)(_random.NextDouble() * (n - i));
            myGO = aList[r];
            aList[r] = aList[i];
            aList[i] = myGO;
        }

        return aList;
    }







    private void UnknownSound()
    {
        unknownVoice.Play();
    }

    private void CapturedVoice()
    {
        capturedVoice.Play();
    }
}
