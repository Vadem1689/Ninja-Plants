using System;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private int _statusPoint= (int)ZoneStatus.None;
    private int _currentIndexModelPlant;
    private bool _isBusy;
    private Plant _plant;

    public bool IsBusy => _isBusy;
    public int StatusPoint => _statusPoint;

    public  Action OnChangeStatus;
    public Plant Plant=> _plant;

    public void SetPlant(Plant plant)
    {
        _plant = plant;
        IdentifyStatus(_plant);
        SetStatus();
    }

    public void DeletePlant()
    {
        _plant = null;
        SetStatus();
        _statusPoint =(int) ZoneStatus.None;
    }

    private void SetStatus()
    {
        if (_plant != null)
        {
            _isBusy = true;
        }
        else
        {
            _isBusy = false;
        }
    }

    private void IdentifyStatus(Plant plant)
    {
        foreach (ZoneStatus zoneStatus in System.Enum.GetValues(typeof(ZoneStatus)))
        {

            if (plant.CurrentIndexFruit == (int)zoneStatus)
            {
                _statusPoint = (int)zoneStatus;
                _currentIndexModelPlant = plant.CurrentIndexPlant;

                OnChangeStatus?.Invoke();
            }
        }
    }
}
