using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour
{
    public float Speed = 10f;
    private MeshRenderer m_Renderer;
    private float x = 0f;
	void Start ()
    {
        m_Renderer = GetComponent<MeshRenderer>();
	}	
	void Update ()
    {
        x += Speed * Time.deltaTime;
        m_Renderer.material.mainTextureOffset = new Vector2(x, 0f);
	}
}
