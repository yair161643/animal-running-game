using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiAnimals : MonoBehaviour
{
    public GameObject deerButton;
    public GameObject tigerButton;
    public GameObject eagleButton;
    public GameObject runningKid;
    public GameObject runningDeer;
    public GameObject runningTiger;
    public GameObject runningEagle;


    // Start is called before the first frame update
    void Start()
    {
        Button buttonOfDeer = deerButton.GetComponent<Button>();
        if (buttonOfDeer != null)
        {
            buttonOfDeer.onClick.AddListener(OnDeerButtonClicked);
        }
        Button buttonOfTiger = tigerButton.GetComponent<Button>();
        if (buttonOfTiger != null)
        {
            buttonOfTiger.onClick.AddListener(OnTigerButtonClicked);
        }
        Button buttonOfEagle = eagleButton.GetComponent<Button>();
        if (buttonOfEagle != null)
        {
            buttonOfEagle.onClick.AddListener(OnEagleButtonClicked);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDeerButtonClicked()
    {
        runningKid.SetActive(false);
        runningDeer.SetActive(true);
        runningTiger.SetActive(false);
        runningEagle.SetActive(false);
        Debug.Log("dear Switch");
    }
    private void OnTigerButtonClicked()
    {
        runningKid.SetActive(false);
        runningDeer.SetActive(false);
        runningTiger.SetActive(true);
        runningEagle.SetActive(false);
        Debug.Log("dear Switch");
    }
    private void OnEagleButtonClicked()
    {
        runningKid.SetActive(false);
        runningDeer.SetActive(false);
        runningTiger.SetActive(false);
        runningEagle.SetActive(true);
        Debug.Log("dear Switch");
    }
}
