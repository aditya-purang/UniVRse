using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AssetGenerator :ScriptableObject
{
    public string FolderPath;

    protected abstract void generateAssets();
    

    public void generate()
    {
        //delete everything from folderpath
        AssetUtility.clearAssetFolder(FolderPath);

        generateAssets();
    }
}
