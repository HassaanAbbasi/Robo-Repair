using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    private PlayerData playerData;
    private JetPackUpgrade jetPack;

    [SerializeField]
    private GameObject HealthContainer;
    [SerializeField]
    private GameObject FuelContainer;
    [SerializeField]
    private GameObject fuelBar;
    // Start is called before the first frame update
    void Start()
    {
        playerData = GetComponentInChildren<PlayerData>();
        jetPack = GetComponentInChildren<JetPackUpgrade>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jetPack != null)
            fuelBar.transform.localScale = new Vector3(Mathf.Clamp(jetPack.GetFuelPercent(), 0, 1), 1, 1);
    }
}
