using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityManager : MonoBehaviour
{
    RectTransform rectTransform;
    public PowerUpData powerUpData;
    Dash dash;

    public float DashColdown = 5f;
    public GameObject dashImage;

    Invisible invisible;

    public float InvisibleColdown = 5f;
    public GameObject invisibleImage;

    StunEnemy stunEnemy;

    public float StunEnemyColdown = 5f;
    public GameObject stunEnemyImage;

    ThrowStone throwStone;

    public float ThrowStoneColdown = 5f;
    public GameObject throwStoneImage;

    float Dashtimer = 0f;
    float Invisibletimer = 0f;
    float StunEnemytimer = 0f;
    float ThrowStonetimer = 0f;
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);

        dash = GameObject.Find("dash").GetComponent<Dash>();
        invisible = GameObject.Find("invisible").GetComponent<Invisible>();
        stunEnemy = GameObject.Find("stunEnemy").GetComponent<StunEnemy>();
        throwStone = GameObject.Find("throwStone").GetComponent<ThrowStone>();
        if (dash == null || invisible == null || stunEnemy == null || throwStone == null)
        {
            Debug.LogError("One or more ability components not found on the GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkToDOAbility();
        disableOtherAbilities();
        handleTransparency();
    }

    void disableOtherAbilities()
    {
        if (!powerUpData.EnableDash)
        {
            dashImage.SetActive(false);
        }
        else
        {
            dashImage.SetActive(true);
        }
        if (!powerUpData.EnableInvisible)
        {
            invisibleImage.SetActive(false);
        }
        else
        {
            invisibleImage.SetActive(true);
        }
        if (!powerUpData.EnableStunEnemy)
        {
            stunEnemyImage.SetActive(false);
        }
        else
        {
            stunEnemyImage.SetActive(true);
        }
        if (!powerUpData.EnableThrowStone)
        {
            throwStoneImage.SetActive(false);
        }
        else
        {
            throwStoneImage.SetActive(true);
        }
    }

    void checkToDOAbility()
    {
        if (Input.GetKeyDown(KeyCode.Q) && Dashtimer <= 0f && powerUpData.EnableDash)
        {
            dash.DoDash();
            Dashtimer = DashColdown;
        }
        if (Input.GetKeyDown(KeyCode.W) && Invisibletimer <= 0f && powerUpData.EnableInvisible)
        {
            invisible.DoInvisible();
            Invisibletimer = InvisibleColdown;
        }
        if (Input.GetKeyDown(KeyCode.E) && StunEnemytimer <= 0f && powerUpData.EnableStunEnemy)
        {
            stunEnemy.doStun();
            StunEnemytimer = StunEnemyColdown;
        }
        if (Input.GetKeyDown(KeyCode.R) && ThrowStonetimer <= 0f && powerUpData.EnableThrowStone)
        {
            throwStone.doThrow();
            ThrowStonetimer = ThrowStoneColdown;
        }

        Dashtimer -= Time.deltaTime;
        if (Dashtimer <= 0f)
        {
            //find the text in child
            TextMeshProUGUI dashText = dashImage.GetComponentInChildren<TextMeshProUGUI>();
            dashText.text = "Q";
        }
        else
        {
            TextMeshProUGUI dashText = dashImage.GetComponentInChildren<TextMeshProUGUI>();
            dashText.text = Mathf.Ceil(Dashtimer).ToString();
        }
        Invisibletimer -= Time.deltaTime;
        if (Invisibletimer <= 0f)
        {
            TextMeshProUGUI invisibleText = invisibleImage.GetComponentInChildren<TextMeshProUGUI>();
            invisibleText.text = "W";
        }
        else
        {
            TextMeshProUGUI invisibleText = invisibleImage.GetComponentInChildren<TextMeshProUGUI>();
            invisibleText.text = Mathf.Ceil(Invisibletimer).ToString();
        }
        StunEnemytimer -= Time.deltaTime;
        if (StunEnemytimer <= 0f)
        {
            TextMeshProUGUI stunEnemyText = stunEnemyImage.GetComponentInChildren<TextMeshProUGUI>();
            stunEnemyText.text = "E";
        }
        else
        {
            TextMeshProUGUI stunEnemyText = stunEnemyImage.GetComponentInChildren<TextMeshProUGUI>();
            stunEnemyText.text = Mathf.Ceil(StunEnemytimer).ToString();
        }

        ThrowStonetimer -= Time.deltaTime;
        if (ThrowStonetimer <= 0f)
        {
            TextMeshProUGUI throwStoneText = throwStoneImage.GetComponentInChildren<TextMeshProUGUI>();
            throwStoneText.text = "R";
        }
        else
        {
            TextMeshProUGUI throwStoneText = throwStoneImage.GetComponentInChildren<TextMeshProUGUI>();
            throwStoneText.text = Mathf.Ceil(ThrowStonetimer).ToString();
        }
    }


    void handleTransparency()
    {
        //if the timer is less than 0.5f, set the alpha to 0.5f
        if (Dashtimer > 0.1f)
        {
            Color color = dashImage.GetComponent<Image>().color;
            color.a = 0.3f;
            dashImage.GetComponent<Image>().color = color;
        }
        else
        {
            Color color = dashImage.GetComponent<Image>().color;
            color.a = 1f;
            dashImage.GetComponent<Image>().color = color;
        }
        if (Invisibletimer > 0.1f)
        {
            Color color = invisibleImage.GetComponent<Image>().color;
            color.a = 0.3f;
            invisibleImage.GetComponent<Image>().color = color;
        }
        else
        {
            Color color = invisibleImage.GetComponent<Image>().color;
            color.a = 1f;
            invisibleImage.GetComponent<Image>().color = color;
        }
        if (StunEnemytimer > 0.1f)
        {
            Color color = stunEnemyImage.GetComponent<Image>().color;
            color.a = 0.3f;
            stunEnemyImage.GetComponent<Image>().color = color;
        }
        else
        {
            Color color = stunEnemyImage.GetComponent<Image>().color;
            color.a = 1f;
            stunEnemyImage.GetComponent<Image>().color = color;
        }
        if (ThrowStonetimer > 0.1f)
        {
            Color color = throwStoneImage.GetComponent<Image>().color;
            color.a = 0.3f;
            throwStoneImage.GetComponent<Image>().color = color;
        }
        else
        {
            Color color = throwStoneImage.GetComponent<Image>().color;
            color.a = 1f;
            throwStoneImage.GetComponent<Image>().color = color;
        }
    }

}
