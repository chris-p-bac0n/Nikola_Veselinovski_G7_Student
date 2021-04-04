namespace RaceCars.Classes
{
    public class Car
    {
        public string Model { get; set; }
        public int Speed { get; set; }
        public Driver Driver { get; set; }

       //public car(string model, int speed)
       // {
       //     model = model;
       //     speed = speed;            
       // }
        public int CalculateSpeed(object driver)
        {
            int carSpeed = Driver.Skill * Speed;
            return carSpeed;
        }
    }        

}
