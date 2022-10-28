namespace Unit_Testing_in_.Net_SD_125_W22SD_Lab1_Unit_Test
{
    [TestClass]
    public class UnitTest1
    {
        Vehicle Vehicle1 = new Vehicle("gds 245", true);
        VehicleTracker newVehicleTracker = new VehicleTracker(10, "123 Fake Street");

        [TestMethod]
        public void VehicleTracker_GenerateSlots_nullSlotWhenInitialized()
        {
            newVehicleTracker.GenerateSlots();

            foreach (KeyValuePair<int, Vehicle> vehicle in newVehicleTracker.VehicleList)
            {
                Assert.AreEqual(vehicle.Value, null);
            }
        }

        [TestMethod]
        public void VehicleTracker_AddVehicle_addTheVehicleToTheFirstSlotInVehicleList()
        {
            newVehicleTracker.AddVehicle(Vehicle1);
        }
        //RemoveVehicle should accept either a licence or slot number, and set that slot’s vehicle to “null”.
        [TestMethod]
        public void VehicleTracker_RemoveVehicle_AcceptEitherALicenceOrSlotNumber()
        {
            int slotAssociatedWithLicence;

            newVehicleTracker.RemoveVehicle(Vehicle1.Licence);

            foreach(KeyValuePair<int, Vehicle> vehicle in newVehicleTracker.VehicleList)
            {
                if(vehicle.Value.Licence == Vehicle1.Licence)
                {
                    slotAssociatedWithLicence = vehicle.Key;
                }
            }

            Assert.AreEqual(newVehicleTracker.VehicleList[slotAssociatedWithLicence], null);

            newVehicleTracker.RemoveVehicle(2);

            Assert.AreEqual(newVehicleTracker.VehicleList[2], null);
        }
        //RemoveVehicle should throw an exception if the licence passed to RemoveVehicle() is not found, if the slot number is
        //invalid(greater than capacity or negative), or the slot is not filled.
        [TestMethod]
        public void VehicleTracker_RemoveVehicle_InvalidInput()
        {
            Assert.ThrowsException<KeyNotFoundException>(() => newVehicleTracker.RemoveVehicle(100));
            Assert.ThrowsException<KeyNotFoundException>(() => newVehicleTracker.RemoveVehicle("drf 234"));
            Assert.ThrowsException<KeyNotFoundException>(() => newVehicleTracker.RemoveVehicle(1));
        }
        [TestMethod]
        public void VehicleTracker_SlotsAvailable_ProperNumberOfSlotsAvailable()
        {
            public int SlotsAvailable = 10;

           Assert.AreEqual(newVehicleTracker.SlotsAvailable, SlotsAvailable);
        }

        [TestMethod]
        //The VehicleTracker.ParkedPassholders() method should return a list of all parked vehicles that have a pass
        public void VehicleTracker_ParkedPassholders()
        {
            List<Vehicle> testList = new List<Vehicle>();
            testList.Add(Vehicle1);

            newVehicleTracker.AddVehicle(Vehicle1);

            Assert.AreEqual(testList, newVehicleTracker.ParkedPassholders());
        }

        [TestMethod]
        public void VehicleTracker_ParkedPassholders()
        {
            public int testPercent = 10;
            newVehicleTracker.AddVehicle(Vehicle1);

            Assert.AreEqual(testPercent, newVehicleTracker.PassholderPercentage());
        }
    }
}


    