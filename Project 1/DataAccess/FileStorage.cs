using System.Text.Json;
namespace DataAccess;
// In this project, all we'll do is getting and persisting data
// Code in this project will not be doing any of the following
// - Input Validation
// - Console I/O
// - Any complex application logic


public interface IRepository
{
    /// <summary>
    /// Retrieves all workout sessions
    /// </summary>
    /// <returns>a list of workout sessions</returns>
    //List<WorkoutSession> GetAllWorkouts();

    /// <summary>
    /// Persists a new workout session to storage
    /// </summary>
    //void CreateNewSession(WorkoutSession sessionToCreate);
}


public class FileStorage
{
    private const string _filePath = "../DataAccess/Users.json";
    public FileStorage() {
        bool fileExists = File.Exists(_filePath);

        if(!fileExists) {
            var fs = File.Create(_filePath);
            fs.Close();
        }
    }
}
/*
    public List<WorkoutSession> GetAllWorkouts() {
        // Open the file, read the content, close the file
        string fileContent = File.ReadAllText(_filePath);

        // The read string, and deserialize it back to List of workout sessions
        return JsonSerializer.Deserialize<List<WorkoutSession>>(fileContent);
    }

    public void CreateNewSession(WorkoutSession sessionToCreate) {
        // Reading from an existing file and deserializing it as list of workout
        List<WorkoutSession> sessions = GetAllWorkouts();
        // Adding new workout session
        sessions.Add(sessionToCreate);

        // Serializing the list as string and writing it back to the file
        string content = JsonSerializer.Serialize(sessions);
        File.WriteAllText(_filePath, content);
  
   }
}*/ 
