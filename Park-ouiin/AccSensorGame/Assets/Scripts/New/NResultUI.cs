using UnityEngine;

public class NResultUI
{
    public GameObject restartbtn;
    public GameObject quitbtn;

    public void MakeResult()
    {
        restartbtn = NShare.Util.InstantiatePrefab(NShare.Path.Prefab.Restartbtn, NUIRoot.resultCanvas);
        quitbtn = NShare.Util.InstantiatePrefab(NShare.Path.Prefab.Quitbtn, NUIRoot.resultCanvas);
    }
}
