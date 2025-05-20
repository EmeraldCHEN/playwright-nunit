using System;
using System.IO;
using Newtonsoft.Json;

namespace PlaywrightTests.Utilitis
{
    // Credentials class with required properties
    public class Credentials
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }

    public static class ConfigLoader
    {
        public static Credentials LoadCredentials(string path = "config/credentials.json")
        {
            try
            {
                // Read JSON from the file
                var json = File.ReadAllText(path);

                // Deserialize the JSON to Credentials object
                var credentials = JsonConvert.DeserializeObject<Credentials>(json);

                // Validate that the deserialized object is correct
                if (credentials == null)
                {
                    throw new InvalidDataException("The credentials file could not be parsed.");
                }

                // Validate required properties manually
                if (string.IsNullOrWhiteSpace(credentials.Username) || string.IsNullOrWhiteSpace(credentials.Password))
                {
                    throw new InvalidDataException("Both Username and Password are required.");
                }

                return credentials;
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException($"The credentials file '{path}' was not found.");
            }
            catch (JsonException)
            {
                throw new InvalidDataException("There was an issue parsing the credentials JSON file. Ensure it is correctly formatted.");
            }
            catch (Exception ex)
            {
                // Catch any unexpected errors
                throw new InvalidOperationException("An error occurred while loading credentials.", ex);
            }
        }
    }
}
