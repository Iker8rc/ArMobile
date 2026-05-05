using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System.Collections;

public class Prueba : MonoBehaviour
{
    [SerializeField]
    private ARTrackedImageManager trackedImageManager;
    [SerializeField]
    private ARObjects[] objets;

    private bool fight1 = false;
    private bool fight2 = false;
    private bool fight3 = false;
    private bool fight4 = false;

    private GameObject pref1;
    private GameObject pref2;
    private Animator animator1;
    private Animator animator2;

    private GameObject pref3;
    private GameObject pref4;
    private Animator animator3;
    private Animator animator4;

    private GameObject pref5;
    private GameObject pref6;
    private Animator animator5;
    private Animator animator6;

    private GameObject pref7;
    private GameObject pref8;
    private Animator animator7;
    private Animator animator8;

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
        if (pref1 != null && pref2 != null && fight1 == false)
        {
            fight1 = true;
            StartCoroutine(Combate1());
            pref1.transform.LookAt(pref2.transform);
            pref2.transform.LookAt(pref1.transform);
            animator1.SetBool("Fight", true);
            Debug.Log(animator1.GetCurrentAnimatorStateInfo(0));
            animator2.SetBool("Fight", true);
            Debug.Log(animator2.GetCurrentAnimatorStateInfo(0));
        }

        if (pref3 != null && pref4 != null && fight2 == false)
        {
            fight2 = true;
            StartCoroutine(Combate2());
            pref3.transform.LookAt(pref4.transform);
            pref4.transform.LookAt(pref3.transform);
            animator3.SetBool("Fight", true);
            animator4.SetBool("Fight", true);
        }

        if (pref5 != null && pref6 != null && fight3 == false)
        {
            fight3 = true;
            StartCoroutine(Combate3());
            pref5.transform.LookAt(pref6.transform);
            pref6.transform.LookAt(pref5.transform);
            animator5.SetBool("Fight", true);
            animator6.SetBool("Fight", true);
        }

        if (pref7 != null && pref8 != null && fight4 == false)
        {
            fight4 = true;
            StartCoroutine(Combate4());
            pref7.transform.LookAt(pref8.transform);
            pref8.transform.LookAt(pref7.transform);
            animator7.SetBool("Fight", true);
            animator8.SetBool("Fight", true);
        }
    }
    IEnumerator Combate1()
    {
        yield return new WaitForSeconds(10f);
        animator1.SetBool("Fight", false);
        animator2.SetBool("Fight", false);
        animator2.SetTrigger("Idle");
        animator1.SetTrigger("Dead");
    }
    IEnumerator Combate2()
    {
        yield return new WaitForSeconds(10f);
        animator3.SetBool("Fight", false);
        animator4.SetBool("Fight", false);
        animator4.SetTrigger("Idle");
        animator3.SetTrigger("Dead");
    }
    IEnumerator Combate3()
    {
        yield return new WaitForSeconds(10f);
        animator5.SetBool("Fight", false);
        animator6.SetBool("Fight", false);
        animator6.SetTrigger("Idle");
        animator5.SetTrigger("Dead");
    }
    IEnumerator Combate4()
    {
        yield return new WaitForSeconds(10f);
        animator7.SetBool("Fight", false);
        animator8.SetBool("Fight", false);
        animator8.SetTrigger("Idle");
        animator7.SetTrigger("Dead");
    }

    void OnTrackedChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventargs)
    {
        foreach (var newImage in eventargs.added) //para repasar todas las img que se han a�adido.
        {
            for(int i = 0; i < objets.Length; i++)
            {
                if (objets[i].referenceImageName == newImage.referenceImage.name)
                {
                    if (pref1 == null)
                    {
                        pref1 = Instantiate(objets[i].prefab, newImage.transform.position, newImage.transform.rotation);
                        animator1 = pref1.GetComponent<Animator>();
                        Debug.Log(animator1.name);
                    }
                    else if (pref2 == null)
                    {
                        pref2 = Instantiate(objets[i].prefab, newImage.transform.position, newImage.transform.rotation);
                        animator2 = pref2.GetComponent<Animator>();
                        Debug.Log(animator2.name);
                    }
                    else if (pref3 == null)
                    {
                        pref3 = Instantiate(objets[i].prefab, newImage.transform.position, newImage.transform.rotation);
                        animator3 = pref3.GetComponent<Animator>();
                    }
                    else if (pref4 == null)
                    {
                        pref4 = Instantiate(objets[i].prefab, newImage.transform.position, newImage.transform.rotation);
                        animator4 = pref4.GetComponent<Animator>();
                    }
                    else if (pref5 == null)
                    {
                        pref5 = Instantiate(objets[i].prefab, newImage.transform.position, newImage.transform.rotation);
                        animator5 = pref5.GetComponent<Animator>();
                    }
                    else if (pref6 == null)
                    {
                        pref6 = Instantiate(objets[i].prefab, newImage.transform.position, newImage.transform.rotation);
                        animator6 = pref6.GetComponent<Animator>();
                    }
                    else if (pref7 == null)
                    {
                        pref7 = Instantiate(objets[i].prefab, newImage.transform.position, newImage.transform.rotation);
                        animator7 = pref7.GetComponent<Animator>();
                    }
                    else 
                    {
                        pref8 = Instantiate(objets[i].prefab, newImage.transform.position, newImage.transform.rotation);
                        animator8 = pref8.GetComponent<Animator>();
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
            
            for (int i = 0; i < objets.Length; i++)
            {
                if (objets[i].referenceImageName == newImage.referenceImage.name && pref1 == null)
                {
                    pref1 = Instantiate(objets[i].prefab, newImage.transform.position, newImage.transform.rotation);
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
