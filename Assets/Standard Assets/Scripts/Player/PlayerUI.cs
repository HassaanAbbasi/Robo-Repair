using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    private PlayerData m_playerData;
    private JetPackUpgrade m_jetPack;

    [SerializeField]
    private GameObject m_healthContainer;
    [SerializeField]
    private GameObject m_fuelContainer;
    [SerializeField]
    private GameObject m_fuelBar;
    [SerializeField]
    private Image one;
    [SerializeField]
    private Image two;
    [SerializeField]
    private Image three;
    // Start is called before the first frame update
    void Start()
    {
        m_playerData = GetComponentInChildren<PlayerData>();
        m_jetPack = GetComponentInChildren<JetPackUpgrade>();
    }

    // Update is called once per frame
    void Update()
    {
        one.enabled = false;
        two.enabled = false;
        three.enabled = false;

        switch (m_playerData.health)
        {
            case 3:
                three.enabled = true;
                two.enabled = true;
                one.enabled = true;
                break;

            case 2:
                two.enabled = true;
                one.enabled = true;
                break;

            case 1:
                one.enabled = true;
                break;

                break;

            default:
                break;
        }

        if (m_jetPack != null)
        {
            if (!m_fuelContainer.activeSelf)
                m_fuelContainer.SetActive(true);
            m_fuelBar.transform.localScale = new Vector3(Mathf.Clamp(m_jetPack.GetFuelPercent(), 0, 1), 1, 1);
        }
        else
        {
            m_fuelContainer.SetActive(false);
            m_jetPack = GetComponentInChildren<JetPackUpgrade>();
        }
    }
}
