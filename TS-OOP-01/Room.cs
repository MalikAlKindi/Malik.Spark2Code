namespace HotelManagementSystem;

public class Room
{
    public int roomNumber { get; set; }
    public string roomType { get; set; }
    public double pricePerNight { get; set; }
    public bool isAvailable { get; set; }

    public Room(int roomNumber, string roomType, double pricePerNight)
    {
        this.roomNumber = roomNumber;
        this.roomType = roomType;
        this.pricePerNight = pricePerNight;
        isAvailable = true;
    }

    public void displayRoom()
    {
        Console.WriteLine($"Room {roomNumber} | {roomType} | OMR {pricePerNight:F2} | {(isAvailable ? "Available" : "Booked")}");
    }
}
