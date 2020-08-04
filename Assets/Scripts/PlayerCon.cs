using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerCon : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource redAlert;
    //public AudioSource gameEnd;
    //public AudioSource backgroundMusic;
    public Text counterPalindrome;
    Rigidbody rb;
    int count;
    float speed = 10;  
    float startTime;
    float endTime;
    int second;
    public Text Timer;
    public GameObject myPrefab;
    string[] randomStringList;
    public TextMesh text1;
    public TextMesh text2;
    public TextMesh text3;
    public TextMesh text4;
    public TextMesh text5;
    public TextMesh text6;
    public TextMesh text7;
    public TextMesh text8;
    public TextMesh text9;
    public TextMesh text10;
    public Text text11;
    bool r = true;
    public int ScreenNumber = 1;
    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
        randomStringList = stringlist();
        generateRandomCollectablean();
        BackgroundMusic();
        startTime = Time.time;
        Debug.Log("Screeen Number " + ScreenNumber);
    }
    private void Update()
    {
        endTime = Time.time - startTime;
        second = ((int)endTime % 60);
        Timer.text = "Timer: " + second + " You have fifty seconds to Capture three palindromes";

        if(second > 50)
        {           
                ScreenNumber = 0;
                SceneManager.LoadScene(ScreenNumber);    
        }
        if (count == 3)
        {         
            if (r)
            {
                //backgroundMusic.Stop();
                text11.text = "YOU HAVE COLLECTED ALL PALINDROME! GAME OVER";
                gameEndSound();
                r = false;
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
     if(count <= 2)
     {
      if (other.gameObject.CompareTag("Pick Up"))
      {
       if (Vector3.Distance(other.gameObject.transform.position, 
                text1.transform.position) == 0)
       {
        if (ChechStringforPanlindrome(text1.text))
        {
          text1.text = "";
          other.gameObject.SetActive(false);
          count += 1;
          counterPalindrome.text = "Palindrome Capture: " + count;
        }
        else
        {
          redAlertSound();
                        }
        }
         else if (Vector3.Distance(other.gameObject.transform.position, text2.transform.position) == 0)
         {
          if(ChechStringforPanlindrome(text2.text))
          {
            text2.text = "";
            other.gameObject.SetActive(false);
            count += 1;
            counterPalindrome.text = "Palindrome Capture: " + count;
          }
          else
          {
            redAlertSound();
          }
         }
         else if (Vector3.Distance(other.gameObject.transform.position, text3.transform.position) == 0)
         {
          if (ChechStringforPanlindrome(text3.text))
          {
            text3.text = "";
            other.gameObject.SetActive(false);
            count += 1;
            counterPalindrome.text = "Palindrome Capture: " + count;
          }
          else
          {
           redAlertSound();
          }
         }
         else if (Vector3.Distance(other.gameObject.transform.position, text4.transform.position) == 0)
         {
          if(ChechStringforPanlindrome(text4.text))
          {
           text4.text = "";
           other.gameObject.SetActive(false);
           count += 1;
           counterPalindrome.text = "Palindrome Capture: " + count;
          }
          else
          {
           redAlertSound();
          }
         }
         else if(Vector3.Distance(other.gameObject.transform.position, text5.transform.position) == 0)
         {
          if(ChechStringforPanlindrome(text5.text))
          {
           text5.text = "";
           other.gameObject.SetActive(false);
           count += 1;
           counterPalindrome.text = "Palindrome Capture: " + count;
          }
          else
          {
           redAlertSound();
          }
         }
         else if(Vector3.Distance(other.gameObject.transform.position, text6.transform.position) == 0)
         {
          if(ChechStringforPanlindrome(text6.text))
          {
          text6.text = "";
          other.gameObject.SetActive(false);
          count += 1;
          counterPalindrome.text = "Palindrome Capture: " + count;
          }
          else
          {
           redAlertSound();
          }
         }
         else if(Vector3.Distance(other.gameObject.transform.position, text7.transform.position) == 0)
         {
          if(ChechStringforPanlindrome(text7.text))
          {
           text7.text = "";
           other.gameObject.SetActive(false);
           count +=1;
           counterPalindrome.text = "Palindrome Capture: " + count;
          }
          else
          {
           redAlertSound();
          }
         }
         else if(Vector3.Distance(other.gameObject.transform.position, text8.transform.position) == 0)
         {
          if (ChechStringforPanlindrome(text8.text))
          {
           text8.text = "";
           other.gameObject.SetActive(false);
           count += 1;
           counterPalindrome.text = "Palindrome Capture: " + count;
          }
          else
          {
           redAlertSound();
          }
         }
         else if(Vector3.Distance(other.gameObject.transform.position, text9.transform.position) == 0)
         {
          if (ChechStringforPanlindrome(text9.text))
          {
           text9.text = "";
           other.gameObject.SetActive(false);
           count += 1;
           counterPalindrome.text = "Palindrome Capture: " + count;
          }
          else
          {
           redAlertSound();
          }
         }
         else if(Vector3.Distance(other.gameObject.transform.position, text10.transform.position) == 0)
         {
          if (ChechStringforPanlindrome(text10.text))
          {
           text10.text = "";
           other.gameObject.SetActive(false);
           count = count + 1;
           counterPalindrome.text = "Palindrome Capture: " + count;
          }
          else
          {
           redAlertSound();
          }
         }
      else
      {

      }
     }
    }
    else
    {
     //backgroundMusic.Stop();
     text11.text = "YOU HAVE COLLECTED ALL PALINDROME! GAME OVER";
     gameEndSound();
     }       
}

// This function is used to generate collectable and give string to 3d text
    void generateRandomCollectablean()
    {  
        Instantiate(myPrefab, new Vector3(12, 0.5f, 7), Quaternion.identity);
        Instantiate(myPrefab, new Vector3(7, 0.5f, 3), Quaternion.identity);
        Instantiate(myPrefab, new Vector3(7, 0.5f, -2), Quaternion.identity);
        Instantiate(myPrefab, new Vector3(12, 0.5f, -6), Quaternion.identity);
        Instantiate(myPrefab, new Vector3(-2, 0.5f, -4), Quaternion.identity);
        Instantiate(myPrefab, new Vector3(-5, 0.5f, -2), Quaternion.identity);
        Instantiate(myPrefab, new Vector3(-12, 0.5f, -5), Quaternion.identity);
        Instantiate(myPrefab, new Vector3(-8, 0.5f, 0), Quaternion.identity);
        Instantiate(myPrefab, new Vector3(-8, 0.5f, 3), Quaternion.identity);
        Instantiate(myPrefab, new Vector3(-12, 0.5f, 6), Quaternion.identity);
        text1.text = randomStringList[8];
        text2.text = randomStringList[5];
        text3.text = randomStringList[2];
        text4.text = randomStringList[3];
        text5.text = randomStringList[4];
        text6.text = randomStringList[1];
        text7.text = randomStringList[6];
        text8.text = randomStringList[7];
        text9.text = randomStringList[0];
        text10.text = randomStringList[9];

    }

    // function to Generate a coupon
    public static string GenerateString(int length, System.Random random)
    {
        string characters = "1SX";
        StringBuilder result = new StringBuilder(length);
        for (int i = 0; i < length; i++)
        {
            result.Append(characters[random.Next(characters.Length)]);
        }
        return result.ToString();
    }

    static string[] stringlist()
    {
        System.Random rnd = new System.Random();
        string[] coupon = new string[10];
        for (int i = 0; i < coupon.Length; i++)
        {
            string a = GenerateString(5, rnd);
            if (i < 3)
            {
                int j = a.Length - 1;
                while (j >= 0)
                {
                    a = String.Concat(a, a[j]);
                    j--;
                }
                coupon[i] = a;
            }
            else
            {
                a = String.Concat(a, a);
                coupon[i] = a;
            }
            //coupon[i] = a;
        }
        return coupon;
    }
    // This function is used to check the given string is palindrome or not
    private bool ChechStringforPanlindrome(string string1)
    {
        int length = string1.Length;
        for (int i = 0; i < length; i++)
        {
            if (string1[i] != string1[length - i - 1])
            {
                return false;
            }
        }
        return true;
    }

    private void redAlertSound()
    {
        redAlert.Play();
    }
    private void gameEndSound()
    {
        //gameEnd.Play();
    }
    private void BackgroundMusic()
    {
        //backgroundMusic.Play();
    }

}
