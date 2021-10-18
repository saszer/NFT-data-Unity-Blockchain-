using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
using UnityEngine.UI;
//sz //www.embracingeart.space
//Rough sketch to rread from csv, this can be structured properly through Object classes etc.
//csv - NFT data list.
public class test : MonoBehaviour
{
    private string[] data;
    public TextAsset textassetdata;

    public int tokenid;
    public string str1;
    public Texture _image;
    public string _imageurl;
    public RawImage texture;
    public Material _material;
    private void OnEnable()
    {
        str1 = data[37* (tokenid) + 9]; //Get Type
        _imageurl = data[37* (tokenid) + 6];
        _imageurl =
            "https://cloudflare-ipfs.com/" + _imageurl;
        
        StopAllCoroutines();
        StartCoroutine(GetTexture());

    }
    IEnumerator GetTexture() {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(_imageurl);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
        }
        else {
            _image = ((DownloadHandlerTexture)www.downloadHandler).texture;
            texture.texture = _image;
            _material.mainTexture = _image;
        }
    }
    void Awake()
    {
        data = textassetdata.text.Split(new string[] {",", "\n"}, StringSplitOptions.None);

    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
