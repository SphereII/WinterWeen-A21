using UnityEngine;

public class DialogActionOpenDialogSDX : BaseDialogAction
{
    public override void PerformAction(EntityPlayer player)
    {
        var uiforPlayer = LocalPlayerUI.GetUIForPlayer(player as EntityPlayerLocal);
        uiforPlayer.windowManager.Open("HireInformation", true, false, true);
    }
}

public class DialogActionOpenWindowSDX : BaseDialogAction
{
    public override void PerformAction(EntityPlayer player)
    {
        var uiforPlayer = LocalPlayerUI.GetUIForPlayer(player as EntityPlayerLocal);
        uiforPlayer.windowManager.Open(ID, true, false, true);
    }

}
