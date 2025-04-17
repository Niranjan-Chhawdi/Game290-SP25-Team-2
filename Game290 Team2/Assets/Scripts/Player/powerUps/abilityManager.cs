using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class abilityManager : MonoBehaviour
{
    public Dash dash;
    public bool EnableDash = true;
    public float DashColdown = 5f;
    public TextMeshProUGUI dashText;
    public Invisible invisible;
    public bool EnableInvisible = true;
    public float InvisibleColdown = 5f;
    public TextMeshProUGUI invisibleText;
    public StunEnemy stunEnemy;
    public bool EnableStunEnemy = true;
    public float StunEnemyColdown = 5f;
    public TextMeshProUGUI stunEnemyText;
    public ThrowStone throwStone;
    public bool EnableThrowStone = true;
    public float ThrowStoneColdown = 5f;
    public TextMeshProUGUI throwStoneText;

    float Dashtimer = 0f;
    float Invisibletimer = 0f;
    float StunEnemytimer = 0f;
    float ThrowStonetimer = 0f;

    // Update is called once per frame
    void Update()
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
            dashText.text = "Q";
        }
        else
        {
            dashText.text = Mathf.Ceil(Dashtimer).ToString();
        }
        Invisibletimer -= Time.deltaTime;
        if (Invisibletimer <= 0f)
        {
            invisibleText.text = "W";
        }
        else
        {
            invisibleText.text = Mathf.Ceil(Invisibletimer).ToString();
        }
        StunEnemytimer -= Time.deltaTime;
        if (StunEnemytimer <= 0f)
        {
            stunEnemyText.text = "E";
        }
        else
        {
            stunEnemyText.text = Mathf.Ceil(StunEnemytimer).ToString();
        }
        ThrowStonetimer -= Time.deltaTime;
        if (ThrowStonetimer <= 0f)
        {
            throwStoneText.text = "R";
        }
        else
        {
            throwStoneText.text = Mathf.Ceil(ThrowStonetimer).ToString();
        }

    }
}
