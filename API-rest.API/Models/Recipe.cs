namespace API_rest.API.Models
{
    public class Recipe
    {

        public Recipe(int id, string name, string slug)
        {
            this.id = id;
            this.name = name;
            this.slug = slug;
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string slug;

        public string Slug
        {
            get { return slug; }
            set { slug = value; }
        }
    }
}
