namespace TestMacroPay.Models
{
    public class AdressBook
    {
        public string id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public List<string> addressLines { get; set; }
    }
}
