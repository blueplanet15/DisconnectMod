using BepInEx;
using Photon.Pun;
using UnityEngine;
using UnityEngine.XR;

#nullable disable
[BepInPlugin("com.BP15.disconnectmod", "Disconnect Mod", "1.0.2")]
public class DisconnectMod : BaseUnityPlugin
{
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