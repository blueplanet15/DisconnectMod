using BepInEx;
using Photon.Pun;
using UnityEngine;
using UnityEngine.XR;

[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
public class DisconnectMod : BaseUnityPlugin
{
    void Start()
    {
        Logger.LogInfo($"Plugin {PluginInfo.GUID} is laoded!");
    }
    internal class PluginInfo
    {
        public const string GUID = "com.BP15.DisconnectMod";
        public const string Name = "Disconnect Mod";
        public const string Version = "1.0.0";
    }

    void Update()
    {
        if (IsButtonPressed(XRNode.LeftHand, CommonUsages.primaryButton) &&
            IsButtonPressed(XRNode.LeftHand, CommonUsages.secondaryButton) &&
            (IsButtonPressed(XRNode.RightHand, CommonUsages.primaryButton) &&
            IsButtonPressed(XRNode.RightHand, CommonUsages.secondaryButton)))
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
