using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class questioning : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject cultist;
    public GameObject textB;
    public int faith;
    public int mentality;
    public int perception;
    public int questionsLeft = 0;
    public int weather;
    public bool interacting = false;

    public int bias;

    public TMP_Text questionsText;
    public TMP_Text log;

    public TraitHandler cultistStats;
    public CultInteracting cultinter;

    public TMP_Text textResp;
    public float characterSpeed = 0.05f;
    private bool isTyping = false;

    void Start()
    {
        weather = Random.Range(1,4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // harrriiiiii helppp - dw i got chatgpt to do it

    public void Dismiss()
	{
        if(interacting == true)
		{
            interacting = false;
            cultinter.Dismiss(cultist);
		}
	}

    public void newRoundOfQuestioning(GameObject culti)
	{
        textB.SetActive(false);
        interacting = true;
        cultist = culti;
        questionsLeft = 3;

        cultistStats = cultist.GetComponent<TraitHandler>();

        questionsLeft = cultistStats.Questions;
        faith = cultistStats.Faith;
        mentality = cultistStats.Mentality;
        perception = cultistStats.Perception;

        log = cultistStats.diaryPage.transform.Find("Log").GetComponent<TMP_Text>();

        questionsText.text = "Questions left: " + questionsLeft.ToString() + "/3";
    }

    public void responseHandler(string response, int strength, string trait, string function)
	{
        string diaryEntry = "- They showed ";

        if (strength <= 0)
		{
            diaryEntry += "no ";
		}
        else if (strength >= 1 && strength <= 3)
        {
            diaryEntry += "little ";
        }
        else if (strength >= 4 && strength <= 6)
        {
            diaryEntry += "average ";
        }
        else if (strength >= 7 && strength <= 9)
        {
            diaryEntry += "strong ";
        }
        else if (strength >= 10)
        {
            diaryEntry += "extremely strong ";
        }

        diaryEntry += trait += " when asked about " + function;

        print(diaryEntry);

        log.text += diaryEntry + "<br><br>";

        StartCoroutine(TypeResponse(response));
    }

    IEnumerator TypeResponse(string response)
    {
        textResp.text = "";
        textB.SetActive(true);
        isTyping = true;
        textResp.text = "";

        bool newLine = false;
        foreach (char c in response)
        {
            textResp.text += c;
            yield return new WaitForSeconds(characterSpeed);

            if(newLine && c == 32)
			{
                yield return new WaitForSeconds(0.8f);
                textResp.text = "";
            }

            newLine = false;

            if (c == 46)
			{
                newLine = true;
			}
        }

        yield return new WaitForSeconds(1.0f);

        isTyping = false;
        textB.SetActive(false);
        afterQuestions();
    }

    public void afterQuestions()
	{
        questionsLeft -= 1;
        cultistStats.Questions -= 1;

        questionsText.text = "Questions left: " + questionsLeft.ToString() + "/3";

        if (questionsLeft <= 0)
        {
            Dismiss();
        }
    }

    public void buttonPressed(GameObject button)
	{
		if (!isTyping)
		{
            string btnName = button.name;


            if (cultistStats.isEvil)
            {
                bias = Random.Range(-5, 6);
		    }
		    else
		    {
                bias = Random.Range(-1, 2);
            }

            faith = cultistStats.Faith + bias;
            mentality = cultistStats.Mentality + bias;
            perception = cultistStats.Perception + bias;

            switch (btnName)
            {
                case "Weather":
                    Weather();
                    break;
                case "Sussy":
                    Sussy();
                    break;
                case "Dream":
                    Dream();
                    break;
                case "Faith":
                    Faith();
                    break;
                case "Odd":
                    Odd();
                    break;
                case "Literature":
                    Literature();
                    break;
                case "Matches":
                    Matches();
                    break;
                case "Herbs":
                    Herbs();
                    break;
                case "Salts":
                    Salts();
                    break;
                case "Crucifix":
                    Crucifix();
                    break;
                case "Magnesium":
                    Magnesium();
                    break;
                default:
                    Debug.LogWarning("Function not found: " + btnName);
                    break;
            }
		}

    }

    public void Weather()
    {
        string response = "";

        if(weather == 1) // night
		{
            if (mentality <= 0)
            {
                response = "The night sky bores me.";
            }
            else if (mentality >= 1 && mentality <= 3)
            {
                response = "The clear night sky feels empty with no stars.";
            }
            else if (mentality >= 4 && mentality <= 6)
            {
                response = "I should be sleeping.";
            }
            else if (mentality >= 7 && mentality <= 9)
            {
                response = "The stars in the sky are a great reminder of our place in the universe.";
            }
            else if (mentality >= 10)
            {
                response = "I could stare at the sprawling expanse of the cosmos for eternity.";
            }
		} else if(weather == 2) // sunny
		{
            if (perception <= 0)
            {
                response = "It's too hot.";
            }
            else if (perception >= 1 && perception <= 3)
            {
                response = "It's ok I guess, the weather doesnt particularly interest me on a day like today.";
            }
            else if (perception >= 4 && perception <= 6)
            {
                response = "Perfect day for a walk and watching the birds.";
            }
            else if (perception >= 7 && perception <= 9)
            {
                response = "I love days like today, the sun shining feels me with joy i did not know i had.";
            }
            else if (perception >= 10)
            {
                response = "The sun is a great partner for all life, the Gods are treating us today.";
            }
        } else if (weather == 3) // rain
        {
            if (faith <= 0)
            {
                response = "What's there to say, im cold, im wet, and i want to go home.";
            }
            else if (faith >= 1 && faith <= 3)
            {
                response = "Its hard to hold much faith in the day brightening up.";
            }
            else if (faith >= 4 && faith <= 6)
            {
                response = "It's raining, so its a good thing we are indoors.";
            }
            else if (faith >= 7 && faith <= 9)
            {
                response = "The rain attempts to blow our high spirits away, but it shall not prevail.";
            }
            else if (faith >= 10)
            {
                response = "Despite the awful weather, my faith holds strong, not even the Gods can waver my faith.";
            }
        }



        Debug.Log("asked about Weather");
        Debug.Log(response);


        responseHandler(response, faith, "Faith", "the Weather");
    }

    public void Sussy()
    {
        string response = "";

        if (perception <= 0)
        {
            response = "I don't see anything unusual around here.";
        }
        else if (perception >= 1 && perception <= 3)
        {
            response = "I thought I saw something move out of the corner of my eye, but it was probably just my imagination.";
        }
        else if (perception >= 4 && perception <= 6)
        {
            response = "Something doesn't feel right here, I can't quite put my finger on it.";
        }
        else if (perception >= 7 && perception <= 9)
        {
            response = "The walls seem to be closing in on me, I feel like I'm being watched.";
        }
        else if (perception >= 10)
        {
            response = "I can see things that shouldn't be there, the geometry of the room is all wrong and shifts with evil intent.";
        }

        Debug.Log("asked about Sussy");
        Debug.Log(response);
        responseHandler(response, perception, "Perception", "Unusual Things");
    }

    public void Dream()
    {
        string response = "";

        if (mentality <= 0)
        {
            response = "I have this reccuring dream. I am stuck in the middle of an infinite, empty bog spare a single dead tree. As I wade towards it I feel a thin tentacle wrap around my leg, gripping it so tight it feels as though it may fall off. It starts to pull me down into the cold wet mud, my fingers reach and claw for the branches. My vision starts to fade as the thick sludge fills my throat and im left with nothing but the numbing cold.";
        }
        else if (mentality >= 1 && mentality <= 3)
        {
            response = "Not good, they have been filled with dark creatures, and terrible things.";
        }
        else if (mentality >= 4 && mentality <= 6)
        {
            response = "I often dont remember my dreams, when i do they're the normal, weird concoctions.";
        }
        else if (mentality >= 7 && mentality <= 9)
        {
            response = "My dreams have been warm, bringing me enlightenment everytime i sleep.";
        }
        else if (mentality >= 10)
        {
            response = "I dream of the great cosmos and all the wondrous beings that fill it. I feel as though it speaks to me every night, telling me of the great things ahead of us.";
        }

        Debug.Log("asked about Dream");
        Debug.Log(response);
        responseHandler(response, mentality, "Mentality", "their Dreams");
    }

    public void Faith()
    {
        string response = "";

        if (faith <= 0)
        {
            response = "My faith diminishes, there is almost none left.";
        }
        else if (faith >= 1 && faith <= 3)
        {
            response = "My faith wavers, I am still trying to figure out my place in all of this.";
        }
        else if (faith >= 4 && faith <= 6)
        {
            response = "My faith is still growing.";
        }
        else if (faith >= 7 && faith <= 9)
        {
            response = "My faith in our lord is as strong as ever.";
        }
        else if (faith >= 10)
        {
            response = "My faith is massive, overwhelming even.";
        }

        Debug.Log("asked about Faith");
        Debug.Log(response);
        responseHandler(response, faith, "Faith", "their Faith");
    }

    public void Odd()
    {
        string response = "";
        if (perception == 0)
        {
            response = "I'm sorry, I cannot perceive anything right now.";
        }
        else if (perception >= 1 && perception <= 3)
        {
            response = "I sense a faint presence.";
        }
        else if (perception >= 4 && perception <= 6)
        {
            response = "I sense a moderate presence.";
        }
        else if (perception >= 7 && perception <= 9)
        {
            response = "I sense a strong presence.";
        }
        else if (perception == 10)
        {
            response = "I sense an overwhelming presence.";
        }

        Debug.Log("Asked about Odd. ");
        Debug.Log(response);
    }

    public void Literature()
    {
        string Response = "";
        int highestValue = Mathf.Max(perception, mentality, faith);

        print(highestValue);

        List<string> responses = new List<string>();
        if (perception == highestValue) responses.Add("a book about psychology. The human brain is quite fascinating.");
        if (mentality == highestValue) responses.Add("a book about the cosmos. It has been quite thought provoking.");
        if (faith == highestValue) responses.Add("the Necronomicon. I love the dark stories.");

        if (responses.Count == 1)
        {
            Response = "I have been reading " + responses[0];
        }
        else
        {
            int randomIndex = Random.Range(0, responses.Count);
            Response = "I have been reading " + responses[randomIndex];
        }

        string trait = "";

        if (Response == "I have been reading " + "a book about psychology. The human brain is quite fascinating.")
		{
            trait = "Perception";
		}

        if (Response == "I have been reading " + "a book about the cosmos. It has been quite thought provoking.")
        {
            trait = "Mentality";
        }

        if (Response == "I have been reading " + "the Necronomicon. I love the dark stories.")
        {
            trait = "Faith";
        }


        Debug.Log("Asked about Literature. " + Response);

        //string ResponseEdited = Response.Substring(0, Response.LastIndexOf('.') + 1);

        responseHandler(Response, 10, trait, "Literature they read.");
    }

    public void Matches()
    {
        Debug.Log("Showed Matches");
    }

    public void Herbs()
    {
        Debug.Log("Showed Herbs");
    }

    public void Salts()
    {
        Debug.Log("Showed Salts");
    }

    public void Crucifix()
    {
        Debug.Log("Showed Crucifix");
    }

    public void Magnesium()
    {
        Debug.Log("Showed Magnesium");
    }

}
