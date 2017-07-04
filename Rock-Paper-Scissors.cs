using System;
using System.Linq;
namespace RockPaperScissorsGame{
    class Game {
		public const int numberOfMoves = 5; 
		
		
		/// <summary>
		/// The function askTypeOfGame ask for the user to select if he/she wants to play with another user or with the computer.
		/// </summary>
		/// <returns>a string with the type of the game. 1-play with another user, 2-play with the computer </returns>
		public static string askTypeOfGame(){
			string input = "";
			do{
				Console.WriteLine("");
				Console.WriteLine("Do you want to play with a another user or with the computer? ");
				Console.WriteLine("Press 1 for another user or Press 2 for computer");
				input = Console.ReadLine();
				if ((input != "1") && (input != "2")){
					Console.WriteLine("Wrong input!!");
				}
			} while ((input != "1")&&(input != "2"));
			return input;	
		}
		
		/// <summary>
		/// This function returns the string name of the move based on the respective symbol.
		/// </summary>
		/// <param name="UserMove">the move of the user with the symbol(0,1,2,3,4) </param>
		/// <returns> the respective string of the move (0-Rock, 1-Paper, 2-Scissors, 3-Spock, 4-Lizzard) </returns>
		public static string getMove(int UserMove){
			string move = "";
			switch(UserMove){
				case 0: move = "Rock"; break;
				case 1: move = "Paper"; break;
				case 2: move = "Scissors"; break;
				case 3: move = "Spock"; break;
				case 4: move = "Lizard"; break;
			}
			return move;
		}

		/// <summary>
		/// This function asks from the user to insert his/her choice of move.
		/// </summary>
		/// <param name="UserName">the name of the user </param>
		/// <returns> the symbolize number of user's selection </returns>		
		public static int getUserMove(string UserName){
			int UserMove;
			string UserInputMove;
			Console.WriteLine("Hello " + UserName + " !");
			do{
				if (numberOfMoves == 3)
					Console.WriteLine("Give your move(Rock, Paper, Scissors) :");
				else
					Console.WriteLine("Give your move(Rock, Paper, Scissors, Spock, Lizard) :");
					
				UserInputMove = Console.ReadLine();
				switch(UserInputMove){
					case "Rock" :
					case "rock" : 
						{UserMove = 0;} break;
					case "Paper" :
					case "paper" : 
						{UserMove = 1;} break;			  
					case "Scissors" :
					case "scissors" : 
						{UserMove = 2;} break;
					case "Spock" :
					case "spock" : 
						{UserMove = 3;} break;
					case "Lizard" :
					case "lizard" : 
						{UserMove = 4;} break;	
					default : {UserMove = numberOfMoves;} break;
				}	
				if (UserMove >= numberOfMoves)
					Console.WriteLine("Wrong Input!"); 
			}while (UserMove >= numberOfMoves);
			
			Console.WriteLine("Thank you! Your choice is : " + UserInputMove);
			Console.WriteLine();
			return UserMove;
		}
		
		/// <summary>
		/// This function choose move for the PC randomly. It gets a number between the range 0-2 included.
		/// The number 0 symbolize the choice "Rock"
		/// The number 1 symbolize the choice "Paper"
		/// The number 2 symbolize the choice "Scissors"
		/// The number 3 symbolize the choice "Spock"
		/// The number 4 symbolize the choice "Lizard"
		/// </summary>
		/// <returns> the move of the computer: 0 for Rock, 1 for Paper, 3 for Scissors </returns>
		public static int getPCMove(){
			Random r = new Random();
			int User2Move = r.Next(0, numberOfMoves); // make random choice for the move. 0-Rock, 1-Paper, 3-Scissors
			return User2Move;
		}
		
		/// <summary>
		/// This function is responsible for finding the winner of the game Rock-Paper-Scissors
		/// We symbolize 0-Rock, 1-Paper, 2-Scissors
		/// We know that:
		/// Rock > Scissors (0 > 2) , Rock > Lizard (0 > 4)
		/// Paper > Rock (1 > 0) , Paper > Spock (1 > 3)
		/// Scissors > Paper (2 > 1) , Scissors > Lizard (2 > 4)
		/// Spock > Rock (3 > 0) , Spock > Scissors (3 > 2)
		/// Lizard > Paper (4 > 1) , Lizard > Spock (4 > 3) 
		/// From the above, we can find a pattern that will help us to find the winner.  
		/// We see that when the difference between the users' moves is odd number, then the winner is the greater of these two.
		///	However, when the difference between the users' moves is even number, then the winner is the smaller of these two.
		/// So, we have 5 different cases:
		/// Case 1 : The users have the same move.
		/// Case 2 : When the (Move of User1 - Move of user2) mod 2 is  equal to 1, then the winner is user 1.
		/// Case 3 : When the (Move of User1 - Move of user2) mod 2 is  equal to -1, then the winner is user 2.
		/// Case 4 : When the (Move of User1 - Move of user2) mod 2 is  equal to 0 and the (Move of User1 - Move of user2) is positive, then the winner is user 2.
		/// Case 5 : When the (Move of User1 - Move of user2) mod 2 is  equal to 0 and the (Move of User1 - Move of user2) is negative, then the winner is user 1.		
		/// </summary>
		/// <param name="User1Move">the move of the first user</param>
		/// <param name="User2Move">the move of the second user </param>
		/// <returns>
		/// The function returns: 
		/// 0 : when the game is tie.
		/// 1 : the winner is user 1.
		/// 2 : the winner is user 2.
		/// </returns>
		public static int findWinner(int User1Move, int User2Move){			
			if (User1Move == User2Move){ // check case 1
				return 0;  // 0 - tie
			}
			if (((User1Move - User2Move) % 2) == 1) // check case 2
					return 1; // 1 - User 1 winner
			if (((User1Move - User2Move) % 2) == -1) // check case 3
					return 2; // 2 - User 2 winner
			if (((User1Move - User2Move) % 2) == 0) //check case 4 and 5
				if ((User1Move - User2Move) > 0) // check case 4
					return 2; // 2 - User 2 winner
				else //check case 5.
					return 1; // 1 - User 1 winner
			return -1; // -1 - error
		}
		
