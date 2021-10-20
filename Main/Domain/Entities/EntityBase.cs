namespace Domain.Entities
{
    public class EntityBase
    {
        public int Id { get; protected set; }

        public void SetId(int id)
        {
            this.Id = id;
        }
    }
}
