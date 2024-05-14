namespace InheritanceVehicle
{
    public class Car : Vehicle
    {
        public Car(string name, int maxSpeed)
            : base(name, maxSpeed)
        {
        }

        public void ChangeName(string newName)
        {
            this.Name = newName;
        }

        public string DisplayName()
        {
            return this.Name;
        }
    }
}
