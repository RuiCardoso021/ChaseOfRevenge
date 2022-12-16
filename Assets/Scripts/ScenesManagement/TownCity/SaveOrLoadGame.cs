using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveOrLoadGame : MonoBehaviour
{
    // Start is called before the first frame update
    Save_BlockSave SaveBlock;
    Save_Town_GameProgress SaveTown;
    UnblockMapAreas UnblockMapAreas;

    private void Awake()
    {
        UnblockMapAreas = GameObject.Find("AreasBlock").GetComponent<UnblockMapAreas>();
        SaveTown = GameObject.Find("Play").GetComponent<Save_Town_GameProgress>();
        SaveBlock = GameObject.Find("Play").GetComponent<Save_BlockSave>();
    }

    private void Start()
    {

    }

    // Update is called once per frame
    public void SaveGame()
    {
        if (SaveBlock != null && SaveTown != null)
        {
            SaveBlock.SaveWinsIfClose();
            SaveTown.SavePosAndRotPlayerIfClose();          
        }
    }

    public void LoadGame()
    {
        if (SaveBlock != null && SaveTown != null)
        {
            SaveTown.SavePermissionLoad(true);
            UnblockMapAreas.wins = SaveBlock.getWinsIfClose();
            SaveTown.LoadPosAndRotPlayer();
            TransferGameObject.Instance.ReloadTownScene();
        }
    }
}
