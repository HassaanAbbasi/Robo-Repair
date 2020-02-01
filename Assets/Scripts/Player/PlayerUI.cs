using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (m_jetPack != null)
        {
         //   if (m_fuelContainer.enabled == false)
            //    m_fuelContainer.enabled = false;
            m_fuelBar.transform.localScale = new Vector3(Mathf.Clamp(m_jetPack.GetFuelPercent(), 0, 1), 1, 1);
        }
        else
        {
           // m_fuelContainer.enabled = false;
            m_jetPack = GetComponentInChildren<JetPackUpgrade>();
        }
    }
}
