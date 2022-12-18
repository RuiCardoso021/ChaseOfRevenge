using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveOrLoadGame : MonoBehaviour
{
    // Start is called before the first frame update
    SaveGameProgress SaveTown;
    UnblockMapAreas UnblockMapAreas;

    private void Awake()
    {
        UnblockMapAreas = GameObject.Find("AreasBlock").GetComponent<UnblockMapAreas>();
        SaveTown = GameObject.Find("Play").GetComponent<SaveGameProgress>();
    }

    // Update is called once per frame
    public void SaveGame()
    {
        if (SaveTown != null)
        {
            SaveTown.SaveWinsIfClose();
            SaveTown.SavePosAndRotPlayerIfClose();          
        }
    }

    public void LoadGame()
    {
        if (SaveTown != null)
        {
            SaveTown.SavePermissionLoad(true);
            UnblockMapAreas.wins = SaveTown.getWinsIfClose();
            SaveTown.LoadPlayer();
            TransferGameObject.Instance.ReloadTownScene();
        }
    }

}
