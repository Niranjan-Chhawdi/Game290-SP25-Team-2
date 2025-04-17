using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityManager : MonoBehaviour
{
    RectTransform rectTransform;

    Dash dash;
    public bool EnableDash = true;
    public float DashColdown = 5f;
    public GameObject dashImage;

    Invisible invisible;
    public bool EnableInvisible = true;
    public float InvisibleColdown = 5f;
    public GameObject invisibleImage;

    StunEnemy stunEnemy;
    public bool EnableStunEnemy = true;
    public float StunEnemyColdown = 5f;
    public GameObject stunEnemyImage;

    ThrowStone throwStone;
    public bool EnableThrowStone = true;
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
    }

    void disableOtherAbilities()
    {
        if (!EnableDash)
        {
            dashImage.SetActive(false);
        }
        else
        {
            dashImage.SetActive(true);
        }
        if (!EnableInvisible)
        {
            invisibleImage.SetActive(false);
        }
        else
        {
            invisibleImage.SetActive(true);
        }
        if (!EnableStunEnemy)
        {
            stunEnemyImage.SetActive(false);
        }
        else
        {
            stunEnemyImage.SetActive(true);
        }
        if (!EnableThrowStone)
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
        if (Input.GetKeyDown(KeyCode.Q) && Dashtimer <= 0f && EnableDash)
        {
            dash.DoDash();
            Dashtimer = DashColdown;
        }
        if (Input.GetKeyDown(KeyCode.W) && Invisibletimer <= 0f && EnableInvisible)
        {
            invisible.DoInvisible();
            Invisibletimer = InvisibleColdown;
        }
        if (Input.GetKeyDown(KeyCode.E) && StunEnemytimer <= 0f && EnableStunEnemy)
        {
            stunEnemy.doStun();
            StunEnemytimer = StunEnemyColdown;
        }
        if (Input.GetKeyDown(KeyCode.R) && ThrowStonetimer <= 0f && EnableThrowStone)
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
}
