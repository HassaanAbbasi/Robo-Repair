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
    // Start is called before the first frame update
    void Start()
    {
        m_playerData = GetComponentInChildren<PlayerData>();
        m_jetPack = GetComponentInChildren<JetPackUpgrade>();
    }

    // Update is called once per frame
    void Update()
    {
        Image[] images = m_healthContainer.GetComponentsInChildren<Image>();
        for(int i = 0; i < 3; i++)
        {
            if (i >= m_playerData.health)
                images[i].enabled = false;
            else
                images[i].enabled = true;
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
