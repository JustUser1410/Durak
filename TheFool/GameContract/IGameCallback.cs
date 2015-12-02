using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using TheFool;

namespace GameContract
{
    [ServiceContract(Namespace = "GameContract")]
    public interface IGameCallback
    {
        /// <summary>
        /// Sets which player has turn
        /// </summary>
        /// <param name="playerID"> id of a player that has the turn</param>
        [OperationContract]
        void PlayerTurn(int playerID);

        /// <summary>
        /// Sends all cards that are on the table (that were used for attack/defence)
        /// It is called after player fails to defend or decides to take the cards
        /// </summary>
        /// <param name="c">list of cards that are currently played</param>
        [OperationContract]
        void CardsOnTable(List<Card> c);

        /// <summary>
        /// WE HAVE TO TALK ABOUT THIS ONE <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        /// we could just give a return value for Attack/Defend method
        /// in IGame. This way service would have to return something 
        /// every time.
        /// </summary>
        /// <param name="e"></param>
        [OperationContract]
        void InvalidMove(Errors e);

        /// <summary>
        /// Sends cards to players at the end of each turn
        /// if there are some left in the deck
        /// </summary>
        /// <param name="c">list of cards</param>
        [OperationContract]
        void DrawCards(List<Card> c);

        /// <summary>
        /// Sends new received message 
        /// </summary>
        /// <param name="message"></param>
        [OperationContract]
        void ReceivedMessage(String message);

        /// <summary>
        /// Informs user that server cannont let user host
        /// </summary>
        /// <param name="e">Type of error</param>
        [OperationContract]
        void CannotHost(Errors e);//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<NOT SURE IF NECESSARY ANYMORE

        /// <summary>
        /// Informs user that server cannont let user join
        /// </summary>
        /// <param name="e">Type of error</param>
        [OperationContract]
        void CannotJoin(Errors e);//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<NOT SURE IF NECESSARY ANYMORE

        /// <summary>
        /// Before game starts, notifies user that opponent is ready
        /// </summary>
        /// <param name="playerID"> id of the opponent</param>
        [OperationContract]
        void PlayerReady(int playerID);

        /// <summary>
        /// After game is over, sends which position user has taken
        /// </summary>
        /// <param name="yourPosition"> 1 = won, 0 = lost</param>
        [OperationContract]
        void GameOver(int yourPosition);


    }
}
