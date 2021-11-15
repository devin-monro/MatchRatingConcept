class MatchMaker {

    string queueName;
    int queueNumber = 0;
    List<Player> playersInQueue = new List<Player>();

    List<Match> matches = new List<Match>();

    public void addPlayer(Player player) {
        string uuid = player.getUUID();

        if(!findPlayer(uuid)) {
            playersInQueue.Add(player);
            queueNumber += 1;
        } else {
            Console.Writeline("There is already a player with the UUID in queue! UUID: "+uuid);
        }
    }

    public void removePlayer(Player player) {
        string uuid =  player.getUUID();

        if(!findPlayer(uuid)) {
            playersInQueue.Remove(player);
            queueNumber -= 1;
        } else {
            Console.WriteLine("There is no player with that UUID in queue! UUID: "+ uuid);
        }
    }

    public void queueList() {
        foreach (var player in playersInQueue) {
            Console.WriteLine("UUID: " + player.getUUID() + " RATING:" + player.getRating());
        }
    }

    public void findPlayer(string uuid) {
        return playersInQueue.Where(p => String.equals(p.uuid, uuid, StringComparison.CurrentCulture));
    }

    public void createMatch(List<Player> matchPlayers) {
        string matchId = createMatchId();
        Match newMatch = new Match();
        newMatch.createMatch(matchId, matchPlayers);
        matches.add(newMatch);

        foreach(Player player in matchPlayers) {
            playersInQueue.Remove(player);
        }
    }

    public string createMatchId() {
        Guid matchId = Guid.NewGuid();
        string matchIdString = matchId.ToString();
        if(!matchIdString) {
            return matchIdString;
        } else {
            createMatchId();
        }
    }

    public void findMatch(string matchId) {
        return matches.Where(m => String.equals(m.matchId, matchId, StringComparison.CurrentCulture));
    }

}