namespace SupplyDomain.Entities
{
    public class Item : Entity
    {
        private string _name;
        private string _description;
        private string _article;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Descripton
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Article
        {
            get { return _article; }
            set { _article = value; }
        }

        public Item(string name, string description, string article)
        {
            _name = name;
            _description = description;
            _article = article;
        }
    }
}
