namespace TEQTechnicalAssessment.Domain.SharedKernel
{
    public abstract class Entity<T> : IEntity
    {
        public Entity(T id)
        {
            Id = id;
        }

        public T Id { get; protected set; }
    }
}
