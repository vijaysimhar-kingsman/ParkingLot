using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    internal class ParkingTicket
    {
        public string _vehicleNumberPlate { get; set; }
        public VehicleType _slotNumber { get; set; }
        public DateTime _inTime { get; set; }
        public DateTime _outTime { get; set; }

        public ParkingTicket(string vehicleNumberPlate = "", VehicleType slotNumber = VehicleType.TwoWheeler, DateTime? inTime = null, DateTime? outTime = null)
        {
            _vehicleNumberPlate = vehicleNumberPlate;
            _slotNumber = slotNumber;
            _inTime = inTime ?? DateTime.MinValue;
            _outTime = outTime ?? DateTime.MinValue;
        }
    }

    internal class Vehicle
    {
        public VehicleType _vehicleType { get; set; }
        public string _vehicleNumberPlate { get; set; }


        public Vehicle(VehicleType vehicleType, string vehicleNumberPlate)
        {
            _vehicleType = vehicleType;
            _vehicleNumberPlate = vehicleNumberPlate;
        }
    }

    internal class ParkingSlot  
    {
        public int twoWheelerSlots { get; set; }
        public int fourWheelerSlots { get; set; }
        public int heavyVehicleSlots { get; set; }
        public ParkingSlot(int _twoWheelerSlots, int _fourWheelerSlots, int _heavyVehicleSlots)
        {
            twoWheelerSlots = _twoWheelerSlots;
            fourWheelerSlots = _fourWheelerSlots;
            heavyVehicleSlots = _heavyVehicleSlots;
        }
    }

    enum VehicleType
    {
        TwoWheeler,
        FourWheerler,
        HeavyVehicle,
        None
    }
}
