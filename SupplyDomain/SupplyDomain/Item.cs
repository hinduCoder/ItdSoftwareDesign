using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyDomain
{
    class Item
    {
        private string name;
        private string description;
        private string article;

        public string Name
        {
            get { return name; }
        }

        public string Descripton
        {
            get { return description; }
        }

        public string Article
        {
            get { return article; }
        }

        public Item(string _name, string _description, string _article)
        {
            name = _name;
            description = _description;
            article = _article;
        }
    }
}
