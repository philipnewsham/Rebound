using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHoverTest : MonoBehaviour
{
    public Font[] fonts;
    private Text m_text;
    void Start()
    {
        m_text = GetComponentInChildren<Text>();
    }
    public void OnHover(bool isHovering)
    {
        if (isHovering)
            m_text.font = fonts[1];
        else
            m_text.font = fonts[0];
    }
}
