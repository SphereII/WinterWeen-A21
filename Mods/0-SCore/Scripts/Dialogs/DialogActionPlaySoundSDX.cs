using Audio;
using UnityEngine;

public class DialogActionPlaySoundSDX : BaseDialogAction
{
    private static string _lastSound = "";

    public override void PerformAction(EntityPlayer player)
    {
        // we want to make sure the sound is not playing anymore before starting a new one.
        if (!string.IsNullOrEmpty(_lastSound))
        {
            player.StopOneShot(_lastSound);
        }
        player.PlayOneShot(ID, false);
        _lastSound = ID;
    }
}