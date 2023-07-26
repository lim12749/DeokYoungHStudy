﻿using System;
using UnityEngine;
using TMPro;
public class PointController : MonoBehaviour
{

    public TextMeshProUGUI total;
    public TextMeshProUGUI coin;

    private static PointController m_instance;

    public static PointController instance
    {
        get
        {
            if (m_instance == false)
            {
                m_instance = FindObjectOfType<PointController>();
            }
            return m_instance;
        }
    }

    public void AddCoin()
    {
        coin.text = (Convert.ToInt32(coin.text) + 1).ToString("00");
        total.text = (Convert.ToInt32(total.text) + 100).ToString("0000000");
    }
}