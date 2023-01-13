using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinesseCheckersServer
{
    public class Room
    {
        private Dictionary<int, DataAccess.Player> players;
        private Dictionary<int, IRoomMgtCallback> roomCallbacks;
        private Dictionary<int, IChatMgtCallback> chatCallbacks;
        private Dictionary<int, IGameplayMgtCallback> gameplayCallbacks;
        private Dictionary<int, char> playersColors;
        private char[] colorForTwoPlayers = new char[] { 'N', 'R' };
        private char[] colorForThreePlayers = new char[] { 'N', 'M', 'B' };
        private string idRoom;
        private int numberOfAllowedPlayers;
        private int numberOfAllowedPlayersOriginal;
        private int turn;
        public Room()
        {
            players = new Dictionary<int, DataAccess.Player>();
            roomCallbacks = new Dictionary<int, IRoomMgtCallback>();
            chatCallbacks = new Dictionary<int, IChatMgtCallback>();
            gameplayCallbacks = new Dictionary<int, IGameplayMgtCallback>();
            playersColors = new Dictionary<int, char>();
        }
        public int NumberOfAllowedPlayersOriginal
        {
            get { return numberOfAllowedPlayersOriginal; }
            set { numberOfAllowedPlayersOriginal = value; }
        }
        public char[] ColorForTwoPlayers
        {
            get { return colorForTwoPlayers; }
            set { colorForTwoPlayers = value; }
        }
        public char[] ColorForThreePlayers
        {
            get { return colorForThreePlayers; }
            set { colorForThreePlayers = value; }
        }
        public Dictionary<int,char> PlayersColors
        {
            get { return playersColors; }
            set { playersColors = value; }
        }
        public int Turn
        {
            get { return turn; }
            set { turn = value; }
        }
        public int ChangeTurn()
        {
            int nextTurn = turn + 1;
            turn = (turn == numberOfAllowedPlayersOriginal - 1 ) ? 0 : nextTurn;
            return turn;
        }
        public int NumberOfAllowedPlayers
        {
            get { return numberOfAllowedPlayers; }
            set { numberOfAllowedPlayers = value; }
        }
        public string IdRoom
        {
            get { return idRoom; }
            set { idRoom = value; }
        }
        public Dictionary<int, DataAccess.Player> Players
        {
            get { return players; }
            set { players = value; }
        }
        public Dictionary<int, IRoomMgtCallback> RoomCallbacks
        {
            get { return roomCallbacks; }
            set { roomCallbacks = value; }
        }
        public Dictionary<int, IChatMgtCallback> ChatCallbacks
        {
            get { return chatCallbacks; }
            set { chatCallbacks = value; }
        }
        public Dictionary<int, IGameplayMgtCallback> GameplayCallbacks
        {
            get { return gameplayCallbacks; }
            set { gameplayCallbacks = value; }
        }
    }
}
