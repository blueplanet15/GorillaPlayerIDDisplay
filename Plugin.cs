using System;
using BepInEx;
using TMPro;

namespace GorillaPlayerIDDisplay
{
    [BepInPlugin("com.BP15.gorillatag.ShowPlayerIDs", "Player ID Display", "1.0.0")]
    public class PlayerIDDisplay : BaseUnityPlugin
    {
        private void Update()
        {
            // Show IDs for all other players
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig == null || vrrig.isOfflineVRRig) continue;

                string playerIdText = $"ID: {vrrig?.Creator?.UserId}";

                if (!vrrig.playerText1.text.Contains(playerIdText))
                    vrrig.playerText1.text += $"\n<color=#40E0D0>{playerIdText}</color>";

                if (!vrrig.playerText2.text.Contains(playerIdText))
                    vrrig.playerText2.text += $"\n{playerIdText}";
            }

            if (GorillaTagger.Instance != null && GorillaTagger.Instance.offlineVRRig != null)
            {
                VRRig localRig = GorillaTagger.Instance.offlineVRRig;
                string localId = $"ID: {localRig?.Creator?.UserId ?? "Unknown"}";

                if (!localRig.playerText1.text.Contains(localId))
                    localRig.playerText1.text += $"\n<color=#40E0D0>{localId}</color>";

                if (!localRig.playerText2.text.Contains(localId))
                    localRig.playerText2.text += $"\n{localId}";
            }
        }
    }
}
