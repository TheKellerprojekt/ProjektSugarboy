using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ActivateLaserDoor : MonoBehaviour
{
    [SerializeField] private Text[] text = new Text[2];

    [SerializeField] private GameObject[] doors = new GameObject[2];
    [SerializeField] private Material openDoor;
    [SerializeField] private Material closedDoor;
    [SerializeField] private GameObject[] lights = new GameObject[4];

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Contains("Player"))
        {
            for (int i = 0; i < doors.Length; i++)
            {
                if (doors[i] != null)
                {
                    switch (doors[i].name)
                    {
                        case "elevator":

                            doors[i].GetComponent<Animator>().SetBool("activated", true);
                            text[i].text = "Lift\nin\nuse";
                            text[i].color = Color.green;
                            break;

                        case "mainplate":

                            doors[i].GetComponent<Animator>().SetBool("activated", true);
                            text[i].text = "Caution\nbridge\nextends";
                            text[i].color = Color.green;
                            break;

                        default:

                            doors[i].SetActive(false);
                            text[i].text = "open";
                            text[i].color = Color.green;
                            break;
                    }
                }
            }
            for (int i = 0; i < lights.Length; i++)
            {
                if (lights[i] != null)
                {
                    lights[i].GetComponent<Renderer>().material = openDoor;
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Contains("Player"))
        {
            for (int i = 0; i < doors.Length; i++)
            {
                if (doors[i] != null)
                {
                    switch (doors[i].name)
                    {
                        case "elevator":

                            doors[i].GetComponent<Animator>().SetBool("activated", false);
                            text[i].text = "Lift\nnot\nin\nuse";
                            text[i].color = Color.red;
                            break;

                        case "mainplate":
                            doors[i].GetComponent<Animator>().SetBool("activated", false);
                            text[i].text = "Caution\nbridge\nnot in\nuse";
                            text[i].color = Color.red;

                            break;

                        default:
                            doors[i].SetActive(true);
                            text[i].text = "closed";
                            text[i].color = Color.red;
                            break;
                    }
                }
            }
            for (int i = 0; i < lights.Length; i++)
            {
                if (lights[i] != null)
                {
                    lights[i].GetComponent<Renderer>().material = closedDoor;
                }
            }
        }
    }
}