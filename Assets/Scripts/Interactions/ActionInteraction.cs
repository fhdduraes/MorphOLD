using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class ActionInteraction : MonoBehaviour
{
    [Header("GameControllers")]
    public Camera playerView;
    public GameObject cellScreen;
    public Translation text;
    public GameObject Player;

    [Header("Bedroom")]
    public GameObject BedroomDoor;
    public GameObject BedroomSwitch;
    public GameObject BLampOn;
    public GameObject BLampOff;
    public GameObject WardrobeLD;
    public GameObject WardrobeRD;
    public GameObject WardrobeTD;
    public GameObject WardrobeDD;
    public GameObject Notebook;
    public GameObject NotebookOnPtbr;
    public GameObject NotebookOnEn;
    public GameObject NotebookOff;
    public GameObject Cellphone;
    public GameObject Medicine;
    public GameObject Bed;
    public GameObject Pill;

    [Header("Kitchen")]
    public GameObject KitchenDoor;
    public GameObject Fridge;
    public GameObject FridgeLights;
    public GameObject KitchenSwitch;
    public GameObject KLampOn;
    public GameObject KLampOff;
    public ParticleSystem Water;
    public GameObject Sink;
    public GameObject CabinetLeftDoor;

    [Header("Living Room")]
    public GameObject LivingRoomDoor;
    public GameObject LivingRoomSwitch;
    public GameObject LRLampOn;
    public GameObject LRLampOff;
    public GameObject LRDrawer;
    public GameObject Tv;

    public bool pillTaken;

    private bool medicineInteraction = true;
    public bool choose = false;
    private bool notebookActive = false;
    private bool cellphoneActive = false;
    float time = 0.2f;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (GlobalVariables.language == "en")
        {
            Destroy(NotebookOnPtbr.gameObject);
        }

        else if (GlobalVariables.language == "ptbr")
        {
            Destroy(NotebookOnEn.gameObject);
        }

        RaycastChecker();
        Controllers();
    }

    void RaycastChecker()
    {
        RaycastHit hit;

        if(!cellphoneActive)
        { 
            if (Physics.Raycast(playerView.transform.position, playerView.transform.forward, out hit, 2.0f))
            {
                if (hit.transform.name == BedroomDoor.name)
                {
                    if (BedroomDoor.GetComponent<LerpInteraction>().isOpenned)
                    {
                        text.textid = "Fechar a porta";
                    }

                    else if (!BedroomDoor.GetComponent<LerpInteraction>().isOpenned)
                    {
                        text.textid = "Abrir a porta";
                    }

                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        BedroomDoor.GetComponent<LerpInteraction>().action = true;
                    }
                }

                else if (hit.transform.name == KitchenDoor.name)
                {
                    if (KitchenDoor.GetComponent<LerpInteraction>().isOpenned)
                    {
                        text.textid = "Fechar a porta";
                    }

                    else if (!KitchenDoor.GetComponent<LerpInteraction>().isOpenned)
                    {
                        text.textid = "Abrir a porta";
                    }

                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        KitchenDoor.GetComponent<LerpInteraction>().action = true;
                    }
                }

                else if (hit.transform.name == WardrobeLD.name)
                {
                    if (WardrobeLD.GetComponent<LerpInteraction>().isOpenned)
                    {
                        text.textid = "Fechar a porta";
                    }

                    else if (!WardrobeLD.GetComponent<LerpInteraction>().isOpenned)
                    {
                        text.textid = "Abrir a porta";
                    }

                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        if (!WardrobeTD.GetComponent<LerpInteraction>().isOpenned && !WardrobeDD.GetComponent<LerpInteraction>().isOpenned && !WardrobeDD.GetComponent<LerpInteraction>().action && !WardrobeTD.GetComponent<LerpInteraction>().action)
                        {
                            WardrobeLD.GetComponent<LerpInteraction>().action = true;
                        }
                    }
                }

                else if (hit.transform.name == WardrobeRD.name)
                {
                    if (WardrobeRD.GetComponent<LerpInteraction>().isOpenned)
                    {
                        text.textid = "Fechar a porta";
                    }

                    else if (!WardrobeRD.GetComponent<LerpInteraction>().isOpenned)
                    {
                        text.textid = "Abrir a porta";
                    }

                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        if (!WardrobeTD.GetComponent<LerpInteraction>().isOpenned && !WardrobeDD.GetComponent<LerpInteraction>().isOpenned && !WardrobeDD.GetComponent<LerpInteraction>().action && !WardrobeTD.GetComponent<LerpInteraction>().action)
                        {
                            WardrobeRD.GetComponent<LerpInteraction>().action = true;
                        }
                    }
                }

                else if (hit.transform.name == WardrobeTD.name)
                {
                    if (WardrobeTD.GetComponent<LerpInteraction>().isOpenned)
                    {
                        text.textid = "Fechar a gaveta";
                    }

                    else if (!WardrobeTD.GetComponent<LerpInteraction>().isOpenned)
                    {
                        text.textid = "Abrir a gaveta";
                    }

                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        if (WardrobeLD.GetComponent<LerpInteraction>().isOpenned && WardrobeRD.GetComponent<LerpInteraction>().isOpenned && !WardrobeLD.GetComponent<LerpInteraction>().action && !WardrobeRD.GetComponent<LerpInteraction>().action)
                        {
                            WardrobeTD.GetComponent<LerpInteraction>().action = true;
                        }
                    }
                }

                else if (hit.transform.name == WardrobeDD.name)
                {
                    if (WardrobeDD.GetComponent<LerpInteraction>().isOpenned)
                    {
                        text.textid = "Fechar a gaveta";
                    }

                    else if (!WardrobeDD.GetComponent<LerpInteraction>().isOpenned)
                    {
                        text.textid = "Abrir a gaveta";
                    }

                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        if (WardrobeLD.GetComponent<LerpInteraction>().isOpenned && WardrobeRD.GetComponent<LerpInteraction>().isOpenned && !WardrobeLD.GetComponent<LerpInteraction>().action && !WardrobeRD.GetComponent<LerpInteraction>().action)
                        {
                            WardrobeDD.GetComponent<LerpInteraction>().action = true;
                        }
                    }
                }

                else if (hit.transform.name == BedroomSwitch.name)
                {
                    if (BedroomSwitch.GetComponent<LerpInteraction>().isOpenned)
                    {
                        text.textid = "Apagar a luz";
                    }

                    else if (!BedroomSwitch.GetComponent<LerpInteraction>().isOpenned)
                    {
                        text.textid = "Acender a luz";
                    }

                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        BedroomSwitch.GetComponent<LerpInteraction>().action = true;
                    }
                }

                else if (hit.transform.name == Notebook.name)
                {
                    if (notebookActive)
                    {
                        text.textid = "Desligar o notebook";
                    }

                    if (!notebookActive)
                    {
                        text.textid = "Ligar o notebook";
                    }

                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        if (notebookActive)
                        {
                            if (GlobalVariables.language == "ptbr")
                                NotebookOnPtbr.SetActive(false);
                            else if (GlobalVariables.language == "en")
                                NotebookOnEn.SetActive(false);

                            NotebookOff.SetActive(true);
                            notebookActive = false;
                        }

                        else if (!notebookActive)
                        {
                            if(GlobalVariables.language == "ptbr")
                                NotebookOnPtbr.SetActive(true);
                            else if (GlobalVariables.language == "en")
                                NotebookOnEn.SetActive(true);

                            NotebookOff.SetActive(false);
                            notebookActive = true;
                        }
                    }
                }

                else if (hit.transform.name == Cellphone.name)
                {
                    if (!cellphoneActive)
                    {
                        text.textid = "Verificar o celular";
                    }

                    if (Input.GetKeyDown(KeyCode.Mouse0) && !cellphoneActive)
                    {
                        Player.GetComponent<PlayerMovement>().enabled = false;
                        Cellphone.SetActive(false);
                        cellScreen.SetActive(true);
                        cellphoneActive = true;
                    }
                }

                else if(hit.transform.name == Medicine.name && medicineInteraction)
                {
                    if(!choose)
                        text.textid = "Parece que esse é o último";
                    else
                    {
                        text.textid = "Tomar o último remédio (Y/N)";

                        if (Input.GetKeyDown(KeyCode.Y))
                        {
                            pillTaken = true;
                            Destroy(Pill);
                            medicineInteraction = false;
                        }

                        else if (Input.GetKeyDown(KeyCode.N))
                        {
                            pillTaken = false;
                            medicineInteraction = false;
                        }
                    }
                }

                else if (hit.transform.name == Bed.name)
                {
                    text.textid = "Não quero dormir agora";
                }

                else if(hit.transform.name == Fridge.name)
                {
                    if (Fridge.GetComponent<LerpInteraction>().isOpenned)
                    {
                        text.textid = "Fechar o frigobar";
                    }

                    else if (!Fridge.GetComponent<LerpInteraction>().isOpenned)
                    {
                        text.textid = "Abrir o frigobar";
                    }

                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        Fridge.GetComponent<LerpInteraction>().action = true;

                        
                    }
                }

                else if (hit.transform.name == LivingRoomDoor.name)
                {
                    text.textid = "Não quero sair agora";
                }

                else if (hit.transform.name == KitchenSwitch.name)
                {
                    if (KitchenSwitch.GetComponent<LerpInteraction>().isOpenned)
                    {
                        text.textid = "Apagar a luz";
                    }

                    else if (!KitchenSwitch.GetComponent<LerpInteraction>().isOpenned)
                    {
                        text.textid = "Acender a luz";
                    }

                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        KitchenSwitch.GetComponent<LerpInteraction>().action = true;
                    }
                }

                else if (hit.transform.name == LivingRoomSwitch.name)
                {
                    if (LivingRoomSwitch.GetComponent<LerpInteraction>().isOpenned)
                    {
                        text.textid = "Apagar a luz";
                    }

                    else if (!LivingRoomSwitch.GetComponent<LerpInteraction>().isOpenned)
                    {
                        text.textid = "Acender a luz";
                    }

                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        LivingRoomSwitch.GetComponent<LerpInteraction>().action = true;
                    }
                }

                else if (hit.transform.name == Sink.name)
                {
                    if (Water.isPlaying)
                    {
                        text.textid = "Desligar a torneira";
                    }

                    else if (!Water.isPlaying)
                    {
                        text.textid = "Ligar a torneira";
                    }

                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        if (Water.isPlaying)
                        {
                            Water.Stop();
                        }

                        else if (!Water.isPlaying)
                        {
                            Water.Play();
                        }
                    }
                }

                else if (hit.transform.name == LRDrawer.name)
                {
                    text.textid = "Está trancada";
                }

                else if(hit.transform.name == Tv.name)
                {
                    if (!Tv.GetComponent<TurnOnTv>().action)
                    {
                        text.textid = "Ligar a tv";
                    }

                    else
                    {
                        text.textid = "";
                    }

                    if(Input.GetKeyDown(KeyCode.Mouse0))
                        Tv.GetComponent<TurnOnTv>().action = true;
                }

                else if(hit.transform.name == CabinetLeftDoor.name)
                {
                    if (CabinetLeftDoor.GetComponent<LerpInteraction>().isOpenned)
                    {
                        text.textid = "Fechar a porta";
                    }

                    else if (!CabinetLeftDoor.GetComponent<LerpInteraction>().isOpenned)
                    {
                        text.textid = "Abrir a porta";
                    }

                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        CabinetLeftDoor.GetComponent<LerpInteraction>().action = true;
                    }
                }

                else if(hit.collider == null)
                {
                    text.textid = "";
                }

                else
                {
                    text.textid = "";
                }

            }
        }
    }

    void Controllers()
    {
        if (BedroomSwitch.GetComponent<LerpInteraction>().isOpenned)
        {
            BLampOn.SetActive(true);
            BLampOff.SetActive(false);
        }

        else if (!BedroomSwitch.GetComponent<LerpInteraction>().isOpenned)
        {
            BLampOn.SetActive(false);
            BLampOff.SetActive(true);
        }

        if (cellphoneActive)
        {
            time -= Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Mouse0) && time <= 0)
            {
                Player.GetComponent<PlayerMovement>().enabled = true;
                cellScreen.SetActive(false);
                Cellphone.SetActive(true);
                cellphoneActive = false;
                time = 0.2f;
            }

            text.textid = "Fechar";
        }

        

        if (!Fridge.GetComponent<LerpInteraction>().isOpenned && Fridge.GetComponent<LerpInteraction>().action)
        {
            FridgeLights.SetActive(true);
        }

        else if (Fridge.GetComponent<LerpInteraction>().isOpenned)
        {
            FridgeLights.SetActive(true);
        }

        else if (!Fridge.GetComponent<LerpInteraction>().isOpenned && !Fridge.GetComponent<LerpInteraction>().action)
        {
            FridgeLights.SetActive(false);
        }

        if (KitchenSwitch.GetComponent<LerpInteraction>().isOpenned)
        {
            KLampOn.SetActive(true);
            KLampOff.SetActive(false);
        }

        else if (!KitchenSwitch.GetComponent<LerpInteraction>().isOpenned)
        {
            KLampOn.SetActive(false);
            KLampOff.SetActive(true);
        }


        if (LivingRoomSwitch.GetComponent<LerpInteraction>().isOpenned)
        {
            LRLampOn.SetActive(true);
            LRLampOff.SetActive(false);
        }

        else if (!LivingRoomSwitch.GetComponent<LerpInteraction>().isOpenned)
        {
            LRLampOn.SetActive(false);
            LRLampOff.SetActive(true);
        }
    }
}
