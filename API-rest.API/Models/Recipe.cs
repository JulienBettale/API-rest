using System;

namespace API_rest.API.Models
{
    public class Recipe
    {

        public Recipe(int id, string name, string slug, User user)
        {
            this.id = id;
            this.name = name;
            this.slug = slug;
            this.user = user;
            //this.step = step;
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

        private User user;

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        private string slug;

        public string Slug
        {
            get { return slug; }
            set { slug = value; }
        }

        //private string step;

        //public string Step
        //{
        //    get { return step; }
        //    set { step = value; }
        //}

    }

    public class User
    {
        public User(string userName, DateTimeOffset lastLogin, int id)
        {
            this.userName = userName;
            this.lastLogin = lastLogin;
            this.id = id;
        }

        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private DateTimeOffset lastLogin;

        public DateTimeOffset LastLogin
        {
            get { return lastLogin; }
            set { lastLogin = value; }
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
