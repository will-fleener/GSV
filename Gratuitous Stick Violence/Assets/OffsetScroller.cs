using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetScroller : MonoBehaviour {

    public float scrollSpeed;
    private Vector2 savedOffset;
    Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
        savedOffset = rend.sharedMaterial.GetTextureOffset("_MainTex");
        rend.sharedMaterial.mainTexture.wrapMode = TextureWrapMode.Repeat; //new TextureWrapMode
    }

    void Update()
    {
        float y = Time.time * scrollSpeed;//Mathf.Repeat(Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2(savedOffset.x, y);
        rend.sharedMaterial.mainTextureOffset = offset;//SetTextureOffset("_MainTex", offset);
    }

    void OnDisable()
    {
        rend.sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
    }
}
