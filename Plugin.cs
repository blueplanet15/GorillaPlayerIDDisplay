using System;
using BepInEx;
using Photon.Pun;
using TMPro;

namespace GorillaPlayerIDDisplay
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class PlayerIDDisplay : BaseUnityPlugin
    {

        void Start()
        {
            PhotonNetwork.LocalPlayer.SetCustomProperties(new ExitGames.Client.Photon.Hashtable()
            {
                {
                    PluginInfo.Name,
                    PluginInfo.Version
                }
            }, null, null);
            Logger.LogInfo($"Plugin {PluginInfo.GUID} is loaded!");
        }

        private void Update()
        {
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
