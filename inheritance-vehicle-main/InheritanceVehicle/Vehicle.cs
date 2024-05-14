namespace InheritanceVehicle
{
    public class Vehicle
    {
        private readonly int maxSpeed;
        private string name;

        public Vehicle(string name, int maxSpeed)
        {
            this.name = name;
            this.maxSpeed = maxSpeed;
        }

        public int MaxSpeed
        {
            get
            {
                return this.maxSpeed;
            }
        }

        protected string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }
    }
}
