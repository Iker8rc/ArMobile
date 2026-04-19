using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TrackImage : MonoBehaviour
{
    [SerializeField]
    private ARTrackedImageManager trackedImageManager;

    [SerializeField]
    private ARObjects[] objetosAR;

    private GameObject prefabCopy;

    private void OnEnable()
    {
        //trackedImageManager.trackedImagesChanged += OnTrackedChanged;
        trackedImageManager.trackablesChanged.AddListener(OnTrackedChanged);
    }
    private void OnDisable()
    {

    }

    void OnTrackedChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
    {
        foreach (var newImage in eventArgs.added)
        {
            for (int i = 0; i < objetosAR.Length; i++)
            {
                if (objetosAR[i].referenceImageName == newImage.referenceImage.name)
                {
                    //prefabCopy = Instantiate(objetosAR[i].referencePrefab, newImage.transform.position, newImage.transform.rotation);
                }
            }
        }

        foreach (var newImage in eventArgs.removed)
        {
            Destroy(prefabCopy);
        }
        foreach (var newImage in eventArgs.updated)
        {
            Debug.Log(newImage.referenceImage.name);
            Debug.Log(newImage.referenceImage.texture);
            Debug.Log(newImage.referenceImage.guid);
            if (newImage.referenceImage.name == "Blastoise")
            {
                //prefabCopy = Instantiate(blastoisePrefab, newImage.transform.position, newImage.transform.rotation);
            }
        }
    }
}

//[Serializable]
//public class ARObjects
/*{
    public string referenceImageName;
    public GameObject referencePrefab;
}*/
