
class Player {
    string uuid;
    string name;
    float rating;

    public void createPlayer(string playerName, float playerRating, string playerUUID) {
        name = playerName;
        rating = playerRating;
        uuid = playerUUID;
    }

    public void getRating() {
        return rating;
    }

    public void updateRating(float updatedRating) {
        rating = updatedRating;
    }

    public string getUUID() {
        return uuid;
    }
    public string getName() {
        return name;
    }
}