namespace ToDo;
/*

use and array to collect data, we are going to use array. 
This is the initalization of an array with ten possible spots.
Arrays are imutable, once it is declared it can not change the size of the array, we can not increase the size dynamically. 
We can make a larger array if nessessary, and then move the items to the new array.
*/

/*
We can also use a list instead of a array, list is an array with 


*/

public class MainMenu 
{

        public void Start()

        {

                    Task[] tasklist = new Task[10];
                    int taskCount = 0;

                    while(true)
                    {
                        Console.WriteLine("Please input a task to do: ");
                        string inputTask = Console.ReadLine()!;
                        Task newTask = new Task();
                        newTask.Description = inputTask;
                        //check to see, and resize if needed.
                        if(tasklist.Length == taskCount) resizeArray(tasklist);
                        Console.WriteLine("What is the status of this task?\n is the task completed?\n y for yes \n n for no");
                        string taskStatus = Console.ReadLine()!;
                            if(taskStatus == "y") newTask.Status = "Done";
                            else newTask.Status = "Pending";
                        
                        
                        tasklist[taskCount] = newTask;
                        taskCount++;
                        Console.WriteLine("Would you like to add another item? type n for NO");
                        // if you add a quesstion mark at the end of your string typeing then it will allow a null.
                        string? resp = Console.ReadLine();
                        if (resp == "n") break;
                        
                    }
                    try{
                    for(int i = 0; i < tasklist.Length; i++) {
                        Console.WriteLine("Description: {0}, Status: {1}", tasklist[i].Description, tasklist[i].Status);
                    }

                    }
                    catch(System.NullReferenceException e){
                    Console.WriteLine("\nThank you for using ToDo list\n");

                    }



        }


        Task[] resizeArray(Task[] taskArr)
            {
            Task[] newArr = new Task[taskArr.Length * 2];
            for( int i = 0 ; i <= taskArr.Length; i++)
            {
            newArr[i] = taskArr[i]; 
            }
            return newArr;

            }


}




    // Method is a reusable block of code, that can take 0 or more inputs and export zero or more inputs
    //the first line of the meathod is the method signiture.
    //void is the return type

    /// <summary>
    /// Takes in a string array and foubles its size and returns the resized array with double it's capacity.
    /// </summary>
    /// <param name="StrArr"></param>
    /// <returns></returns>
    

    public class Task
    {
        public string Description { get; set; } = "";
        public string Status { get; set; } = "";
    };