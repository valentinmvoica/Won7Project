namespace Won7Project.Services
{
    public class SingletonService
    {
        public Guid Id { get;private set; }
        public SingletonService() { 
            Id = Guid.NewGuid();   
        }
    }
}