		/// <summary>
		/// This function is the main function of this program. It uses all the other functions of the program.
		/// When is necessary, it calls the appropriate function and finally it calculates the results. 
		/// </summary>
		/// <param name="typeGame">the type of the game. User vs User or User vs Computer</param>
		public static void startGame(string typeGame){
			int[] countOfMoves = new int[numberOfMoves]; //array to count the number each move is used
			Console.WriteLine();
			int User2Move, User1Move;
			string User2Name = "", User1Name = "";
			if (typeGame == "2"){ //second user is the computer
				User2Name = "Computer";
			}
			Console.WriteLine();

			int countTies = 0; //number of game's turns
			int winner = 0; 
			while ( winner == 0){ //if the game is tie keep going
				countTies++;
				if (countTies > 1){ //check if is not the first round of the game
					Console.WriteLine("The game is tie!! Another turn");
					Console.WriteLine();
				}
				Console.WriteLine("Round " + countTies);
				Console.WriteLine("-------------");
				if (countTies == 1){ //check if is not the first round of the game
					Console.WriteLine("User 1: Give your name:");
					User1Name = Console.ReadLine();	
				}
				User1Move = getUserMove(User1Name); // get first user's move
				countOfMoves[User1Move]++; 
				if (typeGame == "2"){
					User2Move = getPCMove(); // get PC's move
					countOfMoves[User2Move]++; 
				}else{
					if (countTies == 1){
						Console.WriteLine("User 2: Give your name:");
						User2Name = Console.ReadLine();	
					}
					User2Move = getUserMove(User2Name);	//get second user's move	
					countOfMoves[User2Move]++; 					
				}
				Console.WriteLine(User1Name + ": " + getMove(User1Move));
				Console.WriteLine(User2Name + ": " + getMove(User2Move));
				winner = findWinner(User1Move, User2Move);
			}
			if (winner != -1)
				printResults(countOfMoves, winner, countTies, User1Name, User2Name);
			else
				Console.WriteLine("Sorry! Something got wrong. Please start the game again..");
		}
		
		/// <summary>
		/// This function is responsible for printing the results of the game.
		/// </summary>
		/// <param name="countOfMoves">an array with how many each move is used</param>
		/// <param name="winner"> The winner of the game </param>		
		/// <param name="countTies"> The number of the game's turns </param>
		/// <param name="User1Name"> The name of the first user </param>
		/// <param name="User1Name"> The name of the second user </param>
		public static void printResults(int[] countOfMoves, int winner, int countTies, string User1Name, string User2Name){
			Console.WriteLine();
			Console.WriteLine("Results");
			Console.WriteLine("-------------");
			if (winner == 1)
				Console.WriteLine("The winner is the User 1, " + User1Name );
			else
				Console.WriteLine("The winner is the User 2, " + User2Name );
			Console.WriteLine("Congratulation!!");
			Console.WriteLine("The game took " + countTies + " turns!");
			int maxValue = countOfMoves.Max();
			int maxMove = countOfMoves.ToList().IndexOf(maxValue);
			Console.WriteLine("Most used move in this game is : " +  getMove(maxMove));
		}
		
        static void Main() 
        {
			string inputAgain = "";
			do{
				Console.WriteLine("Rock-Paper-Scissors Game!");
				Console.WriteLine("---------------------------");
				string typeGame = askTypeOfGame();
				Console.WriteLine();
				if (typeGame == "1")
					Console.WriteLine("You are playing with another user");
				else
					Console.WriteLine("You are playing with the computer");	
				startGame(typeGame);
				Console.WriteLine();
				Console.WriteLine("Do you want to play again? ");
				Console.WriteLine("Press Y for YES or any key for exit");
				inputAgain = Console.ReadLine();
				Console.WriteLine("");
			} while ((inputAgain == "Y") || (inputAgain == "y"));
        }
    }
}