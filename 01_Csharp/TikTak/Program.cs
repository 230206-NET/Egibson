

using System.Text.RegularExpressions;

namespace TikTak;

public class OtherMenu{

      public void OtherStart(){


                  //initalize the array here.
                  /*
                  Think about the 2d array like this.
                   int[,] Intarr = {
                    {0,0,0}, 
                    {0,0,0}, 
                    {0,0,0}         };
                  
                  */
                int[,] Intarr = {{0,0,0}, {0,0,0}, {0,0,0}};
                ttBoard newTTBoard = new ttBoard();
                newTTBoard.writeGreating();
                bool keepPlaying = true;
                
                while(keepPlaying)
                {
                    newTTBoard.drawfullboard(Intarr);
                    newTTBoard.play(Intarr, 1);
                    keepPlaying = newTTBoard.win(Intarr);
                    if(keepPlaying == false) break;
                    newTTBoard.drawfullboard(Intarr);
                    newTTBoard.play(Intarr, 2);
                    keepPlaying = newTTBoard.win(Intarr);

                }
                  
                  newTTBoard.writeExit();



                  }



            public class ttBoard{
                    public void drawfullboard(int[,] arr){


                    int a1 = arr[0,0];
                    int a2 = arr[0,1];
                    int a3 = arr[0,2];
                    int b1 = arr[1,0];
                    int b2 = arr[1,1];
                    int b3 = arr[1,2];
                    int c1 = arr[2,0];
                    int c2 = arr[2,1];
                    int c3 = arr[2,2];



                    Console.WriteLine
                    (""" 
                                 
                          0     1     2
                             |     |     
                    0     {0}  |  {1}  |  {2}  
                        _____|_____|_____
                             |     |     
                    1     {3}  |  {4}  |  {5}  
                        _____|_____|_____
                             |     |     
                    2     {6}  |  {7}  |  {8}  
                             |     |     
                    """, Result(a1), Result(a2), Result(a3), Result(b1), Result(b2), Result(b3), Result(c1), Result(c2), Result(c3));



                    }

                    public bool win(int[,] arr)
                    {



                        //won in a row
                        if (arr[0,0] == arr[0,1] && arr[0,0] == arr[0,2] && arr[0,0] != 0){Console.WriteLine("Player {0} wins!", arr[0,0]); return false;} 
                        if (arr[1,0] == arr[1,1] && arr[1,0] == arr[1,2] && arr[1,0] != 0){Console.WriteLine("Player {0} wins!", arr[1,0]); return false;} 
                        if (arr[2,0] == arr[2,1] && arr[2,0] == arr[2,2] && arr[2,0] != 0){Console.WriteLine("Player {0} wins!", arr[2,0]); return false;} 
                        
                        //won in a colomn
                        if (arr[0,0] == arr[1,0] && arr[0,0] == arr[2,0] && arr[0,0] != 0){Console.WriteLine("Player {0} wins!", arr[0,0]); return false;} 
                        if (arr[0,1] == arr[1,1] && arr[0,1] == arr[2,1] && arr[0,1] != 0){Console.WriteLine("Player {0} wins!", arr[0,1]); return false;} 
                        if (arr[0,2] == arr[1,2] && arr[0,2] == arr[2,2] && arr[0,2] != 0){Console.WriteLine("Player {0} wins!", arr[0,2]); return false;} 

                        //diagonal win
                        if (arr[0,0] == arr[1,1] && arr[0,0] == arr[2,2] && arr[0,0] != 0){Console.WriteLine("Player {0} wins!", arr[0,0]); return false;} 
                        if (arr[0,2] == arr[1,1] && arr[0,2] == arr[2,0] && arr[0,2] != 0){Console.WriteLine("Player {0} wins!", arr[0,2]); return false;} 
                        
                        //if none are true
                        return true;

                    }
                    public int[,] play(int[,] arr, int PID)
                    {    
                        bool validInput = false;
                        if (PID == 1) Console.WriteLine("Player 1 place an O");
                        else Console.WriteLine("Player 2 place an X");


                        while(validInput == false)
                        {
                                /*
                                Regex regex = new Regex(@"/d/d");
                                string playerInput = Console.ReadLine(); 
                                int row = int.Parse(playerInput[0]);
                                int colomn = int.Parse(playerInput[1]);
                                */
                                bool parseSuccess = false;
                                Console.WriteLine("Input Row:");            
                                int row = 0;
                                parseSuccess = int.TryParse(Console.ReadLine(), out row);
                                if (!(row == 1 || row == 2 || row == 0)) 
                                {
                                    Console.WriteLine("Bad input. Input should be: 0 or 1 or 2");
                                    continue;
                                    
                                }

                                Console.WriteLine("Input Colum:");
                                int colomn = 0;
                                parseSuccess = int.TryParse(Console.ReadLine(), out colomn);
                                if (!(colomn == 1 || colomn == 2 || colomn == 0)) 
                                {
                                    Console.WriteLine("Bad input. Input should be: 0 or 1 or 2");
                                    continue;
                                    
                                }

                                if(arr[row,colomn] == 0)
                                {
                                
                                    arr[row,colomn] = PID;
                                    validInput = true;
                                }
                                else 
                                {

                                    Console.WriteLine("There is already someone at Row {0} Colonm{1} please try again.", row, colomn);
                                    continue;
                                }
                        
                        }
                        return arr;

            }

            public void writeGreating(){
                Console.WriteLine("""
                                    xoxoxoxoxxoxoxoxoxoxoxoxoxoxoxoxoxoxoxoxoxoxoxox
                                    o Hello and Welcome to TikTakToe               o
                                    x We will keep playing until someone wins!     x
                                    o Player 1 is the O                            o
                                    x PLayer 2 is the X                            x
                                    xoxoxoxoxoxoxoxoxoxoxooxoxoxoxoxoxoxxoxoxoxoxoxo
                                """);

            }
            public void writeExit(){
                Console.WriteLine("""
                                    xoxoxoxoxxoxoxoxoxoxoxoxoxoxoxoxoxox
                                    o     Thank you for all the fun!!  o
                                    x             Bye!!                x
                                    xoxoxoxoxoxoxoxoxoxoxooxoxoxoxoxoxox
                                """);
            }
            public string Result(int a){
            if(a==1)
            return "O";
            if(a==2)
            return "X";

            return "-";

            }



            }


}

