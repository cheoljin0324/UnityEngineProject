using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public float hp = 10.0f;
    public float maxHp = 10.0f;
    public float maxst = 10.0f;
    public float st = 10.0f;

    [SerializeField]
    private Image HpBar;
    [SerializeField]
    private Image StBar;

    private void Update()
    {
        HpBar.fillAmount = hp/maxHp;
        StBar.fillAmount = st / maxst;
    }

}
