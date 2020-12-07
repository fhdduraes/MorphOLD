using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TurnOnTv : MonoBehaviour
{
    public bool action = false;
    public bool stop = false;
    public GameObject LivingRoomCollider;
    public ActionInteraction interaction;

    public GameObject tvOff;
    public BoxCollider tvCollider;

    public GameObject tvOnPtbr;
    public VideoPlayer newsPtbr;

    public GameObject tvOnEn;
    public VideoPlayer newsEn;


    private void Start()
    {
        tvOff.SetActive(true);
        tvOnPtbr.SetActive(false);
        tvOnEn.SetActive(false);

        if (GlobalVariables.language == "en")
        {
            Destroy(tvOnPtbr);
            Destroy(newsPtbr.gameObject);
            newsEn.Prepare();
        }

        if(GlobalVariables.language == "ptbr")
        {
            Destroy(tvOnEn);
            Destroy(newsEn.gameObject);
            newsPtbr.Prepare();
        }
    }

    private void Update()
    {
        if (action && !stop)
        {
            if(GlobalVariables.language == "ptbr")
            {
                if (newsPtbr.time >= newsPtbr.length - 0.5f)
                {
                    stop = true;

                    Destroy(newsPtbr);
                    Destroy(tvOnPtbr);
                    Destroy(tvCollider);
                    Destroy(LivingRoomCollider);
                    interaction.choose = true;
                    tvOff.SetActive(true);
                }

                else
                {
                    newsPtbr.Play();

                    tvOff.SetActive(false);
                    tvOnPtbr.SetActive(true);
                }
            }

            if (GlobalVariables.language == "en")
            {
                if (newsEn.time >= newsEn.length - 0.5f)
                {
                    stop = true;
                    Destroy(newsEn);
                    Destroy(tvOnEn);
                    Destroy(tvCollider);
                    Destroy(LivingRoomCollider);
                    interaction.choose = true;
                    tvOff.SetActive(true);
                }

                else
                {
                    newsEn.Play();

                    tvOff.SetActive(false);
                    tvOnEn.SetActive(true);
                }
            }
        }
    }
}
