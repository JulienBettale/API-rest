using API_rest.API.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace API_rest.API.Repositories
{
    public class RecipeRepository
    {
        // Constante de stockage de l'url.
        private const string ConnectionString = "Server=tcp:julienbettale.database.windows.net,1433;Initial Catalog=api-rest-db;Persist Security Info=False;User ID=AdminSQL;Password=azeqsd123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public List<Recipe> Read(string condition)
        {
            // Classe qui permet de créer une connexion à la base de donnée.
            SqlConnection connection = new SqlConnection();

            // On défini le chemin d'acces à la base.
            connection.ConnectionString = ConnectionString;

            // Classe qui permet d'excuter des requetes SQL.
            SqlCommand command = new SqlCommand();

            // On lie "command" à "connection".
            command.Connection = connection;

            var requete = "SELECT * FROM recipes__recipe";

            // On vérifie si (condition) est nul et vide
            if(condition != null && condition != "")
            {
                requete += " " + condition;
            }

            // CommandText -> on lui donne à la requete à exécuter (textuellement).
            command.CommandText = requete;

            // Ouvre la connexion.
            connection.Open();

            // Execute et retourne le résultat de la requete.
            SqlDataReader dataReader = command.ExecuteReader();

            // Créer une liste de recette qu'on va renvoyé au controller.
            List<Recipe> recipeListFromDataBase = new List<Recipe>();

            var repository = new UserRepository();

            while (dataReader.Read())
            {
                // Récupération des données.
                int id = (int)dataReader["id"];
                int userId = (int)dataReader["user_id"];
                string name = (string)dataReader["name"];
                string slug = (string)dataReader["slug"];
                //string step = (string)dataReader["step"];

                // Condition de récuparation des utilisateurs.
                string userCondition = "WHERE id = '" + userId + "'";
                
                // On utilise la fonction "read" qui permet d'allé chercher les utilisateurs.
                var userList = repository.Read(userCondition);

                // On créer un nouvel "recipe" et on le met dans la liste de recipe.
                var recipe = new Recipe(id, name, slug, userList[0]); // userList[0] = récupération de la permier valeur du tableau.
                recipeListFromDataBase.Add(recipe);
            };

            // Ferme la connexion.
            connection.Close();

            // renvoie la liste.
            return recipeListFromDataBase;
        }
    }
}
