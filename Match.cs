public class Match {

    enum MatchState {
        Waiting = 1,
        Paused = 2,
        Live = 3,
        Halftime = 4,
    }

    MatchState state;
    string matchId;
    List<Player> playersInGame = new List<Player>();

    var[] scoreboard = null;

    int round = 0;

    string[] afk;

    public void createMatch(string id, List<Player> players) {
        matchId = id;
        playersInGame = players;
        state = MatchState.Waiting;
    }

    public void addPlayer(Player player) {
        if (!findPlayer(player.getUUID())) {
            playersInGame.Add(player);
        } else {
            Console.WriteLine("Attempted to add a duplicate UUID to the Match! Match: {0} UUID: {1}", matchId, player.getUUID());
        }
    }

    public void startMatch() {
        if (state == MatchState.Live)
            state = MatchState.Live;
        else 
            Console.WriteLine("Attempted to start a match that is already running! MatchID: {0}", matchId);
    }

    public void endMatch(string reason) {
        if(reason == "completed") {

        } else if (reason == "canceled") {

        } else if (reason == "surrender") {

        }
    }

    public void findPlayer(string uuid) {
        return playersInGame.Where(p => String.equals(p.uuid, uuid, StringComparison.CurrentCulture));
    }

}