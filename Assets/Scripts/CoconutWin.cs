using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class CoconutWin : MonoBehaviour
{
    public static int targets = 0;
    public static bool haveWon = false;

    public AudioClip winSound;
    public GameObject cellPrefab; 
    public GameObject targetCell; 

    // NOWE POLE: Wpisz tu wartoœci obrotu w Inspectorze (np. 0, 0, 90)
    public Vector3 fixRotation = new Vector3(0, 90, 0);

    void Update()
    {
        if(targets == 3 && !haveWon) 
        {
            targets = 0; 
            
            GetComponent<AudioSource>().PlayOneShot(winSound);

            if (targetCell != null)
            {
                // U¿ywamy rotacji wpisanej przez Ciebie w Inspectorze
                Quaternion finalRotation = transform.rotation * Quaternion.Euler(fixRotation);

                GameObject newPowerCell = Instantiate(cellPrefab, targetCell.transform.position, finalRotation) as GameObject;
                
                // Usuniêto zmianê skali (skoro rozmiar jest OK)
                // newPowerCell.transform.localScale = ... 

                newPowerCell.SetActive(true);
                
                Destroy(targetCell);
                
                haveWon = true;
            }
            else
            {
                // Fallback
                GameObject fallback = transform.Find("powerCell").gameObject;
                if(fallback != null)
                {
                     Quaternion finalRotation = transform.rotation * Quaternion.Euler(fixRotation);
                     GameObject newPowerCell = Instantiate(cellPrefab, fallback.transform.position, finalRotation) as GameObject;
                     
                     newPowerCell.SetActive(true);
                     Destroy(fallback);
                     haveWon = true;
                }
            }
        }
    }
}