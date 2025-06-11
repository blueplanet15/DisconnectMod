using BepInEx;
using Photon.Pun;
using UnityEngine;
using UnityEngine.XR;

namespace DisconnectMod
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class DisconnectMod : BaseUnityPlugin
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
            Logger.LogInfo($"Plugin {PluginInfo.GUID} is laoded!");
        }

        void Update()
        {
            if (IsButtonPressed(XRNode.RightHand, CommonUsages.primaryButton) &&
                IsButtonPressed(XRNode.RightHand, CommonUsages.secondaryButton))
            {
                DisconnectFromRoom();
            }
        }

        bool IsButtonPressed(XRNode node, InputFeatureUsage<bool> button)
        {
            InputDevice device = InputDevices.GetDeviceAtXRNode(node);
            if (device.TryGetFeatureValue(button, out bool pressed))
            {
                return pressed;
            }
            return false;
        }

        private void DisconnectFromRoom()
        {
            PhotonNetwork.Disconnect();
            Debug.Log((object)"Player disconnected from the room.");
        }
    }
}
