namespace HotelManagementSystem;

public class Guest
{
    public string guestId { get; set; }
    public string guestName { get; set; }
    public int roomNumber { get; set; }
    public string checkInDate { get; set; }
    public int totalNights { get; set; }

    public Guest(string guestId, string guestName, string checkInDate, int totalNights)
    {
        this.guestId = guestId;
        this.guestName = guestName;
        roomNumber = 0;
        this.checkInDate = checkInDate;
        this.totalNights = totalNights;
    }

    public void displayGuest()
    {
        Console.WriteLine($"{guestId} | {guestName} | Room: {(roomNumber == 0 ? "Not Assigned" : roomNumber)} | Check-in: {checkInDate} | Nights: {totalNights}");
    }

    public double calculateTotalCost(List<Room> rooms)
    {
        var room = rooms.FirstOrDefault(r => r.roomNumber == roomNumber);
        return room == null ? 0 : room.pricePerNight * totalNights;
    }
}
