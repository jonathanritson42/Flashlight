using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalAudioController : MonoBehaviour
{
    
    public GameObject HallwayReverb;
    public GameObject KitchenReverb;
    public GameObject DefaultReverb;
    public int ReverbZoneActive = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        KitchenReverb.SetActive(false);
        HallwayReverb.SetActive(false);
        DefaultReverb.SetActive(true);
    }




    public void SwitchReverb(int ZoneToActivate)
    {
        ReverbZoneActive = ZoneToActivate;
        switch (ReverbZoneActive)
        {
            default:
                break;
            case 0:
                KitchenReverb.SetActive(false);
                HallwayReverb.SetActive(false);
                DefaultReverb.SetActive(true);
                break;
            case 1:
                HallwayReverb.SetActive(true);
                KitchenReverb.SetActive(false);
                DefaultReverb.SetActive(false);

                break;
            case 2:
                HallwayReverb.SetActive(false);
                KitchenReverb.SetActive(true);
                DefaultReverb.SetActive(false);
                break;

            
        } 
        
    }

}
