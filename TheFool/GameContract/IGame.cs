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
    public interface IGame
    {
        //Following two could be merged into PlayCard(Card c)
        [OperationContract]
        void Attack(Card c);

        [OperationContract]
        void Defend(Card c);

        /// <summary>
        /// Tells service that user wants to surrender
        /// </summary>
        [OperationContract]
        void Surrender();

        /// <summary>
        /// Sends request to play against random player
        /// </summary>
        [OperationContract]
        void PlayRandom(int playerID);

        /// <summary>
        /// Tells service that player with specified ID wants
        /// to join game with specified token.
        /// </summary>
        /// <param name="token">desired token that is necessary for somebody to join</param>
        /// <param name="playerID">player that wants to Host</param>
        [OperationContract]
        void HostGame(int token, int playerID);

        /// <summary>
        /// Tells service that player with specified ID wants
        /// to join game with specified token.
        /// </summary>
        /// <param name="token">token that game room was hosted with</param>
        /// <param name="playerID">player that wants to Join</param>
        /// <returns>Returns type of error (NONE if there is no error)</returns>
        [OperationContract]
        Errors JoinGame(int token, int playerID);
    }
}
