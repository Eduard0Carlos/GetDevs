namespace Shared.Results
{
    public class DbResult : Result
    {
        public int ID { get; set; }

        public override string ToString()
        {
            return this.Message;
        }
    }
}
