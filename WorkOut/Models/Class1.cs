namespace Models;
/*
As a user, I should be able to create a workout session.
As a user, U should be able to enter excercises 

*/


/*
number of reps and sets.
name and type of workout
time spent at a gym
the datetime that workout took place
type of exercise 
what kind of wheight used.
*/



/*Bodywieght rutine.
-5 x 30 seconds of mtn climbers
-5 x 10 lunges
-5 x 10 burpies
-5 x 15 pushups.
*/

/**/

include System.TimeSpan();
public class Workout
{
    public DateTime WorkoutDate {get; set;}
    public string WorkoutName {get; set;}
    public TimeSpan WorkoutLength {get; set;}
    public List<Exercise> WorkoutExercises {get; set;}
    public double Weight {get; set;}

}

public class Exercise {

public string name {get; set;}
public string notes {get; set;}



}


public class StrengthExercise{


public int Sets {set; get;}
public int reps {set; get;}
public string WeightType {get; set;} // if bodywieght set 
public int Weight {set; get;}



}

public class CardioExercise {
public string name {get; set;}
public double Distance {get; set;}
public int CaloriesBurnt {get; set;}


}