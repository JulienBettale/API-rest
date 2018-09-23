using API_rest.API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace API_rest.API.Repositories
{
    public class UserRepository
    {
            // Constante de stockage de l'url.
            private const string ConnectionString = "Server=tcp:julienbettale.database.windows.net,1433;Initial Catalog=api-rest-db;Persist Security Info=False;User ID=AdminSQL;Password=azeqsd123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            public List<User> Read(string condition)
            {
                // Classe qui permet de créer une connexion à la base de donnée.
                SqlConnection connection = new SqlConnection();

                // On défini le chemin d'acces à la base.
                connection.ConnectionString = ConnectionString;

                // Classe qui permet d'excuter des requetes SQL.
                SqlCommand command = new SqlCommand();

                // On lie "command" à "connection".
                command.Connection = connection;

                var requete = "SELECT * FROM users__user";

                // On vérifie si (condition) est nul et vide
                if (condition != null && condition != "")
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
                List<User> userListFromDataBase = new List<User>();

                while (dataReader.Read())
                {
                    // Récupération des données.
                    string username = (string)dataReader["username"];
                // int userId = (int)dataReader["user_id"];
                    DateTimeOffset last_login = (DateTimeOffset)dataReader["last_login"];

                    int id = (int)dataReader["id"];

                    var user = new User(username, last_login, id);
                    userListFromDataBase.Add(user);
                };

                // Ferme la connexion.
                connection.Close();

                // renvoie la liste.
                return userListFromDataBase;
            }
    }
}