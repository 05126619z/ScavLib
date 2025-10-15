using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UIElements;

namespace ScavLib.Monobehaviours
{
    /// <summary>
    /// TODO!
    /// </summary>
    class DownloaderUI : MonoBehaviour
    {
        static Dictionary<string, float> downloads = new Dictionary<string, float>();
        public GameObject contentWindow;
        public void CreateDownloader(string file)
        {
            downloads.Add(file, 0f);
            GameObject downloader = Resources.Load<GameObject>("Assets/Prefabs/downloader");
            downloader.transform.parent = contentWindow.transform;
            Image fillBar = downloader.GetComponentInChildren<Image>();
            TextMeshProUGUI fileName = downloader.GetComponentInChildren<TextMeshProUGUI>();
            
        }

        public void SetPercent(string file, float percentage)
        {
            downloads[file] = percentage;
        }
        void Start()
        {

        }
        void Update()
        {
            StartCoroutine("UpdatePercentageAsync");
        }

        IEnumerator<DownloaderUI> UpdatePercentageAsync()
        {
            yield break;
        }
    }
}
