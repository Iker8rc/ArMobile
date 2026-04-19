using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System.Collections;

public class Prueba : MonoBehaviour
{
    private bool Fight = false;
    [SerializeField]
    private ARTrackedImageManager trackedImageManager;
    [SerializeField]
    private ARObjects[] objetosAR;

    private GameObject prefabCopy;
    private GameObject prefabCopy2;

    //Animaciones
    private Animator animator1;
    private Animator animator2;

    private void OnEnable()
    {
        //trackedImagemanager.trackedImagesChanged += OnTrackedChanged; //Sirve para enlazar acciones. Herramienta para ponerlo todo en com�n (llamas a un solo evento).
        trackedImageManager.trackablesChanged.AddListener(OnTrackedChanged);
    }

    private void OnDisable()
    {
        trackedImageManager.trackablesChanged.RemoveListener(OnTrackedChanged);
    }
    private void Update()
    {
        if (prefabCopy != null && prefabCopy2 != null && Fight == false)
        {
            Fight = true;
            StartCoroutine(Pelea());

            prefabCopy.transform.LookAt(prefabCopy2.transform);
            prefabCopy2.transform.LookAt(prefabCopy.transform);
            
            animator1.SetBool("Fight", true);
            animator2.SetBool("Fight", true);
        }
    }
    IEnumerator Pelea()
    {
        yield return new WaitForSeconds(15f);
        animator1.SetBool("Fight", false);
        animator2.SetBool("Fight", false);

        animator2.SetTrigger("Dead");
        animator1.SetTrigger("Win");
}

    void OnTrackedChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventargs)
    {
        foreach (var newImage in eventargs.added) //para repasar todas las img que se han a�adido.
        {
            for(int i = 0; i < objetosAR.Length; i++)
            {
                if (objetosAR[i].referenceImageName == newImage.referenceImage.name)
                {
                    if (prefabCopy == null)
                    {
                        prefabCopy = Instantiate(objetosAR[i].prefab, newImage.transform.position, newImage.transform.rotation);
                        animator1 = prefabCopy.GetComponent<Animator>();
                    }
                    else
                    {
                        prefabCopy2 = Instantiate(objetosAR[i].prefab, newImage.transform.position, newImage.transform.rotation);
                        animator2 = prefabCopy2.GetComponent<Animator>();
                    }
                }
            }
            
        }

        foreach (var newImage in eventargs.removed) //por si la imagen no se trackea
        {
            //Eliminar el prefab
            /*if (newImage.referenceImage.name == "simpleFrame")
            {
                Destroy(prefabCopy);
            }*/
        }

        foreach (var newImage in eventargs.updated)
        {
            //Esto es cada frame que sigue detectando
            
            for (int i = 0; i < objetosAR.Length; i++)
            {
                if (objetosAR[i].referenceImageName == newImage.referenceImage.name && prefabCopy == null)
                {
                    prefabCopy = Instantiate(objetosAR[i].prefab, newImage.transform.position, newImage.transform.rotation);
                }
            }
        }
    }
}

[Serializable]
public class ARObjects
{
    public string referenceImageName;
    public GameObject prefab;
}
