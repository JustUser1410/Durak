using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace GameContract
{
    [ServiceContract(Namespace = "GameContract")]
    public interface IGame
    {
        //Following two could be merged into PlayCard(Card c)
        [OperationContract(IsOneWay = false)]
        bool Attack(int playerID, Card c);

        /// <summary>
        /// Notifies that 
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void EndAttack(int playerID);

        [OperationContract(IsOneWay = false)]
        bool Defend(int playerID, Card c);

        /// <summary>
        /// Tells service that user wants to surrender
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void Surrender(int playerID);

        /// <summary>
        /// Sends request to play against random player
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void PlayRandom(int playerID);

        /// <summary>
        /// Tells service that player with specified ID wants
        /// to join game with specified token.
        /// </summary>
        /// <param name="token">desired token that is necessary for somebody to join</param>
        /// <param name="playerID">player that wants to Host</param>
        [OperationContract(IsOneWay = true)]
        void HostGame(int token, int playerID);

        /// <summary>
        /// Tells service that player with specified ID wants
        /// to join game with specified token.
        /// </summary>
        /// <param name="token">token that game room was hosted with</param>
        /// <param name="playerID">player that wants to Join</param>
        /// <returns>Returns type of error (NONE if there is no error)</returns>
        [OperationContract(IsOneWay = false)]
        Errors JoinGame(int token, int playerID);

        /// <summary>
        /// Whenever user is not able to defend, he must take cards off the table
        /// and put them in his hand
        /// </summary>
        /// <returns></returns>
        [OperationContract(IsOneWay = false)]
        List<Card> TakeCards(int playerID);

        /// <summary>
        /// Notifies dealer that player is out of cards for this move
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void OutOfCards(int playerID); 
    }
}
